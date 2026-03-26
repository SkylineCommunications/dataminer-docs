---
uid: SRM_rename_booking_silently
---

# Silently renaming a booking

The example below shows how a booking and the associated DataMiner service can be renamed without user interaction by means of an automation script.

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

      var changeNameInputData = new ChangeNameInputData
      {
         IsSilent = true,
         Name = "New Booking Name",
      };

      var result = bookingManager.TryChangeName(engine, ref reservation, changeNameInputData);
   }
}
```
