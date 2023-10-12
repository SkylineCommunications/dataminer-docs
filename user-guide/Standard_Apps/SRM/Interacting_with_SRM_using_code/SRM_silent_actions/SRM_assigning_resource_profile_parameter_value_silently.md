---
uid: SRM_assigning_resource_profile_parameter_value_silently
---

# Silently assigning resource, profile and parameter values

The example below shows how resource, profile, and parameter values can be assigned to a booking without user interaction by means of an Automation script.<!-- RN 26134 -->

> [!NOTE]
> If you assign a resource to a running booking, SRM will update the content of the DataMiner service accordingly. However, you will need to force the service state to transition again so that LSO and Profile-Load Scripts will be executed. This is also necessary if you change the settings applied to a resource while the booking is already running. If the booking has not started yet, the updated settings will automatically be used when LSO and PLS are applied.

```csharp
using System;
using Skyline.DataMiner.Library.Solutions.SRM;
using Skyline.DataMiner.Library.Solutions.SRM.Model.AssignProfilesAndResources;
using Skyline.DataMiner.Library.Solutions.SRM.Model;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.ResourceManager.Objects;

public class Script
{
 public static void Run(Engine engine)
 {
 // Replace with reservation guid
 var reservationId = Guid.NewGuid();

 var reservationInstance = SrmManagers.ResourceManager.GetReservationInstance(reservationId) as ServiceReservationInstance;

 var requests = new[]
 {
 // Assign a resource (update with relevant data)
 new AssignResourceRequest
 {
 TargetNodeLabel = "DEC1",
 NewResourceId = Guid.Parse("4d4c6525-8fbc-419c-9250-7e8b59dd2fcb")

 },
 // Unassign a resource (update with relevant data)
 new AssignResourceRequest
 {
 TargetNodeLabel = "DEC2",
 NewResourceId = Guid.Empty

 },
 // Assign a profile instance (update with relevant data)
 new AssignResourceRequest
 {
 TargetNodeLabel = "DEC3",
 ProfileInstanceId = Guid.Parse("c4130041-21c5-4693-bbe5-ef1efe78ff04"),
 ByReference = false

 },
 };
 reservationInstance.AssignResources(engine, requests);

 // Assign a profile parameter value (update with relevant data)
 var request = new AssignResourceRequest
 {
 TargetNodeLabel = "DEC3",
 ProfileInstanceId = Guid.Parse("c4130041-21c5-4693-bbe5-ef1efe78ff04"),
 ByReference = false
 };
 var param = new Parameter
 {
 Id = Guid.Parse("7f8bd260-0d26-46c1-9093-08b16a5f7dcf"),
 Value = "abc"
 };
 request.OverriddenParameters.Add(param);
 reservationInstance.AssignResources(engine, request);

 // PLEASE USE VISUAL STUDIO TO SEE ALL OPTIONS ON AssignResourceRequest,
 // including manipulating parameters and instance on interface level
 }
}
```

> [!NOTE]
> When the *TargetNodeLabel* is empty or null, the resource added to the booking will not be mapped to any node in the service definition.<!-- RN 30150 -->
