---
uid: SRM_adding_properties_to_booking_silently
---

# Silently adding properties to an existing booking

The example below shows how properties can be added to an existing booking without user interaction by means of an automation script.

```csharp
using System;
using System.Collections.Generic;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Core.SRM;
using Skyline.DataMiner.Core.SRM.Extensions.Reservations;

public class Script
{
	public static void Run(Engine engine)
	{
		// Update with relevant data
		var reservationId = Guid.NewGuid();
		var propertyName = "Property";
		var propertyValue = "Value";

		var properties = new Dictionary<string, object> { { propertyName, propertyValue } };

		var reservationInstance = SrmManagers.ResourceManager.GetReservationInstance(reservationId);
		reservationInstance.UpdateServiceReservationProperties(properties);
	}
}
```
