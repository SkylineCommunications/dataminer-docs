---
uid: SRM_1.2.1
---

# SRM 1.2.1

## New features

#### SRM_ReservationAction script can now immediately start a booking \[ID_24809\]

The *SRM_ReservationAction* script can now immediately start a booking and its contributing bookings, if any. This is possible both in silent and in interactive mode.

In order to avoid potential quarantine conflicts, it will only be possible to force a quarantine when the action is executed interactively. This way the user can decide whether to cancel the operation or force the booking update.

#### Labels assigned to nodes of dynamically generated service definitions \[ID_25227\]

Service definitions that are dynamically generated for contributing bookings (based on the Dijkstra algorithm) will now have a label assigned to each node. The label will be an incremental integer starting at 1. The last node will be indicated with "N", to allow easy mapping in Visio drawings. If the service definition contains only one node, the node label will be 1.

#### New 'Use Node Label As Element Alias' option \[ID_25236\]

A new *Use Node Label As Element Alias* toggle button is now available in the Booking Manager, via *General* > *Booking Wizard Options*.

If this button is enabled, a node label is used as service element alias, so that an element in a service will be displayed with the label associated with the corresponding node in the service definition. If the button is disabled, the service elements will be displayed with the resource DVE names.

## Changes

### Enhancements

#### Empty appendix supported for contributing booking creation \[ID_24903\]

When contributing bookings are created, an empty appendix is now supported.

For this purpose, the JSON parameter *{"AppendixReservationName":"\<Name>"}* can be used as an input parameter, or used in the *Contributing Config* property of the service definition. For example:

| Property | Value |
|----------|-------|
| Contributing Config | {ParentSystemFunction":"b91f59c8-58f2-4422-9a28-f0a6b815ab0","ResourcePool":"SDMN.SAT.RXSAT","AppendixReservationName":"",LifeCycle":"Locked"} |

#### Support for network path with one element \[ID_25031\]

It is now possible to have a network path consisting of only a single element or network device. Previously, if a path used the same element as source and destination, this could not be selected.

#### Service definitions only available to select as default depending on Virtual Platform property \[ID_25258\]

The service definitions that can be selected in the Booking Manager are now filtered based on their *Virtual Platform* property. The *Default Booking Service Definition* must now always have the *Virtual Platform* property and the value of the property must be the same as the *Default Virtual Platform* specified in the Booking Manager settings. If no virtual platform is specified in the Booking Manager settings, all template service definitions will be selectable in the *Default Booking Service Definition* drop-down list.

### Fixes

#### Booking life cycle of contributing booking not updated correctly \[ID_24856\]

In some cases, it could occur that the booking life cycle of a contributing booking was not updated by local events as it should be, but instead by the main booking.

#### SRM_ServiceType service property not updated \[ID_24887\]

Except in contributing bookings, it could occur that the service property *SRM_ServiceType* was not updated, which could cause other issues if the *Persistent service* option was not enabled.

#### Contributing protocols not deleted correctly \[ID_24907\]

In some cases, it could occur that contributing protocols were not deleted correctly, which could make it impossible to create a contributing booking based on the same service definition.

#### Visio file for contributing booking not added \[ID_25033\]

In some cases, it could occur that the Visio file for a contributing booking could not be added.

#### Not all properties set for silent booking without auto-assign \[ID_25051\]

When a booking was created silently without automatically assigning resources, it could occur that the properties for the booking were not set correctly.

#### Generic source not correctly loaded with model action \[ID_25052\]

If a model action object was provided as input to a Resource Script parameter, it could occur that no parameter data were filled in for a generic source node.

#### Changing booking time also caused change to start time of ongoing contributing booking \[ID_25112\]

If the time of a booking was modified, it could occur that the start time of an ongoing contributing booking was also adapted, while this should not be the case.

#### Properties not added correctly to service \[ID_25194\]

If the *Persistent service* option was not enabled, it could occur that properties were not correctly added to a service.

#### Incorrect protocol parameter ID returned in script \[ID_25196\]

In case an element exported two different types of resources that shared the same profile parameter, it could occur that an incorrect protocol parameter ID was returned in a script.
