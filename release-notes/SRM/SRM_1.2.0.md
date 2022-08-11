---
uid: SRM_1.2.0
---

# SRM 1.2.0

## New features

#### New action to set interrupted booking to 'Confirmed' \[ID_24301\]

A new action is now possible with the *SRM_ReservationActions* script, both in interactive and in silent mode, which can be used to set an interrupted booking to *Confirmed*. A booking can be in the *Interrupted* state when it does not start because of unexpected circumstances, for example because the system is down at the moment when the booking is supposed to start. The new action will update the interrupted booking so that the start date is set to a future date.

The *BookingManager* class now also contains direct methods to allow the action to be invoked, such as:

- `bool TryLeaveFromInterruptedState(ref ReservationInstance *reservation*, out string *errorMessage*);`

- `ReservationInstance LeaveFromInterruptedState(ReservationInstance *reservation*);`

#### New Skyline Booking Manager driver branch without Booking Overview table \[ID_24612\]

The Booking Manager driver has been updated to branch 2.0.2.x. This new branch features the possibility to not include the active and history bookings tables in order to improve performance.

All SRM scripts have also been updated to a new branch. To improve performance, the scripts will no longer do parameter sets on the Skyline Booking Manager element.

#### New ExposedInterfaceId property to map interfaces of contributing service to parent service \[ID_24679\]

A new property, *ExposedInterfaceId*, can now be defined on an interface of the service definition of a contributing service in order to map this interface to a parent service interface.

For this purpose, the service definition for contributing service must be defined as follows:

- The service definition must have the same input and output interfaces as the service definition of the parent service.
- On each interface that is to be mapped to a parent service interface, the following properties must be configured.

  - *ExposedInterfaceId*: Must be set to the ID of the interface in the parent service definition.
  - *NoConnectivityCheck*: Must be set to true so that this interface is loaded.

- The interfaces must be exposed and unconnected.

## Changes

### Enhancements

#### SRM_CustomContributingReservation script updated \[ID_24570\]

The script *SRM_CustomContributingReservation* has been updated so that it no longer creates a custom service definition.

#### SRM_AssignProfilesAndResourcesToCustomServiceDefinition script enhanced \[ID_24615\]

The *SRM_AssignProfilesAndResourcesToCustomServiceDefinition* script has been adjusted so that when the contributing resources of an ongoing contributing booking are assigned to a parent booking, the contributing booking will not be set to "Confirmed" again.

#### Contributing booking enhanced service within main booking service \[ID_24638\]

The Booking Manager can now be configured to include an enhanced service for a contributing booking within the service for the main booking. If this feature is not enabled, the main booking will only include resource elements. By default, it is enabled.

#### Silent booking creation without resources \[ID_24656\]

A new *AutoSelection* property is now available in the class *Skyline.DataMiner.Library.Solutions.SRM.Model.ExtendedFunction*. This property can be used to silently create a new booking without assigning any resources to it.

By default, this property is set to true, but if it is set to false, resources will not be automatically selected for a function. This behavior is the same regardless of whether nodes are optional or mandatory.

Note that automatic selection does not occur if a valid resource has been selected for a function.

#### ApplyProfileScript property behavior enhanced \[ID_24660\]

If the *ApplyProfileScript* property has been configured on a node, but the specified script is not available, now no script will be triggered and an exception will be thrown. If this property is empty or missing, no script will be triggered and no exception will be thrown.

If the property value starts with "{", the SRM engine will attempt to parse the value as a JSON structure according to the class *Skyline.DataMiner.Library.Solutions.SRM.Model.ApplySettings*. The property should be configured as follows:

```json
{"ScriptName":"Dummy_Script", "ExtraParameters":{"Param1":"Value1","Param2":"Value2, (...) , "ParamN":"ValueN"}}
```

In the configuration above, *ExtraParameters*, represents the input parameters of the script. If *ScriptName* is not found or the parameters do not match the input parameters, an exception will be thrown.

### Fixes

#### HideFromWizard property ignored when booking was created silently \[ID_24576\]

When a new booking was created silently, it could occur that the *HideFromWizard* property of a service definition was ignored.

#### Null exception when retrieving service definitions \[ID_24585\]

In some cases, a null exception could be returned when the service definitions were retrieved.

#### Contributing service not created in correct view \[ID_24619\]

When a contributing booking was created, it could occur that the corresponding contributing service was not included in the correct view.

#### Silent booking creation not possible with node option 'Hide' \[ID_24687\]

If a service definition contained a node with the property *Options* set to *Hide*, it could occur that it was not possible to create a booking with this service definition in silent mode.

#### ShowNotConfiguredParameters property not applied correctly in Booking Wizard \[ID_24724\]

In some cases, it could occur that parameters were shown in the Booking Wizard while they were not configured, even if the property *ShowNotConfiguredParameters* was not set to true on the corresponding node. In addition, it could occur that a parameter without value was not shown, even though this property was set to true.

#### Resources drop-down list not generated correctly in Booking Wizard \[ID_24837\]

In the Booking Wizard, it could occur that the resources drop-down list was not generated correctly. This could make it possible for users to select an unavailable resource, which would cause the booking to be quarantined.

#### Incorrect booking color when booking was converted to contributing booking \[ID_24839\]

In some cases, when a booking was converted to a contributing booking, it could occur that it did not get the correct color in the Booking Manager.

#### Not possible to assign capability to function with only input or output interfaces \[ID_24863\]

If a function only had interfaces of one type (i.e. only input or only output), it could occur that it was not possible to assign a capability to the function.
