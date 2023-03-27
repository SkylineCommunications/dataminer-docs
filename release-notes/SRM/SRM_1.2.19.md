---
uid: SRM_1.2.19
---

# SRM 1.2.19

## New features

#### Empty service definition management \[ID_30144\]

A new *Empty Service Definition Name* parameter is now available on the *General* data page of the Booking Manager, which determines the name of the service definition that will be used to make resource-based bookings. If the virtual platform is updated, the selected service definition will be updated accordingly.

The service definition will include the events STANDBY, START, PAUSE and STOP. For each event that occurs on a booking using the service definition, a script will be triggered that goes over all resources and initiates the Profile Load script in accordance with the type of event.

#### Support for bookings with unmapped function resource, virtual function or contributing resource \[ID_30150\]

It is now possible to assign a function resource, virtual function or contributing resource that is not linked to a node of the service definition. The same resource can only be included as an unmapped resource once in the same booking.

#### Duplicating/saving bookings now supported with unmapped resources \[ID_30174\]

It is now possible to duplicate and save bookings with unmapped resources. These are resources that are not linked to any node of the configured service definition.

#### New script to apply profile to resource without creating booking \[ID_30227\]

A new script, *SRM_ApplyProfileToResource*, is now available. This script allows you to apply a profile configuration to a resource without creating a booking. The script requires a single resource ID as its input.

The script allows you to select the full configuration for the resource. You can select a profile for the resource as well as for the interfaces. You can apply a state transition by selecting a profile instance that has state profiles configured, selecting the *State Transition* checkbox, and selecting the corresponding state in a drop-down box. To combine profiles and state profile data, you should select the *Full Config* checkbox, which only becomes available if *State Transition* is selected.

When a configuration is applied, this can affect existing bookings. The script will therefore first display a window with the ongoing bookings before you can confirm the configuration change.

#### Support for applying profile to unmapped resource \[ID_30228\]

You can now apply a profile to a resource that is assigned to a booking without being mapped. In the LSO script, you can select the unmapped resource and then apply a profile instance or state profile instance, or both. A new method is available to support this.

Because of this change, some data (related to the node, booking and service) used in the SRM Resource Configuration Info in the Profile Load script has become optional.

#### New script to create/edit booking with unmapped resources \[ID_30275\]

A new script, *SRM_ResourceManagement*, is now available. This script facilitates the creation/editing of bookings with unmapped resources (i.e. resources that are not mapped to a service definition node).

#### Possibility to configure resources of running booking \[ID_30306\]

The *SRM_ResourceManagement* script has been extended so that you can now edit a running booking to add, remove, replace or configure its resources. When you click the button to configure a resource, a window is displayed with information about the profile instance selected for the resource. You can then select a target service state and select to force the full configuration (i.e. the profile instance and target service state configuration).

However, note that any pending changes must be saved before you can configure resources.

#### Support for unmapped resources in silent booking creation \[ID_30324\]

Silent booking creation now supports unmapped resources, i.e. resources that are not linked to a node of a service definition. For this purpose, it is now possible to pass no service definition to the booking creation script. Note that the same resource cannot be included twice in the request.

Alternatively, it is possible to pass a normal service definition, and add unmapped resources to the Function array (i.e. resources without a specified ID).

#### New SRM_ApplyProfileToUnmappedResourceSilent script \[ID_30705\]

A new script, *SRM_ApplyProfileToUnmappedResourceSilent*, has been added, which makes it possible to silently apply a profile to an unmapped resource of a booking. It can apply the base profile, the service state, or both.

However, applying the profile is only possible when the booking is in the *Service Pre-Roll*, *Service Active* or *Service Post-Roll* state. Applying the *FAILED* service state or a state that is not supported by SRM is not possible.

#### Support for adding any type of resource to a booking \[ID_30735\]

It is now possible to add any type of resource to a booking using the *AssignResources* method. For resources without a function, the profile instances and overridden parameters will be discarded.

