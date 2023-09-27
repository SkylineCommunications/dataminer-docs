---
uid: IDP_1.1.6
---

# IDP 1.1.6

## New features

#### New settings to control default behavior of workflow automation settings \[ID_24949\]

On the *Settings* data page of the *DataMiner IDP CI Types* element, two new settings, *Enable Discovery* and *Enable Provisioning*, are now available. These allow you to define the default behavior of the discovery and provisioning workflow automation toggle buttons in the IDP app.

If *Enable Discovery* or *Enable Provisioning* is set to *Manual* (the default value), the corresponding automation setting needs to be enabled manually when the CI type has been fully configured.

If *Enable Discovery* or *Enable Provisioning* is set to *Automatic*, the corresponding automation setting will automatically be enabled when the discovery or provisioning completeness reaches 100%.

#### Button to delete CI type in CI type management window \[ID_24988\]

When you edit a CI type by going to *Admin* > *CI Types* > *Overview* and clicking the *Edit* button for this CI type, a *Delete* button will now be displayed in the CI type management pop-up window. If this button is clicked and any elements are still assigned to this CI type, a message will notify the user that the CI type cannot be removed because elements are still assigned to it. If no elements are assigned to the CI type, it will be removed from the system when the button is clicked.

#### New DataMiner IDP Connectivity component \[ID_25016\]\[ID_25077\]\[ID_25150\]

The IDP Solution now has a new *DataMiner IDP Connectivity* component, using the protocol *Skyline IDP Connectivity*. When the IDP Solution is installed or updated, the setup wizard will install this new element. It allows you to manage DCF connections within the IDP Solution. It will process DCF information and create DCF connections for CI types that have connectivity discovery enabled.

On the *General* page of the *DataMiner IDP Connectivity* element, the *Mapping* table will store element information and the *Connections* table will store interfaces and port information. In the *Mapping* table, you can click the *Commit* button to start the connectivity discovery for a specific element. Above the table, the *Commit All* button can be used to start the connectivity discovery for all elements.

#### Reapplying and reassigning CI types \[ID_25034\]

It is now possible to reapply or reassign a CI type to a managed element. Reapplying a CI type can for instance be useful to revert the element to its original configuration in case changes were made or to make the element reflect an update to the CI type. Reassigning a CI type can for example be of use in case the system administrator originally used one generic CI type for a family of devices but now wants to use more specific CI types.

You can reapply or reassign a CI type to an element by going to the *Inventory* > *Managed* tab in the IDP app, selecting the element and then clicking the *Reapply* or *Reassign* button above the list of managed elements.

When you reapply a CI type, you will then need to click the *Reapply* button in the pop-up window. When you reassign a CI type, you will be able to select a different CI type in a drop-down box and then click the *Reassign* button in the pop-up window. Only CI types for which provisioning is enabled via *Workflows* > *Automation* will be displayed in the drop-down box.

Regardless of whether you are reapplying or reassigning a CI type, you can then select which of the following parts of the CI Type should be applied: the element name, element description, initial protocol and version, initial alarm template, initial trend template, initial port info, password setup, default element state, initial views and the update property script. If you select the initial views option, you can also select to remove the element from other views or keep it in other views.

The initial protocol and version, initial alarm template, initial trend template, initial port info, and password setup are always selected in case you are reassigning a CI type. In case any of these are the same in the element and in the CI type you want to reapply or reassign, the corresponding options will be disabled in the window.

In case selecting a particular option will have a significant effect on the functionality of the element, for example in case the element currently uses a different protocol than the initial protocol defined in the CI type, a warning will be displayed for this option.

#### Example script to discover connections \[ID_25047\]

The IDP Solution will now be shipped with an example script, *IDP_Example_Custom_ConnectivityDiscovery*, that can be used to develop scripts to discover connections. Though the script itself is not meant to be run, users can duplicate it and fine-tune the duplicated script in order to create their own custom script.

The script contains the following actions:

- Informing IDP that a connectivity discovery has started.
- Retrieving the necessary information from the element.
- Sending this information to IDP.
- Indicating if it was able to stop successfully or if it failed at some point.

