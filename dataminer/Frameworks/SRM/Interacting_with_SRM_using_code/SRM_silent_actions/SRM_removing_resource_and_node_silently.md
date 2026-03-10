---
uid: SRM_removing_resource_and_node_silently
---

# Silently removing a resource and node from a booking and potentially creating a new service definition

<!-- RN 30812 -->

When a resource has to be removed from a booking and the service definition with the associated node also has to be removed, you can use the *TryRemoveAndNode* method.

In case there is no matching service definition that can cope with the updated list of resources in the booking, DataMiner SRM will try to identify another service definition or create a new one.

Here is a code sample:

```csharp
using System;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Core.SRM;
using Skyline.DataMiner.Core.SRM.Extensions.Reservations;

public class Script
{
	public void Run(Engine engine)
	{
		// Update with relevant data
		var reservationGuid = Guid.NewGuid();
		var resourceGuid = Guid.NewGuid();
		var nodeId = 1;

		var reservation = SrmManagers.ResourceManager.GetReservationInstance(reservationGuid);
		var bookingManager = reservation.FindBookingManager();

		bookingManager.TryRemoveResourceAndNode(engine, ref reservation, resourceGuid, nodeId);

		// Example of passing a service definition template as an extra parameter to the TryRemoveResourceAndNode method
		var existingServiceDefinitionGuid = Guid.NewGuid();
		bookingManager.TryRemoveResourceAndNode(engine, ref reservation, resourceGuid, nodeId, existingServiceDefinitionGuid);
	}
}
```

> [!NOTE]
>
> - In case a service definition needs to be created, it will not be a template.
> - A non-template service definition will not be cleaned up.
> - Since version 1.2.33 <!-- RN 36792 --> it is possible to pass the desired service definition as a parameter to the *RemoveResourceAndNode* and *TryRemoveResourceAndNode* methods. If the passed service definition contains the correct nodes, it will be used; otherwise the behavior will be the same as described above.
