---
uid: SRM_create_service_for_booking
---

# Create service for existing booking

When a solution uses the *External Service Management* option is up to the solution to manage the service, though for ease of use, method *ServiceManagement.CreateReservationService* can be used to create a service for an existing booking. This method will create a service based on the current booking content in the same way that would be done automatically by the framework when a booking is created/started.

> [!NOTE]
> This is available from version 1.2.36 of the SRM framework. <!-- RN 39096 -->

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