#### New IDP_Connectivity script \[ID_25103\]

A new script, *IDP_Connectivity*, has been added to the IDP Solution, in the Automation folder *DataMiner Solutions/IDP/CI Type Management/Connectivity*. This script will be launched when a connectivity discovery is executed. In the input for the script, multiple CI types and element IDs can be specified, separated by pipe characters. The script will make sure the connectivity script for the relevant CI types is executed if workflow automation is enabled for the CI types. Unlike the scripts for specific CI types, the *IDP_Connectivity* script may not be modified by users.

#### Connectivity discovery in the IDP app \[ID_25126\]\[ID_25312\]\[ID_25428\]

You can now assign an Automation script to a CI type in order to discover connectivity information for an element so that the IDP Solution can provision the necessary connections.

In the IDP app, you can assign a script to a CI type on the page *Admin* > *CI Types* > *Connectivity*. This page displays a table listing the CI types with an indication of the completeness of their connectivity discovery configuration and their assigned script, if any. To assign a script, in the *Connectivity Discovery Script* column, you can select any of the scripts from the connectivity discovery scripts folder (by default *DataMiner Solutions/IDP/CI Type Management/Connectivity/Discovery*). The main CI type management wizard has also been updated to include the settings to configure connectivity discovery. Clicking the *Advanced* button in the table will open the wizard on the relevant page.

If a script has been assigned to a CI type, the connectivity discovery feature can be enabled for the CI type on the page *Workflows* > *Automation*.

Once connectivity discovery has been enabled for a CI type, you can start a connectivity discovery action for one or more managed elements in the *Connectivity* tab of the IDP app, by selecting the elements in the table and clicking the *Discover* button above the table. In the table, the *Update Progress* column displays a progress report of the discovery and the *Status* column displays the current status of the discovery. Once the discovery process has finished, the *Status* column displays the number of discovered connections.

## Changes

### Enhancements

#### CI type management wizard: Views sorted alphabetically \[ID_24910\]

In the CI type management wizard, the views in the section *Provisioning* > *Views* are now sorted alphabetically.

#### CI type management wizard enhancements \[ID_24924\]

In the CI type management wizard, when an *Update Property Script*, *Backup Script Name*, *Update Script Name* or *Rack Assignment Script* has been selected, it is now possible to clear that selection again. In addition, the *Update Property Script* parameter has now been added to the Provisioning window.

#### Unused IDP dashboards removed \[ID_25039\]

Up to now, the IDP package contained dashboards that were not used. These are now no longer included in the package. In case they had already been installed, they will be removed when IDP is updated.

#### Discovery of SNMPv2-only devices now supported \[ID_25166\]

The IDP Solution now allows the discovery of devices that only allow SNMPv2 communication.

### Fixes

#### CI type management wizard: Parameter deletion under Provisioning \> Password Setup not working \[ID_24908\]

In the CI type management wizard, if you deleted a parameter under *Provisioning* > *Password Setup*, it could occur that the deletion was not implemented.

#### Incorrect labels in scan range wizard \[ID_24975\]

In the wizard to configure a scan range, it could occur that some labels were not displayed correctly.

#### CI types not generated correctly for protocols with serial connection \[ID_25082\]

For protocols with a serial connection, it could occur that CI types were not generated correctly because the default type was "Serial" instead of "TCP/IP".

#### Images in the Location, Building, Floor and Room visual overviews not displayed \[ID_25355\]

If the IDP Solution was used with recent DataMiner versions, it could occur that images embedded in the *Location*, *Building*, *Floor* and *Room* visual overviews were not displayed.

#### Discovery timeout \[ID_25431\]

In some cases, it could occur that the discovery operation timed out. The discovery process has now been made more efficient to prevent this.

#### Problem with DataMiner IDP Rack Layout Manager element \[ID_25470\]

In some cases, it could occur that the *DataMiner IDP Rack Layout Manager* element kept toggling between normal and timeout state, and that as a consequence no elements were filled in in the *Devices* table and properties were not created.
