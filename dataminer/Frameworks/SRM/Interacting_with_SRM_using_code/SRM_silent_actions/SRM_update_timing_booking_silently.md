---
uid: SRM_update_timing_booking_silently
---

# Silently updating the timing of a booking

The example below shows how the timing of a booking can be changed without user interaction by means of an automation script.

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
> From version 2.0.2 of the SRM framework feature release track (Dev Pack) onwards<!-- RN40481 -->, it is possible to finish a permanent booking while defining a post-roll time. To do so, change the timing of that booking using `ChangeTime`/`TryChangeTime` like in the example above, by changing the end date to a time in the near future and setting the appropriate post-roll time. Providing a post-roll time is not supported when a permanent booking is finished using `Finish`/`TryFinish`. Although the timing of contributing bookings will be adapted accordingly if appropriate, no post-roll time will be set for the contributing bookings. In case orchestration is required, you will need to change the timing for each of them separately.
