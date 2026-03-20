---
uid: SRM_update_timing_booking_silently
---

# Silently updating the timing of a booking

The example below shows how the timing of a booking can be changed without user interaction by means of an automation script.

> [!NOTE]
>
> - The timing of events that have already been executed cannot be changed.
> - Dates should be passed in local time. The Booking Manager will take care of converting them to UTC.

```csharp
using System;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Core.SRM;
using Skyline.DataMiner.Core.SRM.Extensions.Reservations;
using Skyline.DataMiner.Core.SRM.Model.ReservationAction;

public class Script
{
   public static void Run(Engine engine)
   {
      // Replace with reservation guid
      var reservationId = Guid.NewGuid();

      // Replace with expected timing
      var start = DateTime.Now.AddHours(2);
      var end = start.AddHours(4);
      var preRoll = TimeSpan.FromMinutes(5);
      var postRoll = TimeSpan.FromMinutes(5);

      var reservation = SrmManagers.ResourceManager.GetReservationInstance(reservationId);

      var bookingManager = reservation.FindBookingManager();

      var newTiming = new ChangeTimeInputData
      {
         StartDate = start,
         EndDate = end,
         PreRoll = preRoll,
         PostRoll = postRoll,
         IsSilent = true,
      };

      var result = bookingManager.TryChangeTime(engine, ref reservation, newTiming);
   }
}
```

> [!NOTE]
> From version 2.0.2 of the SRM framework feature release track (Dev Pack) onwards<!-- RN40481 -->, it is possible to finish a permanent booking while defining a post-roll time. To do so, change the timing of that booking using `ChangeTime`/`TryChangeTime` like in the example above, by changing the end date to a time in the near future and setting the appropriate post-roll time. Providing a post-roll time is not supported when a permanent booking is finished using `Finish`/`TryFinish`. Although the timing of contributing bookings will be adapted accordingly if appropriate, no post-roll time will be set for the contributing bookings. In case orchestration is required, you will need to change the timing for each of them separately.
