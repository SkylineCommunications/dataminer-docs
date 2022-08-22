---
uid: SRM_1.2.9
---

# SRM 1.2.9

## New features

#### Redesigned automatic resource selection behavior \[ID_28165\]

The automatic selection of resources in the Booking Wizard has been redesigned. Previously, resources were only automatically selected when the Booking Wizard was first launched for a service definition. Now automatic resource selection can be configured with the property *Auto Select Resource* of service definition nodes, which will have an effect every time a node does not have a resource selected (unless the resource was explicitly cleared by the user).

#### Possibility to trigger custom script when booking is converted to contributing booking \[ID_28243\]

A custom script can now be triggered when a booking is converted to a contributing booking. This is mainly intended to make it possible to assign capabilities and capacities to contributing resources with a custom script.

For this purpose, a new *Script* field is available in the *Contributing Configuration* class field. This field should contain a string value in the same format as for the *Created Booking Action* property.

To configure this feature, use the *Contributing Config* or *Contributing Configuration* property and configure a value like in the following example:

```json
{
 "CandidateResources": null,
 "Concurrency": 310,
 "ConvertToContributing": true,
 "LifeCycle": "Locked",
 "OrchestrationTrigger": "Local",
 "ParentSystemFunction": "b91f59c8-58f2-4422-9a28-f0a6bf815ab0",
 "PostRoll": 0,
 "PreRoll": 0,
 "ReservationAppendixName": "V46GQJ",
 "ReservationType": "Standalone",
 "ResourcePool": "SDMN.SAT.Resource Pool",
 "Script": "Script:SRM_DummyScript||DummyParameterName=DummyValue",
 "VisioFileName": null
}
```

To trigger a custom script after the creation of a transport booking, configure the *Path* parameter as follows:

```json
{
 "Link": "PATH",
 "Paths": [
  {
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
    "Script": "Script:SRM_DummyScript||DummyParameterName=DummyValue"
   }
  }
 ]
}
```

#### Support for V2 functions in Booking Wizard \[ID_28390\]

The Booking Wizard now supports V2 functions and resources. These will be handled in the same way as V1 functions.

However, note that this is currently not yet supported for bookings created based on service profiles and for contributing workflows.

## Changes

### Enhancements

#### Improved error reporting in case of issue during transport path selection \[ID_28049\]

Error reporting has been improved in case an issue occurs during transport path selection.

When an error occurs during the preparation for the path selection, a button with an exclamation mark will now be displayed next to the *Select Path* button. Clicking the new button will display the error message with additional detailed information, if available.

#### Bookings now set to Partial state if custom created booking action script fails \[ID_28213\]

When a custom created booking action script fails, bookings will now always be set to the *Partial* state. Previously, in some cases, the booking went into *On-Hold* state instead.

#### SRM_DiscoverResource script now allows update of unlinked resources \[ID_28348\]

The *SRM_DiscoverResource* script has been improved so that it can be used to update unlinked resources.

To make it easier to import unlinked resources, when resources are exported, the resource ID will now be included. If the resource ID does not exist in the system where a resource is imported, the system will try to find a match based on the resource key (in case of a linked resource) or the resource name (in case of an unlinked resource). If the resource ID does exist, the resource name can be updated via the import, unless that same name is already used by another resource in the same pool.

The following other minor changes were also implemented:

- Before an import is done, DataMiner will now check if the file path exists and the file is accessible.
- The following characters are no longer supported in property, capability and capacity names: . ! \`
- Capacity values will now be validated to ensure that they are within the range defined for the profile parameter.

#### Progress indicator when booking is confirmed/saved \[ID_28365\]

When a booking is being confirmed or saved, the Booking Manager will now indicate the progress of this action.

#### Importing function now updates ResourceInputInterface and ResourceOutputInterface capabilities \[ID_28420\]

When a function is imported, the *ResourceInputInterface* and *ResourceOutputInterface* capabilities will now automatically be updated with the relevant discrete values. If these capability parameters do not exist yet, they will be created.

#### SRM_DiscoverResources script updated to support V2 functions \[ID_28567\]

To add support for V2 functions, the following functionality has been added in the *SRM_DiscoverResources* script:

- Export of bound or unbound virtual function resources.
- Export of resource information linked to a virtual function definition.
- Import of bound or unbound virtual function resources, with the possibility to rename or rebind them and update related info.

#### Filtering of resources in Service Profiles Wizard \[ID_28642\]

In the wizard to create a booking based on a service profile the same filtering will now be applied for resources as in the regular Booking Wizard, i.e. by function, by interface capability and by resource pool. If this is enabled, resources will now also be shown with a first and second priority.

### Fixes

#### Filtering criteria for node resource assignment reset to default value when booking was edited \[ID_28022\]

If a *Resource Assignment* property is defined at node level, during booking creation, the user has to select filtering criteria for a given node. Previously, when such a booking was edited, the filtering criteria were reset to the default value. Now, to ensure that this selection is remembered when the booking is edited, it is saved in the booking property *BookingWizardAssignFilter*.

#### Problem with SRM_ShowResource script \[ID_28221\]

If a booking was created based on service profiles, it could occur that an exception was thrown on the page showing selected resources (via the *Show Resource* button) and the wizard closed without providing any feedback to the user.

In addition, if a resource was assigned based on the pool inheritance feature, an exception was also thrown. In such a case, the resource will now simply not be displayed in the UI.

#### Not possible to change timing of ongoing booking \[ID_28329\]

In some cases, it could occur that it was not possible the change the timing of an ongoing booking via the Booking Manager UI.

#### Issues with SRM_ExportFunctions and SRM_ImportFunctions script \[ID_28354\]

Because the *SRM_ExportFunctions* script did not include parent profile definitions in an export, it could occur that an import failed. This script has been adapted, and the *SRM_ImportFunctions* script has also been adjusted to import such parent profile definitions. In addition, an issue has been resolved that could cause the link to parent functions to be lost when multiple functions were imported.

#### DTR: Not possible to assign numeric value to capability parameter of type text \[ID_28383\]

When data transfer rules (DTR) were used, it could occur that numeric values could not be assigned to capability parameters of type text.

#### Allowed resource type not taken into account for booking with start time in the past \[ID_28411\]

When a booking was created with a start time in the past, it could occur that the resources available for selection in the Booking Wizard were not limited by allowed resource type.

#### Booking remained locked after wizard to edit booking was aborted\[ID_28412\]

If a user aborted the wizard to edit a booking, it could occur that the booking remained locked for editing, so that it was not possible to edit it again.

#### State of Convert to Contributing checkbox not saved when going back in wizard \[ID_28425\]

In some cases, when you returned to a previous page of the wizard to create a booking based on service profiles, it could occur that the selected state of the *Convert to Contributing* checkbox was not saved.

#### Not possible to edit booking using resource pool inheritance \[ID_28524\]

If a booking used resource pool inheritance, it could occur that the booking could not be edited.

#### Editing a booking briefly released its resources \[ID_28620\]

When a booking was edited, its resources could briefly be released while their availability was being re-evaluated. This will no longer occur for confirmed and partial bookings. The resources will only be re-evaluated for quarantined bookings from now on.

#### Incorrect resource assignment when creating booking based on service profile \[ID_28630\]

When a booking was created based on a service profile, it could occur that an incorrect resource was assigned to the booking.