#### Selection of unmapped resources based on function or pool during booking creation \[ID_30902\]

When you create a booking with unmapped resources (i.e. resources that are not mapped to a service definition node), a *selection type* drop-down box is now available, which allows you to indicate whether you want to select a resource based on a function or based on a pool.

If you select *Function* in the drop-down box, you will then be able to select the function and the profile instance for the function and interfaces. Finally, the selectable resources will be filtered based on the capacities and capabilities of the selected profile instance(s).

If you select *Pool*, you can then select the pool and select a resource from this pool.

#### Logging improvements \[ID_31178\]

SRM debug logging no longer requires an element using the *Generic Bookings Log* connector. Instead it will use the Serilog library. This will improve performance. The file name convention and structure of the log files remains unchanged.

The *Booking Orchestration Logging* parameters of the Booking Manager have been renamed to *Booking Logging* parameters, and both orchestration logging and debug logging can now be configured with these. A new *Booking Logging Date Time Format* parameter has also been added, which allows you to configure the date and time format for the debug logging.

#### Transport workflow now supports lite contributing resources \[ID_31227\]

Lite contributing resources are now also supported for a transport (Dijkstra) workflow.

For this purpose, in the *ContributingConfig* element of the *Path* parameter configuration, add *"LiteContributingResource": true*. For example:

```json
{
    "Link": "PATH",
    "Paths": [{
            "Name": "Route",
            "ResourcePoolForLinks": "SDMN.SAT.Transport",
            "Algorithm": "Dijkstra",
            "LinkPoolOptions": 0,
            "NrOfSuggestions": 10,
            "PathSelectionMode": "Manual",
            "Source": {
                "Link": "RESOURCE",
                "Function": "Demodulating",
                "Property": "Connected Resource"
            },
            "Destination": {
                "Link": "RESOURCE",
                "Function": "Decoding",
                "Property": "Connected Resource"
            },
            "ContributingConfig": {
                "PreRoll": 0,
                "PostRoll": 0,
                "LifeCycle": "Locked",
                "ReservationType": "FollowMain",
                "Concurrency": 1,
                "VisioFileName": "SRM_DefaultTransportService.vsdx",
                "Script": "Script:SRM_DummyScriptMultipleParameters||DummyParameterName=123456;DummyParameterName1=[RESERVATIONID]",
                "LiteContributingResource": true
            }
        }
    ]
}
```

## Changes

### Enhancements

#### Default name empty service definition modified \[ID_30519\]

The name of an empty service definition has been changed from "\<Virtual platform name>.Default Empty Service Definition" to "\<Virtual platform name>.Default".

#### SRM_ApplyProfileToResource and SRM_ResourceManagement scripts updated to have only one input parameter \[ID_30912\]

The *SRM_ApplyProfileToResource* and *SRM_ResourceManagement* scripts now support only one input parameter, which should contain all previous parameters in a single JSON-formatted string. This will make these scripts more resilient to future changes

#### Dedicated default service definition per Booking Manager instance \[ID_30960\]

Every Booking Manager instance will now have a dedicated default service definition (i.e. a service definition without nodes).

#### Improved debug logging for booking actions \[ID_31066\]

The debug logging of the script *SRM_ReservationAction* has been improved, so that it will be easier to understand what happened in case something goes wrong with a booking action.

#### Improved logging for SRM scripts \[ID_31083\]

The logging for several SRM scripts has been improved:

- For *SRM_BookingStartFailureTemplate*, debug and orchestration logging are now included.
- For *SRM_HandleBookingStartFailure*, whenever a failure occurs at the start of a booking, orchestration logging will be included with critical severity.

#### Time-dependent capabilities for new silent bookings \[ID_31136\]

Time-dependent capabilities are now supported for bookings created using the latest, faster silent booking mechanism.

#### Improved logging in case of incomplete configuration in Booking Wizard \[ID_31183\]

