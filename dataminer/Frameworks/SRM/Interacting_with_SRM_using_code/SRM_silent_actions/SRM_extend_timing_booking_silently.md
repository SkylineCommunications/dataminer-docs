---
uid: SRM_extend_timing_booking_silently
description: "Find out how, by using TryExtend in an automation script, you can silently extend the timing of an SRM booking by one hour without user interaction."
---

# Silently extending the timing of a booking

The example below shows how the timing of a booking can be extended without user interaction by means of an automation script.<!-- RN 26212 -->

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
      var reservationGuid = Guid.NewGuid();

      var reservation = SrmManagers.ResourceManager.GetReservationInstance(reservationGuid);

      var bookingManager = reservation.FindBookingManager();

      var extendBookingInputData = new ExtendBookingInputData
      {
         IsSilent = true,
         TimeToAdd = TimeSpan.FromHours(1),
      };

      var result = bookingManager.TryExtend(engine, ref reservation, extendBookingInputData);
   }
}
```
