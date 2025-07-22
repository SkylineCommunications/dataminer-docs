---
uid: SRM_apply_LS_transition_silently
---

# Silently applying booking life cycle transitions

The example below shows how booking life cycle transitions (Finish, On-Hold, Confirm, Cancel, or Delete) can be applied to an existing booking without user interaction by means of an Automation script.

> [!NOTE]
> Using the *TryChangeStateToConfirmed* call as illustrated below will also trigger any Created Booking custom script.

```csharp
using System;
using Skyline.DataMiner.Library.Solutions.SRM;
using Skyline.DataMiner.Automation;

public class Script
{
 public static void Run(Engine engine)
 {
 // Replace with reservation guid
 var reservationId = Guid.NewGuid();

 // Replace with Element Name of the Booking Manager
 var bookingManagerElementName = "Booking Manager";

 var reservationInstance = SrmManagers.ResourceManager.GetReservationInstance(reservationId);

 var bookingManager = new BookingManager(engine,
 engine.FindElement(bookingManagerElementName));

 var result = bookingManager.TryChangeStateToConfirmed(engine, ref reservationInstance);
 //var result = bookingManager.TryFinish(engine, ref reservationInstance);
 //var result = bookingManager.TryChangeStateToOnHold(engine, ref reservationInstance);
 //var result = bookingManager.TryCancel(engine, ref reservationInstance);
 //var result = bookingManager.TryDelete(engine, reservationInstance);
 }
}
```
