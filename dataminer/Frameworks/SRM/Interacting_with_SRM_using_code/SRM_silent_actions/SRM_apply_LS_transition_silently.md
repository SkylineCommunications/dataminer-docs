---
uid: SRM_apply_LS_transition_silently
---

# Silently applying booking lifecycle transitions

The example below shows how booking lifecycle transitions (Finish, On-Hold, Confirm, Cancel, or Delete) can be applied to an existing booking without user interaction by means of an automation script.

> [!NOTE]
> Using the *TryChangeStateToConfirmed* call as illustrated below will also trigger any Created Booking custom script.

```csharp
using System;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Core.SRM;
using Skyline.DataMiner.Core.SRM.Extensions.Reservations;

public class Script
{
   public static void Run(Engine engine)
   {
      // Replace with reservation guid
      var reservationId = Guid.NewGuid();

      var reservation = SrmManagers.ResourceManager.GetReservationInstance(reservationId);

      var bookingManager = reservation.FindBookingManager();

      var result = bookingManager.TryChangeStateToConfirmed(engine, ref reservation);
      //var result = bookingManager.TryFinish(engine, ref reservation);
      //var result = bookingManager.TryChangeStateToOnHold(engine, ref reservation);
      //var result = bookingManager.TryCancel(engine, ref reservation);
      //var result = bookingManager.TryDelete(engine, reservation);
   }
}
```
