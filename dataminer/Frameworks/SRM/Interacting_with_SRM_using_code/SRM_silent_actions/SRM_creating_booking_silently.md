---
uid: SRM_creating_booking_silently
---

# Silently creating a booking

The example below shows how a booking can be created without user interaction by means of an automation script.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Core.SRM;
using Skyline.DataMiner.Core.SRM.Model;
using Skyline.DataMiner.Core.SRM.Model.Events;
using Skyline.DataMiner.Core.SRM.Model.Properties;

/// <summary>
/// Represents a DataMiner Automation script.
/// </summary>
public class Script
{
   /// <summary>
   /// The script entry point.
   /// </summary>
   /// <param name="engine">Link with SLAutomation process.</param>
   public static void Run(Engine engine)
   {
      // Update with relevant data
      var bookingManagerElementName = "Booking Manager";
      var bookingDurationSeconds = 3600;
      var bookingDescription = $"Booking {DateTime.Now.ToString("yyyyMMdd HHmmss")}";
      var serviceDefinitionId = Guid.Parse("c2583ca4-a55e-483f-a50e-7d5e0a6b357f");
      var start = DateTime.Now.AddSeconds(20);
      var end = start.AddSeconds(bookingDurationSeconds);

      var bookingManager = new BookingManager(bookingManagerElementName);

      // Configuring booking main info - PLEASE USE VISUAL STUDIO TO SEE ALL OPTIONS
      var bookingData = new Booking
      {
         Description = bookingDescription,
         Recurrence = new Recurrence
         {
            StartDate = DateTime.SpecifyKind(start, DateTimeKind.Local),
            EndDate = DateTime.SpecifyKind(end, DateTimeKind.Local),
         },
         ServiceDefinition = serviceDefinitionId.ToString(),
      };

      var functions = new Function[]
      {
         // Configuring node(s) - PLEASE USE VISUAL STUDIO TO SEE ALL OPTIONS
         new Function
         {
            Id = 1,
            ShouldAutoSelectResource = false,
            SelectedResource = "0e7a1e0c-6b14-484f-ae13-46e71a522d7a",
            ProfileInstance = "73697f60-789f-4b9b-a1b0-4f7d5776a0e9",
         },
         new Function
         {
            Id = 2,
            ShouldAutoSelectResource = false,
            SelectedResource = "77a391a1-d5a2-46e3-a6b6-e7b80d4cd139",
            ProfileInstance = "4e7941ab-ed99-4adc-bda3-ebe48b1b2602",
         },
      };

      // Selecting properties - PLEASE USE VISUAL STUDIO TO SEE ALL OPTIONS
      var properties = new List<Property>();
      var property = bookingManager.Properties.FirstOrDefault(x =>
      string.Equals(x.Name, "test property", StringComparison.InvariantCultureIgnoreCase));

      if (property != null)
      {
         property.Value = "test value";
         property.IsChecked = true;
         properties.Add(property);
      }

      // Selecting custom events - PLEASE USE VISUAL STUDIO TO SEE ALL OPTIONS
      var customEvents = new List<Event>();
      var customEvent = bookingManager.Events.FirstOrDefault(x =>
      string.Equals(x.Name, "test event", StringComparison.InvariantCultureIgnoreCase));

      if (customEvent != null)
      {
         customEvent.IsChecked = true;
         customEvents.Add(customEvent);
      }

      // Safe method, won't throw exceptions, though in case of error cannot be seen
      var success = bookingManager.TryCreateNewBooking(engine, bookingData, functions, customEvents, properties, null, out var reservation);

      // Not safe, this method will throw exceptions in case of failure, a try catch is necessary
      try
      {
         reservation = bookingManager.CreateNewBooking(engine, bookingData, functions, customEvents, properties);
      }
      catch (Exception e)
      {
         engine.Log($"Failed to create booking {bookingData.Description} (ID: {bookingData.BookingId}) due to: {e}");
      }
   }
}
```

> [!NOTE]
>
> - In case a null service definition is provided, SRM will use a dynamically generated blank service definition.<!-- RN 30324 -->
> - To add a resource without linking it to a node in the service definition, do not provide the *Id* attribute of the *Function* object.<!-- RN 30324 -->
> - From SRM 1.2.34 onwards<!-- RN 37774 -->, it is possible to pass the security view IDs. To do so, fill in the *SecurityViewIds* property of the *Booking* object with the list of security view GUIDs.

## Handling bookings with a start date in the past

When you create a booking with a start date in the past, we strongly recommend waiting until the booking is fully started before performing any other operations. This prevents updates made during the start process from being overridden.

Use the following code to ensure the booking is correctly started after creation:

```csharp
bool IsBookingLifeCycleCorrect(ReservationInstance booking)
{
   if (booking.IsInPreRoll())
   {
   return booking.GetBookingLifeCycle() == GeneralStatus.Starting;
   }
   else if (booking.IsRunning())
   {
   return booking.GetBookingLifeCycle() == GeneralStatus.Running;
   }
   else if (booking.IsInPostRoll())
   {
   return booking.GetBookingLifeCycle() == GeneralStatus.Stopping;
   }
 
   return true;
}

bool CheckCorrectBookingLifeCycle()
{
   reservation = SrmManagers.ResourceManager.GetReservationInstance(reservation.ID);
   return IsBookingLifeCycleCorrect(reservation);
}

if (reservation.Start <= DateTime.UtcNow && !IsBookingLifeCycleCorrect(reservation))
{
   Skyline.DataMiner.Core.SRM.Utils.MiscExtensionMethods.RetryUntilSuccessOrTimeout(CheckCorrectBookingLifeCycle, bookingManager.RetryTimeout, bookingManager.RetryInterval);
}
```

This approach ensures that the booking process completes correctly before any further actions are taken.
