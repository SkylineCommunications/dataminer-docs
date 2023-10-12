---
uid: SRM_update_timing_booking_silently
---

# Silently updating the timing of a booking

The example below shows how the timing of a booking can be changed without user interaction by means of an Automation script.

> [!NOTE]
> The timing of events that have already been executed cannot be changed.

```csharp
using System;
using Skyline.DataMiner.Library.Solutions.SRM;
using Skyline.DataMiner.Library.Solutions.SRM.Model.ReservationAction;
using Skyline.DataMiner.Automation;

public class Script
{
 public static void Run(Engine engine)
 {
 // Replace with reservation guid
 var reservationId = Guid.NewGuid();

 // Replace with Element Name of the Booking Manager
 string bookingManagerElementName = "Booking Manager";

 // Replace with expected timing
 DateTime start = DateTime.UtcNow.AddHours(2);
 DateTime end = start.AddHours(4);
 TimeSpan preRoll = TimeSpan.FromMinutes(5);
 TimeSpan postRoll = TimeSpan.FromMinutes(5);

 var reservationInstance = SrmManagers.ResourceManager.GetReservationInstance(reservationId);

 var bookingManager = new BookingManager(engine,
 engine.FindElement(bookingManagerElementName));

 var newTiming = new ChangeTimeInputData
 {
 StartDate = start,
 EndDate = end,
 PreRoll = preRoll,
 PostRoll = postRoll,
 IsSilent = true
 };

 var result = bookingManager.TryChangeTime(engine, ref reservationInstance, newTiming);
 }
}
```
