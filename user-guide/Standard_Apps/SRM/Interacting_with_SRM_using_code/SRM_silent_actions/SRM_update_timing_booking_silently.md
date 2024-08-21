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

> [!NOTE]
> Since SRM Framework 1.2.37/2.0.2 <!-- RN40481 --> it's possible to finish a permanent booking while defining post-roll. To do so, the timing of that booking should be changed, by changing the end date to a time in the near future and setting the appropriate post-roll time.
> Finishing a permanent booking will not support defining any post-roll.
> Although the reservation time of contributing bookings will adapt accordingly, if appropriate, no post-roll will be set. When orchestration would be required, the timing can be changed for each of them separately.
