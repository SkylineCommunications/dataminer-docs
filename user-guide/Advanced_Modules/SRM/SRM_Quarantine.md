---
uid: SRM_Quarantine
---

# Quarantine

## What is the quarantine state?

The quarantine state is a special state of a booking, that indicates the booking cannot start because one or more resources that were assigned are no longer available. Bookings are automatically moved to this state when the ResourceManager detects such a situation. Usually this is because overlapping bookings using the same resource are added or modified and the resource does not have enough capacity or concurrency to support all bookings.

Bookings that are in a quarantine state will have the ``IsQuarantined`` flag set to true on the ``ReservationInstance`` object, and will have the status set to ``Pending``. These bookings will still reserve the non-quarantined resources, the same way they would if they were in a regular ``Pending`` state. The resources that are no longer available are still present on the booking in the ``QuarantinedResources`` collection, along with some information about why these resources were moved to quarantine.

## Practical examples

### Concurrency conflict

Consider a system that has a booking with two resources *Resource A* and *Resource B*. Each resource in this system has a maximum concurrency of one, so it can only be used by one booking at the same time.

![Quarantine concurrency example before](~/user-guide/images/quarantine_example_concurrencies_existing.png)

If a second booking is added to the system that overlaps with the first booking and also wants to use *Resource A*, there will be a scheduling conflict. *Resource A* does not have enough concurrency to support the second booking. If the addition of the second booking is forced anyway, the ResourceManager would resolve the conflict as follows:

![Quarantine concurrency example result](~/user-guide/images/quarantine_example_concurrencies_result.png)

