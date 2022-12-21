---
uid: SRM_1.2.11
---

# SRM 1.2.11

## New features

#### New service definition node property to allow reuse of contributing resources \[ID_28958\]

A new property, *Reuse Contributing Resource*, can now be configured on a service definition node. If this property is set to true, and a contributing resource is already available, no new contributing resource will be created by the Service Profile Wizard. If this property is set to false, the previous default behavior will be maintained and a new contributing resource will always be created by the wizard.

#### Contributing resource ID now possible input argument for contributing conversion script \[ID_28961\]

When a booking is converted to a contributing booking, a custom script can be executed. You can now add the contributing resource ID as an input argument for this script by using the \[RESOURCEID\] placeholder. When you specify the script in the Booking Manager settings, add this placeholder as follows: *Script:SRM_DummyScript\|\|DummyParameterName=\[RESOURCEID\]*

#### New service definition node property to set read-only resource selection for node \[ID_28965\]

In a service definition, you can now configure that the resource selection for a specific node should not be editable in the Booking Wizard. To do so, define the property *ReadOnlyResourceSelectionControl* on the node and set it to *true*.

#### Support for multiple placeholders in one line in timeline booking blocks \[ID_28995\]

It is now possible to add more than one placeholder in one line of the configuration for booking blocks on the Booking Manager timeline.

#### New Dashboard tab in the Booking Manager app \[ID_29015\]

The Booking Manager app now has a new *Dashboard* tab. This tab provides an overview of all the services created with the Booking Manager.

The tab contains different subtabs representing the different views that contain services. There is also an "All" subtab, which shows all services across the different views.

At the top of the Dashboard tab, you can select whether the services should be displayed as boxes showing the service name and the overall alarm state of the service ("Service Name"), or as icons with the service alarm color, which display the service name in a tooltip when you hover the mouse pointer over them ("Small icon").

In the top-right corner of the tab, a filter box is also available. If text is entered in this box, only the services of which the name matches this text will be displayed. Finally, two toggle buttons are also available in the top-left corner:

- *Severity Sorting*: Determines whether services are sorted by name or by severity.
- *Penalty Box*: Determines whether all services are displayed or only those in alarm.

#### Custom script to transfer data between functions during service profile booking creation \[ID_29069\]

During creation a booking based on a service profile, a custom script can now be launched that allows the transfer of data between functions. It is also possible to change a parameter of a contributing booking or of a main booking.

In the service profile instance or service profile definition, the property *Service Profile Data Transfer Configuration* allows you to define which script should be used for this. The value of this property must be a configuration JSON object with a *Script* key, for example: *{"Script":"SRM_ServiceProfileDataTransferExample"}*

If the property is defined both on instance and on definition level, the instance level takes precedence. If several service profiles have a configuration defined, the scripts will be executed top-down.

You can find examples of how to implement a data transfer script in the automation scripts *SRM_ServiceProfileDataTransferExample* and *SRM_ServiceProfileDataTransferExampleShared*.

#### BREAKING CHANGE: Quarantining a contributing booking now affects the main booking \[ID_29095\]

When a contributing booking is quarantined, this will now also affect the main booking.

The predefined capability parameter *SRM_ExposedResourceState* will now automatically be added to the contributing resource, with the value *OK*. When the corresponding booking goes into quarantine, this parameter will be set to *Quarantine*. When the booking leaves quarantine, the state will be reverted to *OK*.

When resources are assigned, if *SRM_ExposedResourceState* is set to *Quarantine*, the resource will be filtered out. When a resource with that capability gets assigned to a booking, the capability will be added as a requirement with state *OK*.

## Changes

### Enhancements

#### Custom Created Booking Action script now executed before booking is confirmed \[ID_28875\]

Custom Create Booking Action scripts will now be executed before a newly created booking is confirmed. This way, if such a custom script fails for some reason, there will be no service state transition.

#### BREAKING CHANGE: Bookings that failed to start now set to Failed \[ID_28912\]

Previously, when a booking failed to start, a custom script would be called, but the booking would still be in Confirmed state. Now its *Booking Life Cycle* will be set to "Failed" and its *Status* will be set to "Pending".

> [!NOTE]
> If you make use of such a custom script, you will need to update it in accordance with the changes in the script *SRM_BookingStartFailureTemplate*, version 1.0.1.1.

#### Changing timing of booking now displays message with new timing including pre- and post-roll \[ID_28916\]

When you change the timing of a booking, the displayed pop-up message will now also show the start time and stop time of the information with the pre-roll and post-roll timing.

#### Applying custom service state now supported in case state is defined in service definition and Booking Manager \[ID_29002\]

Applying a a custom service state is now also possible if the service state is defined in the service definition and the Booking Manager.

#### Filter added to drop-down boxes in Service Profiles wizard \[ID_29013\]

In the Service Profiles wizard, a filter has been added to the drop-down boxes.

### Fixes

#### Extending booking in post-roll extended start of post-roll stage \[ID_28934\]

When a booking in post-roll state was extended, it could occur that the start time of the post-roll stage was extended instead of the end time of the post-roll stage.

#### DTR not triggered when parameter was reset to default value \[ID_28962\]

When a profile instance was no longer selected and this caused a parameter to be reset to its default value, it could occur that Data Transfer Rules (DTR) were not triggered

#### Problem when specifying start time for permanent booking Service Profiles wizard \[ID_29028\]

In some cases, when a permanent booking was created in the Service Profiles wizard, a problem could occur when the start time was specified.

#### Exception when Profile Load script retrieves element generating contributing function DVE \[ID_29038\]

In some cases, it could occur that a Profile Load script threw an exception when trying to retrieve the main element generating a contributing function DVE.

#### Not possible to create multiple bookings for service with custom name \[ID_29085\]

In case a custom service name was used, it could occur that it was not possible to create more than one booking using the same service.

#### Exception during silent creation of booking \[ID_29161\]

When a new booking was created silently, in some cases an exception could be thrown where the script tried to show errors to the user.
