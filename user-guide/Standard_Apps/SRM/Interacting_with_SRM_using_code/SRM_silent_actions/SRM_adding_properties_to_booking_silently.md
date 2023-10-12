---
uid: SRM_adding_properties_to_booking_silently
---

# Silently adding properties to an existing booking

The example below shows how properties can be added to an existing booking without user interaction by means of an Automation script.

```csharp
using System;
using System.Collections.Generic;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Library.Reservation;
using Skyline.DataMiner.Library.Solutions.SRM;

public class Script
{
 public static void Run(Engine engine)
 {
 // Replace with reservation guid

 var reservationId = Guid.NewGuid();

 var properties = new Dictionary<string, object> { { "testproperty", "testvalue" } };

 var reservationInstance = SrmManagers.ResourceManager.GetReservationInstance(reservationId);
 reservationInstance.UpdateServiceReservationProperties(properties);
 }
}
```