In the diagram above *Booking one* was moved to quarantine, because it has the lowest priority (see [Quarantine priority](#quarantine-priority)). *Booking one* will not start until the quarantine conflict is resolved. *Resource B* is however still assigned to *Booking one*, meaning if another booking is created that overlaps with *Booking one* and tries to use *Resource B*, another scheduling conflict will arise. 

### Capacity conflict

Consider a system that has two existing bookings in the confirmed state, each using a resource *Resource A*. *Resource A* has a concurrency of 10, so it can be used by 10 bookings at the same time, and has a capacity defined, with a maximum bookable value of 10.

![Quarantine example before](~/user-guide/images/quarantine_example_existing.png)

If a third booking is added as configured below, there would not be enough capacity on *Resource A* to support this booking. If the addition of *Booking three* is forced anyway, the ResourceManager would resolve the conflict as follows: 

![Quarantine example result](~/user-guide/images/quarantine_example_result.png)

In the diagram above *Booking two* was moved to quarantine, because it has the lowest priority (see [Quarantine priority](#quarantine-priority)). *Resource A* is still partially assigned to *Booking two*, only the capacity necessary to resolve the conflict has been moved to quarantine. Since *Resource A* has a capacity of 10, only 1 capacity needed to be moved.


## General quarantine concepts

### Quarantine priority

When the ResourceManager detects some usages will need to be quarantined in order to resolve a conflict, it will remove usages from bookings according to a set priority. The priority of a booking is determined as follows: 

1. **Quarantined bookings** \
Bookings that are already in quarantine have the lowest priority and will be the first to have their resource usages removed.

1. **Bookings with ``HasAbsoluteQuarantinePriority`` flag**\
Bookings with the ``HasAbsoluteQuarantinePriority`` flag set have the highest priority, unless they are already in quarantine. The usages of these bookings will be moved last when resource usages need to be moved to resolve scheduling conflicts.

1. **Bookings with the ``Pending`` Status**\
Bookings that are in a ``Pending`` status have a lower priority and will have their resource usages removed before other non-quarantined bookings.

1. **Start Time**\
Among bookings with similar statuses, those with a later start time will have a lower priority.

1. **Alphabetical Order**\
If bookings have the same status, start time, and priority, a deterministic resolution is achieved through an alphabetical comparison of booking names. Bookings with names that come later alphabetically will have a lower priority.


> [!NOTE]
> 
> 1. The booking that is being created or added is also considered for quarantining. 
> 1. Bookings that are already ongoing can also be moved to quarantine. 


## Handling quarantine on booking updates

When an add or update of a booking would cause bookings to go to quarantine, errors will be in the ``TraceData`` indicating quarantine is needed to solve conflicts. The bookings will only be saved if the ``forceQuarantine`` parameter is set to true.

The error in the ``TraceData`` will be of type ``ReservationUpdateCausedReservationsToGoToQuarantine``, and the property ``MustBeMovedToQuarantine`` will contain all bookings and their usages that must be moved to quarantine in order to solve the scheduling conflict. The bookings that will be moved to quarantine will be selecting according to their priority (see [Quarantine priority](#quarantine-priority)).

If the ``forceQuarantine`` flag is passed, no error will be returned, instead a warning of type ``ReservationInstancesMovedToQuarantine`` will be present in the ``TraceData``, and the ``SubjectIds`` property of the warning will contain the IDs of the bookings that were moved to quarantine.

The below code snippet shows an example on how this error in the ``TraceData`` can be used to retrieve information about the scheduling conflict.

```csharp
// Create a new ResourceManagerHelper
var helper = new ResourceManagerHelper(engine.SendSLNetSingleResponseMessage);

// Save a 'ReservationInstance' without forcing quarantine
helper.AddOrUpdateReservationInstances(forceQuarantine: false, reservation);

var traceData = helper.GetTraceDataLastCall();
var errors = traceData.GetErrorDataOfType<ResourceManagerErrorData>();

foreach (var error in errors)
{
    if (error.ErrorReason != ResourceManagerErrorData.Reason.ReservationUpdateCausedReservationsToGoToQuarantine)
    {
        // For the sake of example we only handle the quarantine error here, but if there is a different error
        // the script should of course not ignore it but handle it appropriately.
        continue;
    }

    var errorBuilder = new StringBuilder("Scheduling conflict. The following bookings need to be moved to quarantine:").AppendLine();

    // The bookings that will be moved to quarantine to resolve the conflict are in the 'MustBeMovedToQuarantine' property
    foreach (var toQuarantine in error.MustBeMovedToQuarantine)
    {
        var booking = toQuarantine.ReservationInstance;
        errorBuilder.AppendLine($"{booking.Name} ({booking.ID}):");

        foreach(var quarantinedUsage in toQuarantine.QuarantinedUsages)
        {
            var resourceUsage = quarantinedUsage.QuarantinedResourceUsage;
            errorBuilder.AppendLine($"\tresource with ID '{resourceUsage.GUID}' will be quarantined because:");
                
            // The 'QuarantineTriggers' contains information about why this usage was moved to quarantine
            foreach (var trigger in quarantinedUsage.QuarantineTriggers)
            {
                errorBuilder.Append($"\t\t{trigger.QuarantineReason}");
                errorBuilder.AppendLine();
            }
        }
    }

    // Example value of 'errorBuilder.ToString()':
    // Scheduling conflict. The following bookings need to be moved to quarantine::
    //     Test Booking 1 (54add931-66fc-44f5-a76e-95ad0317f6af):
    // 	       resource with ID 'a250cffb-7054-4704-aa58-96200b0c49b3' will be quarantined because:
    // 		       ReservationInstanceUpdated
}
```

When saving with the ``forceQuarantine`` flag set tot ``true``, there will be warnings about the bookings that were automatically moved to quarantine.

```csharp
// Save a 'ReservationInstance' and force quarantine
helper.AddOrUpdateReservationInstances(forceQuarantine: true, reservation);

var traceData = helper.GetTraceDataLastCall();

// When forcing quarantine the call should succeed even if there are conflicts.
// If the traceData does not indicate the call succeeded the error must be handled.
if (!traceData.HasSucceeded())
{
    // The script should handle the error here, but in this example we will just return.
    return;
}

foreach (var warning in traceData.WarningData)
{
    if (!(warning is ResourceManagerWarningData resourceManagerWarning) || 
        resourceManagerWarning.WarningReason != ResourceManagerWarningData.Reason.ReservationInstancesMovedToQuarantine)
    {
        // For the sake of example we only handle the quarantine warning here, but if there is a different warning
        // the script should of course not ignore it but handle it appropriately.
        continue;
    }

    var bookingIds = string.Join(", ", resourceManagerWarning.SubjectIds);
    var warningString = "The following bookings were moved to quarantine: {bookingIds}";
    
    // Example value of 'warningString': 
    // The following bookings were moved to quarantine: 54add931-66fc-44f5-a76e-95ad0317f6af, 69958b9b-5704-4532-bb08-b021c5437084
}
```

## Handling quarantine on resource updates

Quarantine on resource updates works almost the same as quarantine on booking updates. Similar as for booking updates, bookings will only be moved to quarantine if the ``forceQuarantine`` flag is passed.

The following updates to resources can trigger quarantine:

1. Decreasing the ``MaxConcurrency`` of a resource.
2. Changing the mode of a resource to ``Maintenance``, this will move all bookings using that resource to quarantine.
3. Deleting a capacity or capability. All reservations using the deleted capacity/capability of this resource will be moved to quarantine.
4. Decreasing a maximum capacity in way that existing bookings are no longer supported.
5. Changing or removing a capability in a way that currently booked values are no longer supported.

> [!NOTE]
> Deletion of a resource will not trigger quarantine, but will always be blocked if the resource is in use by a future or ongoing booking.

If a quarantine conflict arises when a resource is updated and the call is not forced, the returned error in the ``TraceData`` will be of type ``ResourceUpdateCausedReservationsToGoToQuarantine``.

```csharp
// Create a new ResourceManagerHelper
var helper = new ResourceManagerHelper(engine.SendSLNetSingleResponseMessage);
helper.AddOrUpdateResources(forceQuarantine: false, resource);

var traceData = helper.GetTraceDataLastCall();
var errors = traceData.GetErrorDataOfType<ResourceManagerErrorData>();

foreach (var error in errors)
{
    if (error.ErrorReason != ResourceManagerErrorData.Reason.ResourceUpdateCausedReservationsToGoToQuarantine)
    {
        // For the sake of example we only handle the quarantine error here, but if there is a different error
        // the script should of course not ignore it but handle it appropriately.
        continue;
    }

    var conflictInformation = error.ConflictInformation;
    var errorBuilder = new StringBuilder($"Scheduling conflict. The following bookings need to be moved to quarantine:").AppendLine();

    // The bookings that will be moved to quarantine are in the 'ConflictingUsages' property
    foreach (var toQuarantine in conflictInformation.ConflictingUsages)
    {
        var booking = toQuarantine.Instance;
        errorBuilder.AppendLine($"{booking.Name} ({booking.ID}):");

        var usageToQuarantine = toQuarantine.Usage;
        errorBuilder.AppendLine($"\tresource with ID '{usageToQuarantine.GUID}' will be quarantined because:");

        // The 'QuarantineTriggers' contains information about why this usage was moved to quarantine
        foreach (var trigger in toQuarantine.Triggers)
        {
            errorBuilder.Append($"\t\t{trigger.QuarantineReason}");
            errorBuilder.AppendLine();
        }
    }

    // Example value of 'errorBuilder.ToString()' when a booking is moved to quarantine because we decreased the 'MaxConcurrency' property of a resource:
    // Scheduling conflict. The following bookings need to be moved to quarantine::
    //     Test Booking 1 (54add931-66fc-44f5-a76e-95ad0317f6af):
    // 	       resource with ID 'a250cffb-7054-4704-aa58-96200b0c49b3' will be quarantined because:
    // 		       ConcurrencyDowngraded
}
```

Saving a resource with the ``forceQuarantine`` flag set to true will return a warning of type ``ReservationInstancesMovedToQuarantine`` in the ``TraceData``. [Handling quarantine on booking updates](#handling-quarantine-on-booking-updates) contains an example script showing how to retrieve that information.

## Quarantine on interrupted contributing bookings

On startup of the ResourceManager, the bookings in the database will be checked, to see if there are any bookings that should have started, stopped or have an event run while the ResourceManager was not running. Such bookings will be put in an ``Interrupted`` state. If a contributing booking is moved to an ``Interrupted`` state, the bookings making use of the corresponding contributing resource will be moved to a quarantined state. The ``QuarantineTrigger`` will have value ``ContributingResourceNotAvailable`` for the ``QuarantineReason`` field in that case.

## Overview of possible ``QuarantineReason`` values

The script examples above show how the quarantine related errors in the ``TraceData`` can be used to retrieve information about the scheduling conflict. Each quarantined ``ResourceUsageDefinition`` will have a ``QuarantineTrigger`` with a ``QuarantineReason`` to keep track of why a usage was moved to quarantine. Below table contains the possible values for the ``QuarantineReason`` field:

|``QuarantineReason``   | Used when  |
|---|---|
| CapacityDeleted  | A capacity was completely removed from a resource. |
| CapabilityDeleted  | A capability was completely removed from a resource. |
| CapacityDowngraded  | A capacity was downgraded on a resource, meaning the maximum capacity value was lowered. |
| CapabilityDowngraded  | A capability was downgraded on a resource. This could be a rangepoint capability where the min-max range was narrowed, or a discrete capability where a discrete value was removed.  |
| ConcurrencyDowngraded  | The maximum concurrency of a resource was lowered.  |
| MovedToMaintenance  | The resource was moved to the *Maintenance* status. |
| ReservationInstanceUpdated  | A ``ReservationInstance`` was added or updated and caused a scheduling conflict. |
| ContributingResourceNotAvailable  | A contributing resource is not available. This can happen when contributing bookings are interrupted, or when trying to assign an unavailable contributing resource to a booking. |


## Moving bookings out of the quarantine state.

> [!NOTE]
> The SRM framework provides a feature to recover bookings from a quarantined state. By default this will trigger the *SRM_LeaveQuarantineState* script,
> but this can be customized: see [using custom scripts](xref:SRM_custom_scripts#configuring-the-booking-manager-app-to-use-custom-scripts)

To resolve the quarantined state, the quarantined usages on the booking can be inspected, and they can either be restored or a new resource can be assigned.
The script example below will show how to restore resources that were put in quarantine. This approach will only work if the bookings that caused the conflict have been updated so the resources are available again for the quarantined booking.

```csharp
var helper = new ResourceManagerHelper(engine.SendSLNetSingleResponseMessage);

// All bookings in the quarantined state can be retrieved with a filter.
// An extra filter is added here to only retrieve quarantined bookings that need to start in the next 7 days.
var filter = ReservationInstanceExposers.IsQuarantined.Equal(true)
                                        .AND(ReservationInstanceExposers.End.GreaterThan(DateTime.UtcNow))
                                        .AND(ReservationInstanceExposers.Start.LessThan(DateTime.UtcNow.AddDays(7)));
var quarantinedBookings = helper.GetReservationInstances(filter);

foreach (var booking in quarantinedBookings)
{
    // Create a dictionary of the usages that still exist on the booking and their quarantine reference.
    var existingUsagesWithQuarantineReference = booking.ResourcesInReservationInstance
                                                       .Where(r => r.QuarantineReference != Guid.Empty)
                                                       .ToDictionary(r => r.QuarantineReference);
    
    foreach (var quarantinedResource in booking.QuarantinedResources)
    {
        var quarantinedUsageDefinition = quarantinedResource.QuarantinedResourceUsage;

        // The quarantinedResource contains a list of triggers which keep track of when and why a usage was moved to quarantine.
        // The script will log these for the sake of example.
        var logBuilder = new StringBuilder();
        logBuilder.AppendLine($"Resource with ID '{quarantinedUsageDefinition.GUID}' was moved to quarantine for the following reasons:");
        foreach (var oneTrigger in quarantinedResource.QuarantineTriggers)
        {
            logBuilder.AppendLine($"\tat {oneTrigger.CreatedAt:dd/mm/yyyy HH:mm.ss} because {oneTrigger}");
        }

        // Example value of 'logBuilder.ToString()':
        // Resource with ID 'dda81819-58a2-4f52-8812-8ac823f2842d' was moved to quarantine for the following reasons:
        //     at 26/09/2024 08:09.26 because ReservationInstanceUpdated: b0c1522d-de1d-4597-b48e-b6f0279135ed

        if (existingUsagesWithQuarantineReference.TryGetValue(quarantinedUsageDefinition.QuarantineReference, out var existingUsage))
        {
            // This quarantined usage was split off and some usage is still assigned to the booking.
            // This usually happens when there is a capacity overflow and some capacity is still assigned to the resource.
            
            // Merge the existing usage with the old usage to restore the resource usage.
            // If the goal of the script is to assign a completely new resource to resolve the quarantine state, the 'existingUsage'
            // should be removed from the 'ResourcesInReservationInstance' collection.
            if (quarantinedUsageDefinition.RequiredCapabilities.Count > 0)
            {
                existingUsage.RequiredCapabilities.AddRange(quarantinedUsageDefinition.RequiredCapabilities);
            }

            foreach (var requiredCapacity in quarantinedUsageDefinition.RequiredCapacities)
            {
                var currentCapacity = existingUsage.RequiredCapacities.SingleOrDefault(x => x.CapacityProfileID == requiredCapacity.CapacityProfileID);
                if (currentCapacity != null)
                {
                    currentCapacity.DecimalQuantity += requiredCapacity.DecimalQuantity;
                }
                else
                {
                    existingUsage.RequiredCapacities.Add(requiredCapacity);
                }
            }
            existingUsage.QuarantineReference = Guid.Empty;
        }
        else
        {
            // The entire usage is in quarantine, nothing is assigned to the booking anymore for this resource.
            quarantinedResource.QuarantinedResourceUsage.QuarantineReference = Guid.Empty;
            // Re-assign the old resource usage
            booking.ResourcesInReservationInstance.Add(quarantinedResource.QuarantinedResourceUsage);
        }
    }

    booking.QuarantinedResources.Clear();

    // 'FindBookingManager' and 'RemoveFromQuarantine' is an extension method provided by the SRM framework
    var bookingManager = booking.FindBookingManager();
    helper.RemoveFromQuarantine(booking, bookingManager);
}
```

In order to select a new resource, some code will need to be written to select this new resource according to some criteria. Below is a simple example script that shows how to select a new resource based of the result of a ``GetEligibleResources`` call:

```csharp
...
var contexts = new List<EligibleResourceContext>();
var contextIdsToUsages = new Dictionary<Guid, ResourceUsageDefinition>();

foreach (var booking in quarantinedBookings)
{
    // Create a dictionary of the usages that still exist on the booking and their quarantine reference.
    var existingUsagesWithQuarantineReference = booking.ResourcesInReservationInstance
                                                       .Where(r => r.QuarantineReference != Guid.Empty)
                                                       .ToDictionary(r => r.QuarantineReference);

    foreach (var quarantinedResource in booking.QuarantinedResources)
    {
        ResourceUsageDefinition usage = null;

        // If there is still an existing usage we need to merge the required capacities and capabilities
        if (existingUsagesWithQuarantineReference.TryGetValue(usage.QuarantineReference, out var stillBooked))
        {
            usage = stillBooked;
            var quarantinedUsage = quarantinedResource.QuarantinedResourceUsage;
            foreach (var quarantinedCapacity in quarantinedUsage.RequiredCapacities)
            {
                var alreadyInUsage = usage.RequiredCapacities.FirstOrDefault(r => r.CapacityProfileID == quarantinedCapacity.CapacityProfileID);
                if (alreadyInUsage != null)
                {
                    alreadyInUsage.DecimalQuantity += quarantinedCapacity.DecimalQuantity;
                }
                else
                {
                    usage.RequiredCapacities.Add(quarantinedCapacity);
                }
            }
            foreach (var quarantinedCapability in quarantinedUsage.RequiredCapabilities)
            {
                // Capabilities are moved completely so they can copied over
                usage.RequiredCapabilities.Add(quarantinedCapability);
            }
        }
        else 
        {
            usage = quarantinedResource.QuarantinedResourceUsage;
        }
        
        // This will get all resources that are available with the capacities and capabilities that were
        // originally required.
        var context = new EligibleResourceContext(booking.TimeRange)
        {
            RequiredCapacities = usage.RequiredCapacities,
            RequiredCapabilities = usage.RequiredCapabilities
        };
        
        contextIdsToUsages[context.ContextId] = usage;

        // If only resources that match a certain filter should be considered this extra filter can be added to the context.
        // For example to only consider resources that are part of a certain pool:
        // var poolId = resourcePool.ID;
        // context.ResourceFilter = ResourceExposers.PoolGUIDs.Contains(poolId);

        contexts.Add(context);
    }

    var results = helper.GetEligibleResources(contexts);
    var usages = new List<ResourceUsageDefinition>();

    string error = "";
    foreach (var eligibleResourceResult in results)
    {
        if (eligibleResourceResult.EligibleResources.Count == 0)
        {
            var context = contexts.First(c => c.ContextId == eligibleResourceResult.ForContextId);
            error += $"Could not find a resource with filter: {context}{Environment.NewLine}";
            continue;
        }
        
        // Overwrite the resource on the usage with the first eligible resource.
        var usage = contextIdsToUsages[eligibleResourceResult.ForContextId];
        usage.GUID = eligibleResourceResult.EligibleResources[0].ID;
        usages.Add(usage);
    }

    if (error != string.Empty)
    {
        // The error should of course be handled but this example script will just return.
        return;
    }

    booking.ResourcesInReservationInstance.RemoveAll(r => r.QuarantineReference != Guid.Empty);
    foreach (var usage in usages)
    {
        usage.QuarantineReference = Guid.Empty;
        booking.ResourcesInReservationInstance.Add(usage);
    }
    booking.QuarantinedResources.Clear();    

    // 'FindBookingManager' and 'RemoveFromQuarantine' is an extension method provided by the SRM framework
    var bookingManager = booking.FindBookingManager();
    helper.RemoveFromQuarantine(booking, bookingManager);
}
```
