---
uid: SRM_apply_service_state_transitions_silently
---

# Silently applying service state transitions

The example below shows how you can apply service state transitions (Start, Stop, Pause, Standby, etc.) or force the same service state without user interaction by means of an automation script.

```csharp
using System;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Core.SRM;
using Skyline.DataMiner.Core.SRM.Extensions.Reservations;
using Skyline.DataMiner.Net.ResourceManager.Objects;

public class Script
{
	public static void Run(Engine engine)
	{
		// Replace with reservation guid
		var reservationGuid = Guid.NewGuid();

		var reservation = SrmManagers.ResourceManager.GetReservationInstance(reservationGuid) as ServiceReservationInstance;

		var bookingManager = reservation.FindBookingManager();

		// Apply service state async
		bookingManager.ApplyServiceState(engine, reservation, "STANDBY");
	}
}
```

> [!NOTE]
> This call will run asynchronously. An overloaded method can be used to run it synchronously.<!-- RN 30454 -->
