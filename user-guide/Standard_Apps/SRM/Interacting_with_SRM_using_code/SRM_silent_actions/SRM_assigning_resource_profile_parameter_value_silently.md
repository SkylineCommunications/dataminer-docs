---
uid: SRM_assigning_resource_profile_parameter_value_silently
---

# Silently assigning resource, profile and parameter values

The example below shows how resource, profile, and parameter values can be assigned to a booking without user interaction by means of an Automation script.

> [!NOTE]
> In case the booking is already running, you must force the service state to transition again so that LSO and Profile-Load Scripts will be executed to apply new settings or to configure the new resource.

```cs
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
