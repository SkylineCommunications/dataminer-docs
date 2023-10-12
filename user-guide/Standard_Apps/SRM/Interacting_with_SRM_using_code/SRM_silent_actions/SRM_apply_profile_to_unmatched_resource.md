---
uid: SRM_apply_profile_to_unmatched_resource
---

# Silently applying a profile to an unmapped resource or resource not part of a booking

<!-- RN 30228 -->

> [!TIP]
> See also: [Manipulating unlinked resources](xref:Service_Orchestration_LSO_script#manipulating-unlinked-resources)

It is possible to apply a profile when it is assigned unmapped to a booking. In the LSO script, an unmapped resource can be selected from a booking to then apply the profile instance or the state profile instance to a resource. A method is also available to apply the combination of both profile instance and state profile instance.

In an LSO script, the unmapped resource can be selected using the *SrmBookingConfiguration*:

```csharp
// Select the unmapped resource, assigned to the booking, by its ID
var unmappedResource = srmBookingConfig.GetUnmappedResource(unmappedResourceId);
unmappedResource.ApplyProfile("APPLY");
unmappedResource.ApplyServiceActionProfile("START", "APPLY");

// Select all unmapped resources, assigned to the booking
var unmappedResources = srmBookingConfig.GetUnmappedResources();
 
// Select all mapped and unmapped resources, assigned to the booking
var resources = srmBookingConfig.GetResourcesToOrchestrate();
```

## Applying the combined configuration and state profile instance

The following method allows you to apply both the configuration and state profile instance to an unmapped resource:

```csharp
// Select the unmapped resource, assigned to the booking, by its ID
var unmappedResource = srmBookingConfig.GetUnmappedResource(unmappedResourceId);
// Apply the values of the START State Profile Instance.
// If either is unavailable, apply the value available in the Profile Instance.
unmappedResource.ApplyCombinedProfile("START", "APPLY");
```

## Applying a profile instance to a resource without a related booking

The extension method *Skyline.DataMiner.Library.Resource.ResourceExtensionMethods.GetOrchestrationHelper* allows you to apply a profile instance, a state profile instance, or both combined to a resource that is not part of a booking.

```csharp
using Skyline.DataMiner.Library.Resource;
// ...
// Select the unmapped resource, assigned to the booking, by its ID
var orchestrationHelper = resource.GetOrchestrationHelper(
    engine,
    profileInstanceId,
    new Dictionary<int, Guid> { { interfaceId, interfaceProfileInstanceId } });

orchestrationHelper.ApplyProfile("APPLY");
orchestrationHelper.ApplyServiceActionProfile("START", "APPLY");
orchestrationHelper.ApplyCombinedProfile("START", "APPLY");
```

> [!NOTE]
> To assess if the orchestration went as expected, the actions can be logged. From SRM version 1.2.18<!-- RN 30975 --> onwards, *GetOrchestrationHelper* also has an overload that takes the Booking Manager as an argument. The helper will then create a log file (in the format `Resource_[Resource ID]_[Orchestration time].html`) in the location specified in the Booking Manager.
