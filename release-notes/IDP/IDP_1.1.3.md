---
uid: IDP_1.1.3
---

# IDP 1.1.3

## New features

#### New IDP_CI_Type_Management script to create CI types JSON \[ID_23005\]\[ID_23182\] \[ID_23231\]

A new script, *IDP_CI_Type_Management*, is now available, which can be used to generate a CI type in JSON format and upload it to the DataMiner IDP CMDB element. You can create new CI types and edit existing CI types by launching this script from the new *Admin* > *CI Types* tab.

The following connection types are currently supported:

- SNMPv1 and v2
- HTTP
- Serial

#### IDP app: Cleanup of unused discovery profiles \[ID_23020\]

The administrator user can now remove discovery templates that are not used. This can be done in the IDP app, via *Admin* > *Discovery*. Removing a discovery template that is in use is not possible.

#### Setup wizard now allows configuration of binding address Provisioning API \[ID_23105\]

In the *Extra Configurations* screen of the IDP setup wizard, you can now configure the hostname and IP address to use when binding the Provisioning API.

## Changes

### Enhancements

#### Generic Rack Layout Manager now always connected to provisioning API \[ID_22859\]

Previously, if there had not been any changes recently, it could occur that the Rack Layout Manager was no longer connected to the Skyline Generic Provisioning API. Now, RLM elements have a timer to connect to the API regularly, so that they are never disconnected.

#### Generic Rack Layout Manager Visio drawings adjusted to match IDP app layout \[ID_22881\]

All Visio drawings managed by the Generic Rack Layout Manager have been adjusted so that they are more in line with the IDP application.

Specifically, the Visio drawings assigned to views representing Locations, Buildings, Floors, Rooms, Aisles and Racks were changed. Rack usage KPIs are now represented in table format. Moreover, these Visio drawings now have the same width and scaling options as the IDP application.

#### IDP app: Improved software status validation \[ID_22918\]

In case the expected software version of a device is contained in its detected software version, the IDP app will now display the status of the software version as "up to date".

#### Skyline Generic Provisioning: Improved element name validation \[ID_22924\]

The validation of proposed element names will now take the length of the names in account, as element names of more than 150 characters are not allowed in DataMiner.

#### IDP app: Improved software version information \[ID_22935\]

The software version information of a managed element is now refreshed as soon as the element is added in the *Software* tab of the IDP app. The software version information is also periodically refreshed automatically, and can be updated manually with the refresh button.

#### IDP app: Improved slow poll mechanism \[ID_22942\]

The slow poll mechanism implemented in the *Skyline Infrastructure Discovery And Provisioning* protocol has been improved, in order to ensure better performance and to make sure that the slow poll settings of the DataMiner IDP element are taken into account.

#### Adjusted default port settings of elements connecting to API \[ID_23072\]

The default port settings for the HTTP API connection of the Generic Rack Layout Manager and Skyline DataMiner Infrastructure Discovery drivers have been adjusted.

#### IDP setup wizard window size optimization \[ID_23073\]

The window displaying the setup wizard has been optimized so that it always shows as much content as possible in the available space on the screen. When necessary, scroll bars will be displayed.

#### IDP now uses UTC \[ID_23104\]

The Skyline Generic Provisioning API will now use UTC in its responses.

In addition, the various IDP drivers were updated to explicitly mention that UTC is used.

#### Skyline Generic Provisioning API: Extended validation for new element creation \[ID_23125\]

In the following situations, the Skyline Generic Provisioning API will now return a message that it failed to create a new element:

- The element name contains invalid characters
- The protocol or protocol version does not exist
- The IP address is not configured
- The alarm and/or trend template do not exist

#### IDP DMA Agents configuration now supports DMS changes \[ID_23137\]

The *DMA Agents* table of the DataMiner IDP Provisioning element and the *Fallback Agent* selection in the IDP app now support the following changes in the DataMiner cluster:

- Addition of a new Agent
- Removal of an existing Agent
- Failover switches

### Fixes

#### Skyline Generic Provisioning: Parameter set not applied when element was not yet available \[ID_22876\]

If an element was not yet available, it could occur that parameter sets were not applied during provisioning. Now the Skyline Generic Provisioning protocol will wait until an element is available before a parameter is set.

#### Generic Rack Layout Manager: Incorrect device space usage information \[ID_23018\]

In some cases, it could occur that the Rack Layout Manager element did not indicate the device space usage of managed devices correctly.

#### Setup failed when element used by IDP Solution was stopped \[ID_23078\]

If the setup wizard was run while one of the elements of the IDP Solution was in the stopped state, it could occur that the setup failed. Now the wizard will attempt to restart any stopped IDP elements to prevent this issue.

#### Skyline Infrastructure, Discovery and Provisioning: Inconsistent component info \[ID_23158\]

In some cases, it could occur that the component availability information in the IDP element was not correct.

#### Exception when deleting scan range \[ID_23191\]

In some cases, an exception could be thrown when you tried to delete a scan range.

#### IDP setup wizard: View creation issue \[ID_23246\]

When IDP was installed for the first time, in the view creation step of the setup wizard, it could occur that the root view was displayed as an existing view and the wizard did not propose new views to be created. When you selected to create a new view, it could occur that the script failed.

#### Configuration tab already displayed while still being developed \[ID_23269\]

In the IDP app, a *Configuration* tab could be displayed, even though the functionality of this tab is still being developed. This tab has now been removed.