Logging has been improved in case a configuration is incomplete in the Booking Wizard. A log entry and information event will now be added in case something is missing. This is verified in steps, so that only one error appears at a time, and possibly a new error can be shown in case a previous error is resolved.

#### SRM_CustomContributingReservation obsolete \[ID_31188\]

The script *SRM_CustomContributingReservation*, which was previously used to create a contributing booking when assigning profiles and resources to a new booking in the Booking Wizard, is now obsolete and will no longer be included in the SRM package.

#### Contributing booking ID added in ContributingReservationId property of contributing resource \[ID_31241\]

When a contributing booking is created, the *ContributingReservationId* property of the contributing resource will now be updated with the ID of the contributing booking.

#### Booking Wizard now shows discrete display values of profile parameters \[ID_31295\]

For profile parameters with discrete values, the display values will now be shown in the Booking Wizard instead of the raw values.

#### New ApplyContributingProfile method \[ID_31301\]

A new method, *ApplyContributingProfile*, has been added to *SrmResourceConfiguration* class. It can be used to execute the Profile Load script for a given contributing booking by passing the initial parameter values defined at booking creation to the Profile Load script executed for a contributing booking.

#### Methods to add resources no longer create new service definition if suitable service definition is available \[ID_31396\]

When the *BookingManager.AddResource* or *BookingManager.TryAddResource* method was used, up to now, a new service definition was created whenever the service definition that was being used could not support the new resource. Now the SRM framework will instead check if a compatible service definition is already available in the system.

### Fixes

#### Service Profiles Wizard did not use transferred booking data to filter resources when reusing contributing resource \[ID_31115\]

When contributing resources were reused in the Service Profiles Wizard, only the profile instance was taken into account to filter resources, instead of the transferred booking data.

#### Transport resources assigned to main booking \[ID_31126\]

When no contributing transport booking was available, it could occur that transport resources were assigned to the main booking and the path info was added in a property of the main booking.

#### Transport path not filled in when editing booking \[ID_31168\]

When a booking that had a transport path assigned was edited in the Booking Wizard, it could occur that the selected path was not filled in, which meant that the user would have to select it again to be able to edit the booking.

#### Booking Wizard: Resource selected automatically for transport node \[ID_31175\]

When a new booking was created, it could occur that the Booking Wizard automatically assigned a resource to a transport node, while this should not happen.

#### SRM_ExposedResourceState capability not updated when contributing booking was edited to leave quarantine \[ID_31268\]

When a contributing booking was edited so that it could leave the quarantine state, it could occur that the *SRM_ExposedResourceState* capability of the corresponding contributing resource was not updated, so that the main booking could not leave the quarantine.

#### Fast booking creation failed when service definition combined DTR and resource pool inheritance \[ID_31269\]

When data transfer rules (DTR) and resource pool inheritance were used in the same service definition, it could occur that it was not possible to create a fast booking using that service definition.

#### Profile instance with null values caused failure of resource assignment \[ID_31278\]

When a profile instance with null values was provided, it could occur that assigning resources to a booking failed.

#### Incorrect exception when silent booking was created with incorrect permanent booking settings \[ID_31288\]

When a booking was created silently with the *PermanentBookings* setting disabled but with *Recurrence.PermanentService* set to "true" and without an end date, this would cause the Booking creation to fail and an incorrect exception to be thrown:

```txt
EndDate cannot be lower than the current date.
```

#### Post-roll offset of contributing booking not adjusted when booking was extended during post-roll \[ID_31337\]

When a booking containing a locked contributing resource was extended during the post-roll phase, the post-roll offset of the contributing booking remained as it was. Now the post-roll duration will be extended instead.

#### Not possible to create booking with null user when Booking Locking was disabled \[ID_31348\]

When *Booking Locking* was disabled, it could occur that it was not possible to create a booking from a script if *engine.UserDisplayName* was null.
