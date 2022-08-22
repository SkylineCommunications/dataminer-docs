---
uid: SRM_1.2.4
---

# SRM 1.2.4

## New features

#### Booking start failure script \[ID_26018\]

It is now possible to specify a script that should be triggered in case the start actions for a booking instance fail. You can specify this script on the *General* data page of the Booking Manager element, using the new *Booking Start Failure Script* parameter.

An example script, *SRM_BookingStartFailureTemplate*, has also been added to the SRM Solution. You can use this script in order to create a booking start failure script that matches your own configuration.

#### New EXTEND booking action \[ID_26212\]

The *SRM_ReservationAction* script now has an EXTEND action that can be used to extend the booking by a specific period of time. This action can be used in silent mode, using the method *BookingManager.Extend(Engine engine, ReservationInstance reservation, ExtendBookingInputData data)*, or in the Booking Wizard, by specifying a period of time in the *Extend by* box.

#### Service definition node property to determine profile assignment mode \[ID_26322\]

The service definition node property *ByProfileInstanceReference* (dedicated field on each service definition node) now determines whether the *By Reference* checkbox is selected for profile assignment in the Booking Wizard.

## Changes

### Enhancements

#### Overload methods using interfaceId added to SrmResourceConfiguration class \[ID_26086\]

Overloads have been added for the *GetConnectedResources*, *GetParameter* and *SetParameter* methods of the *SrmResourceConfiguration* class, so that these can now take the *interfaceId* as input instead of the *interfaceName*.

#### New AssignResources method \[ID_26134\]

The following new method has been added to the *AssignResourceRequest* class:

```csharp
public static ServiceReservationInstance AssignResources(this ServiceReservationInstance reservation, Engine engine, bool forceQuarantine, params AssignResourceRequest[] requests);
```

It can be used to assign resources to a specific booking. It returns the requested booking and requires the following input parameters:

- *reservation*: The booking to which the resources should be assigned.
- *engine*: Link with SLScripting
- *forceQuarantine*: Indicates whether a quarantine should be forced when necessary.
- *requests*: The requests to assign resources.

Examples:

- Assigning multiple resources

    ```csharp
    var requests = new[]
    {
       new AssignResourceRequest
       {
          TargetNodeLabel = "Demodulating",
          NewResourceId = TestSystemObjects.ResourceIds.Demodulating.NMA_NS2000_01
       },
       new AssignResourceRequest
       {
          TargetNodeLabel = "Decoding",
          NewResourceId = TestSystemObjects.ResourceIds.Decoding.KFS_RX8200_07
       }
    };
    serviceReservation = serviceReservation.AssignResources(engine, true, requests);
    ```

- Removing an assigned resource:

    ```csharp
    var request = new AssignResourceRequest
    {
       TargetNodeLabel = "Decoding",
       NewResourceId = Guid.Empty
    };
    serviceReservation = serviceReservation.AssignResources(engine, true, request);
    ```

- Changing overridden parameters:

    ```csharp
    var request = new AssignResourceRequest
    {
       TargetNodeLabel = "Decoding",
       NewResourceId = Guid.Parse(functions[3].SelectedResource),
       ByReference = false
    };
    var param = new Parameter
    {
       Id = TestSystemObjects.ProfileParametersIds.Video_State,
       Value = RandomNumber.RandomString(10)
    };
    request.OverriddenParameters.Add(param);
    serviceReservation = serviceReservation.AssignResources(engine, true, request);
    ```

- Changing a profile instance:

    ```csharp
    var request = new AssignResourceRequest
    {
       TargetNodeLabel = "Demodulating",
       ProfileInstanceId = TestSystemObjects.ProfileInstancesIds.EUTELSAT_07A_A03_NS3,
       NewResourceId = Guid.Parse(functions[2].SelectedResource)
    };
    serviceReservation = serviceReservation.AssignResources(engine, request);
    ```

#### String capability filter support in SRM_AssignFilterToFunctionResources script \[ID_26142\]

The script *SRM_AssignFilterToFunctionResources* now supports filtering on string capability.

#### New methods to allow check sets option to be disabled for profile loading scripts \[ID_26236\]

Previously, when a script to load a profile was triggered, the option to check parameters or properties after these had been changed was always enabled. Because of this, if a parameter set failed, the script would end with the rest of the configuration unfinished.

The following methods have now been added to the class *SrmResourceConfiguration* to allow this option to be deactivated (with the *performCheckSets* boolean):

- SrmResourceConfiguration.ApplyContributingState(string *serviceState*, bool *performCheckSets*)
- SrmResourceConfiguration.ApplyProfile(string *profileAction*, bool *performCheckSets*)
- SrmResourceConfiguration.ApplyServiceActionProfile(string *serviceAction*, string *profileAction*, bool *performCheckSets*)

#### DTR scripts triggered when parameter is initialized \[ID_26363\]

Data transfer rule (DTR) scripts will now also be triggered when a parameter is initialized, instead of only when a parameter value changes.

### Fixes

#### Hidden resources not loaded when CreatedBookingAction script was executed \[ID_26052\]

In case hidden resources were assigned to a booking when it was confirmed, it could occur that these resources were not loaded when the *CreatedBookingAction* script was executed.

#### Exception when converting booking to contributing booking \[ID_26135\]

In some cases, when a booking was converted to a contributing booking, it could occur that the corresponding service received the same name as an existing service, which caused an exception to be thrown.

#### Resource incorrectly assigned to other nodes if node was set to no longer use resource \[ID_26315\]

If a node in the Booking Wizard was set to no longer use a resource, it could occur that the resource was automatically assigned to other nodes for the same function that had no resource assigned yet. This could even occur if concurrency for the resource was set to 1.

#### InputReference path configuration option not working properly \[ID_26380\]

In some cases, when the *InputReference* configuration option was used for a JSON Path parameter, it could occur that this did not work properly.

#### Incorrect end time of locked contributing booking when parent booking is finished \[ID_26424\]

When a booking containing a locked contributing booking and using a post-roll phase was finished, the end time for the contributing booking could be incorrect.

#### Problem when editing booking with parameter inherited from resource pool \[ID_26468\]

If a booking contained a parameter with resource pool inheritance, and the resource had a concurrency of 1, it could occur that the resource was considered to be not available when the booking was edited.
