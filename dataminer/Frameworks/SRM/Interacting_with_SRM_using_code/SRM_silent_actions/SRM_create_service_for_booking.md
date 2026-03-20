---
uid: SRM_create_service_for_booking
---

# Creating a service for an existing booking

When a solution uses the *External Service Management* option, it is up to the solution to manage the services for bookings. However, for ease of use, the method *ServiceManagement.CreateReservationService* can be used to create a service for an existing booking. This method will create a service based on the current booking content in the same way as the SRM framework automatically creates a service when a booking is created or started.

This feature is available from SRM 1.2.36 onwards.<!-- RN 39096 -->

```csharp
using System;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Core.SRM;
using Skyline.DataMiner.Core.SRM.Extensions.Reservations;
using Skyline.DataMiner.Core.SRM.FastBookingCreation;
using Skyline.DataMiner.Net.ResourceManager.Objects;

public class Script
{
   public static void Run(Engine engine)
   {
      // Replace with reservation guid
      var reservationGuid = Guid.NewGuid();

      var reservation = SrmManagers.ResourceManager.GetReservationInstance(reservationGuid) as ServiceReservationInstance;
      var logger = reservation.GetCachedLogger();
      var bookingManager = reservation.FindBookingManager();

      var srmContext = new SrmManagersContext(engine, bookingManager, reservation, logger);
      ServiceManagement.CreateReservationService(srmContext);
   }
}
```
