---
uid: SRM_editing_pending_booking_silently
---

# Silently editing a pending booking

If a booking has not yet started, you can use the *TryEditBooking* method to silently edit its content.<!-- RN 32000 -->

The example below shows how you can use this to update the name of a booking.

```csharp
using System;
using Skyline.DataMiner.Library.Solutions.SRM;
using Skyline.DataMiner.Library.Solutions.SRM.Model;
using Skyline.DataMiner.Automation;

public class Script
{
    public void Run(Engine engine)
    {
        // to be replaced with reservation guid;
        var reservationId = Guid.Parse("<Reservation ID>");
        var reservation = SrmManagers.ResourceManager.GetReservationInstance(reservationId);

        var bookingManager = reservation.FindBookingManager(engine);
        var bookingData = reservation.GetBookingData();
        bookingData.Description = "new booking description";

        // TryEditBooking is available since 1.2.21. In earlier versions EditBooking can be used as an alternative.
        var result = bookingManager.TryEditBooking(engine, reservation.ID, bookingData, null, null, null, null, out reservation);
    }
}
```

The example below show how you can use this to update the name and the resource assigned to node 1:

```csharp
using System;
using System.Linq;
using Skyline.DataMiner.Library.Solutions.SRM;
using Skyline.DataMiner.Library.Solutions.SRM.Model;
using Skyline.DataMiner.Automation;

public class Script
{
    public void Run(Engine engine)
    {
        // to be replaced with reservation guid;
        var reservationId = Guid.Parse("<Reservation ID>");
        var reservation = SrmManagers.ResourceManager.GetReservationInstance(reservationId);

        var bookingManager = reservation.FindBookingManager(engine);
        var bookingData = reservation.GetBookingData();
        bookingData.Description = "new booking description";

        var functionData = reservation.GetFunctionData();
        functionData.Single(x => x.Id == 1 /* Node ID */).SelectedResource = "new resource guid";

        // TryEditBooking is available since 1.2.21. In earlier versions EditBooking can be used as an alternative.
        var result = bookingManager.TryEditBooking(engine, reservation.ID, bookingData, functionData, null, null, null, out reservation);
    }
}
```
