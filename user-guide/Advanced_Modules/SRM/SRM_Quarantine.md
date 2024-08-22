---
uid: SRM_Quarantine
---

# Quarantine

## What is the quarantine state?

The quarantine state is a special state of a booking, that indicates the booking cannot start because one or more resources that were assigned are no longer available. Bookings are automatically moved to this state when the ResourceManager detects such a situation. Usually this is because overlapping bookings using the same resource are added or modified and the resource does not have enough capacity or concurrency to support all bookings.

Bookings that are in a quarantine state will have the ``IsQuarantined`` flag set to true, and will have the status set to ``Pending``. These bookings will still reserve the non-quarantined resources, the same way they would if they were in a regular ``Pending`` state. The resources that are no longer available are still present on the booking in the ``QuarantinedResources`` collection, along with some information about why these resources were moved to quarantine.

## Practical example

Consider a system that has two existing bookings in the confirmed state, each using a resource *Resource one*. *Resource one* has a capacity defined, with a maximum bookable value of 10.

![Quarantine example before](~/user-guide/images/quarantine_example_existing.png)

If a third booking is added as configured below, there would not be enough capacity on *Resource one* to support this booking. If the addition of *Booking three* is forced anyway, the ResourceManager would resolve the conflict as follows: 

![Quarantine example result](~/user-guide/images/quarantine_example_result.png)

In the diagram above *Booking two* was moved to quarantine, because it has the lowest priority (see [Quarantine priority](#quarantine-priority)). *Resource one* is still partially assigned to *Booking two*, only the capacity necessary to resolve the conflict has been moved to quarantine. Since *Resource one* has a capacity of 10, only 1 capacity needed to be moved.

## Handling quarantine on booking updates

When an add or update of a booking would cause bookings to go to quarantine, errors will be in the ``TraceData`` indicating quarantine is needed to solve conflicts. The bookings will only be saved if the ``forceQuarantine`` parameter is set to true.

The error in the ``TraceData`` will be of type ``ReservationUpdateCausedReservationsToGoToQuarantine``, and the property ``MustBeMovedToQuarantine`` will contain all bookings and their usages that must be moved to quarantine in order to solve the scheduling conflict. The bookings that will be moved to quarantine will be selecting according to their priority (see [Quarantine priority](#quarantine-priority)).

If the ``forceQuarantine`` flag is passed, no error will be returned, instead a warning of type ``ReservationInstancesMovedToQuarantine`` will be present in the ``TraceData``, and the ``SubjectIds`` property of the warning will contain the IDs of the bookings that were moved to quarantine.

See below for an example on how to interpret the error in the ``TraceData`` when a booking add or update would cause quarantine.

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

    engine.GenerateInformation(errorBuilder.ToString());

    // Example output:
    // Scheduling conflict. The following bookings need to be moved to quarantine::
    //     Test Booking 1 (54add931-66fc-44f5-a76e-95ad0317f6af):
    // 	       resource with ID 'a250cffb-7054-4704-aa58-96200b0c49b3' will be quarantined because:
    // 		       ReservationInstanceUpdated
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

If a quarantine conflict arises when a resource is updated, the returned error in the ``TraceData`` will be of type ``ResourceUpdateCausedReservationsToGoToQuarantine``. 

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

    engine.GenerateInformation(errorBuilder.ToString());

    // Example output when a booking is moved to quarantine because we decreased the 'MaxConcurrency' property of a resource:
    // Scheduling conflict. The following bookings need to be moved to quarantine::
    //     Test Booking 1 (54add931-66fc-44f5-a76e-95ad0317f6af):
    // 	       resource with ID 'a250cffb-7054-4704-aa58-96200b0c49b3' will be quarantined because:
    // 		       ConcurrencyDowngraded
}
```

## Quarantine on interrupted contributing bookings

On startup of the ResourceManager, the bookings in the database will be checked, to see if there are any bookings that should have started, stopped or have an event run while the ResourceManager was not running. Such bookings will be put in an ``Interrupted`` state. If a contributing booking is moved to an ``Interrupted`` state, the bookings making use of the corresponding contributing resource will be moved to a quarantined state. The ``QuarantineTrigger`` will have value ``ContributingResourceNotAvailable`` for the ``QuarantineReason`` field in that case.

## General quarantine concepts

### Quarantine priority

When the ResourceManager detects some usages will need to be quarantined in order to resolve a conflict, it will remove usages from bookings according to a set priority. The priority of a booking is determined as follows: 

1. **Quarantined bookings** \
Bookings that are already in quarantine have the lowest priority and will be the first to have their resource usages removed.

1. **Bookings with ``HasAbsoluteQuarantinePriority`` flag**\
Bookings with the ``HasAbsoluteQuarantinePriority`` flag set have the highest priority, unless they are already in quarantine. These bookings will be considered last when resolving conflicts.

1. **Bookings with the ``Pending`` Status**\
Bookings that are in a ``Pending`` status have a lower priority and will have their resource usages removed before other non-quarantined bookings.

1. **Start Time**\
Among bookings with similar statuses, those with a later start time will have a lower priority.

1. **Alphabetical Order**\
If bookings have the same status, start time, and priority, a deterministic resolution is achieved through an alphabetical comparison of booking names. Bookings with names that come later alphabetically will have a lower priority.


> [!NOTE]
> 
> 1. The booking that is being created or added is also considered for quarantining. 
> 2. Bookings that are already ongoing can also be moved to quarantine. 


## Moving bookings out of the quarantine state.

> [!NOTE]
> The SRM solution provides a feature to recover bookings from a quarantined state. By default this will trigger the *SRM_LeaveQuarantineState* script,
> but this can be customized: see [using custom scripts](xref:SRM_custom_scripts#configuring-the-booking-manager-app-to-use-custom-scripts)

To resolve the quarantined state, the quarantined usages on the booking can be inspected, and they can either be restored or a new resource can be assigned.
The script example below will show how to restore resources that were put in quarantine. This approach will only work if the bookings that caused the conflict have been updated so the resources are available again for the quarantined booking.

```csharp
var helper = new ResourceManagerHelper(engine.SendSLNetSingleResponseMessage);

// All bookings in the quarantined state can be retrieved with a filter.
// We are only interested in quarantined bookings that end in the future here.
var filter = ReservationInstanceExposers.IsQuarantined.Equal(true)
                                        .AND(ReservationInstanceExposers.End.GreaterThan(DateTime.UtcNow));
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
        engine.GenerateInformation(logBuilder.ToString());

        if (existingUsagesWithQuarantineReference.TryGetValue(quarantinedUsageDefinition.QuarantineReference, out var existingUsage))
        {
            // This quarantined usage was split off and some usage is still assigned to the booking.
            // This usually happens when there is a capacity overflow and some capacity is still assigned to the resource
            
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
            // The entire usage is in quarantine, nothing is still assigned to the booking.

            quarantinedResource.QuarantinedResourceUsage.QuarantineReference = Guid.Empty;
            // Re-assign the old resource usage
            booking.ResourcesInReservationInstance.Add(quarantinedResource.QuarantinedResourceUsage);
        }
    }

    // Restore the quarantine properties to the default values
    booking.QuarantinedResources.Clear();
    booking.Status = ReservationStatus.Confirmed;
    booking.IsQuarantined = false;
    
    // Try to save the booking with the resources again.
    helper.AddOrUpdateReservationInstances(forceQuarantine: false, booking);
    var traceData = helper.GetTraceDataLastCall();
    if (!traceData.HasSucceeded())
    {
        // Handle error
    }
}
```
