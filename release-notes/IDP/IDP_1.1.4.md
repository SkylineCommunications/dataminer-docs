---
uid: IDP_1.1.4
---

# IDP 1.1.4

## New features

#### IDP app: Editing and creation of CI types \[ID_23487\]

In the IDP app, on the *Admin* > *CI Types* tab, you can now edit a selected CI type. In addition, a button is now available on this tab that can be used to create a new CI type.

#### IDP app: New 'Discovery Results to Show' option \[ID_23502\]

A new option is available in the IDP app, which allows you to determine which discovery results are shown in the *Discovered Elements* table. With the *Discovery Results to Show* parameter, you can now either have all discoveries displayed, or only the latest discovery. You can find this option on the *Settings* data page of the app.

#### Configuration provisioning details CI type \[ID_23571\]\[ID_23583\]

The Skyline IDP CMDB driver has been updated so that it is now possible to manage the provisioning details of a CI type directly in the *DataMiner IDP CI Types* element.

In addition, the provisioning details of a CI type can now also be managed in the IDP app itself, via *Admin* > *CI Types* > *Provisioning*. To modify advanced settings for a CI type, click the *Advanced* button in the row listing the CI type. This will activate a wizard that allows you to edit every detail.

#### Skyline IDP CMDB: Exporting CI types \[ID_23690\]

The *DataMiner IDP CI Types* element, which uses the Skyline IDP CMDB protocol, now allows you to export one or more CI types to JSON format.

If you select CI types in the *CI Types Templates* table, you can click the *Export Selected* button to export the selected CI types. Alternatively, you can click the *Export all* button to export all CI types in the table. The exported files are located in the folder configured using the *CI Type File Path* parameter. By default, this is *C:\\Skyline DataMiner\\Documents*\\*Skyline IDP CMDB*\\*CI Types*.

#### Additional scripts launched after element creation \[ID_23716\]

When a new element is created using the IDP Solution, the script *IDP_Default_UpdateProperties* is now launched in order to update the properties of the element based on the CI type.

In addition, it is also possible to configure an extra script to run after this script, in order to update other settings on the newly created element. This extra script can be configured in the IDP app via *Admin* > *CI Types* > *Provisioning*. It can also be configured on the *Provisioning* page of the DataMiner IDP CI Types element.

#### IDP app: Additional information on Provisioning page \[ID_23757\]

In the IDP app, on the *Admin* > *CI types* > *Provisioning* page, the following columns were added to the overview:

- Default Element State
- Initial Protocol
- Initial Alarm Template
- Initial Trend Template
- Initial Views
- Update Property Script

#### Possibility to disable discovery for CI types \[ID_23778\]

In the IDP app, it is now possible to enable or disable discovery for particular CI types on the *Workflow* > *Automation* tab. You can do so with the toggle button in the *Discovery* column. By default, this is set to disabled.

The *Skyline IDP Discovery* protocol will only perform discoveries for those CI types that have discovery set to enabled.

#### Possibility to disable element creation for CI types \[ID_23781\]

In the IDP app, it is now possible to enable or disable element creation for particular CI types on the *Workflow* > *Automation* tab. You can do so with the toggle button in the *Provisioning* column. By default, this is set to disabled.

#### Overview of discovery details for CI types \[ID_23804\]

On the *Admin* > *CI Types* tab of the IDP app, the *Discovery* page now displays a table that can be used to manage CI types and compare the settings of different CI types.

The table consists of the following columns:

- *CI Type*: Contains the names of the CI types.
- *Completeness*: Indicates whether mandatory fields are filled in. If there is a discovery condition, this is set to 100%.
- *Identifiers*: Contains a textual representation of the discovery identifiers and the conditions that should be used when a device is discovered.
- *Advanced*: Contains a button that can be used to launch the CI Type Management wizard for the relevant CI type.

#### Button added to duplicate a CI type \[ID_23954\]

When you select a CI type in any of the tables on the *Admin* > *CI types* tab of the IDP app, a *Duplicate* button is now displayed. Clicking the button opens a pop-up window that allows you to create an exact copy or to implement some changes to create a new CI type.

#### CI type controls on the Workflows \> Automation page \[ID_24104\]

In the IDP app, the *Workflows* > *Automation* page now contains a table listing all CI types, with buttons for each CI type that can be used to enable or disable discovery, provisioning, software updates and software compliancy for this CI type.

#### Automatic generation of CI types \[ID_24106\]

To facilitate the initial configuration of the IDP Solution, during setup, you can now select to have CI types automatically generated for some or all of the drivers in the system. CI types will be generated for the Production version of the drivers.

This functionality can also be used when new drivers are installed in the DMS, in order to generate CI types for these new drivers without affecting existing CI types.

#### CI types software management page in IDP app Admin section \[ID_24215\]

In the IDP app, the *Admin* > *CI Types* tab now contains a *Software Management* page where you can view and edit the software details for the CI types.

## Changes

### Enhancements

#### CI type management script improvements \[ID_23817\]

A number of improvements have been implemented to the CI type management script:

- When a new CI type is created, the number of retries for the element is now set to 3 by default.
- When a new CI type is created, the Type is now set to the element type from the protocol. Previously, the Type was an empty string.
- When an existing CI type is edited, *DMAElementSNMPPortInfo* objects are no longer duplicated.

#### HTTPS_GET discovery profile now contains port 443 by default \[ID_23939\]

The discovery profile HTTPS_GET now contains the default port for HTTPS, i.e. 443, instead of the previous port 80, which is the default port for HTTP. In addition, the identifier name has been changed from GET_80 to GET_443.

#### Improved support for element name changes \[ID_23974\]

The IDP Solution now better supports changes to the names of elements created by the Solution.

For this purpose, the index of the *Managed Elements*, *Software Updates* and *Configuration Management* tables now no longer contains the element name, but only the DMA ID/Element ID of the listed elements.

In addition, when the Solution is informed of an element name change, it will update the element name in the three above-mentioned tables and in the *DataMiner Devices* table of the Rack Layout Manager.

#### Limitation on number of IP addresses for discovery removed \[ID_24130\]

There is no longer a limitation on the number of IP addresses that can be scanned in a single discovery request. Requests can now run for as long as the time configured in the *Discovery Request Timeout* parameter.

#### Custom software update script now receives parameters identifying element to update \[ID_24135\]

If a custom software update script is used, it will now receive the following parameters from the IDP Solution, in order to identify the element that needs to be updated:

- GUID
- DataMiner ID
- Element ID
- CI type
- Image file location

#### Default discovery profiles now imported during setup \[ID_24148\]

When the IDP setup wizard is run, the following default discovery profiles are now imported into the IDP Solution:

- SNMP_MIB_II.json
- HTTP_GET.json
- HTTPS_GET.json

#### RLM_RemoveDevice script now sets parameters after manual deselection of rack \[ID_24235\]

When the selection of a rack for a specific device is cleared manually, the *RLM_RemoveDevice* script will now set the related parameters, such as the slot position and rack position, to their exception value.

#### Rack Layout Manager: Maps removed from visual overview for building, floor and room level \[ID_24281\]

On the visual overview for the building, floor and room level of the infrastructure, a map will no longer be displayed, since these always have the same coordinates as the corresponding location. The map will now only be displayed for the location level.

### Fixes

#### Automatic element creation could generate duplicate elements \[ID_23441\]

In some cases, when automatic creation of discovered elements was activated, it could occur that duplicate elements were generated.

#### Setup wizard quit early during first IDP installation \[ID_23535\]

In some cases, when IDP was installed for the first time, it could occur that the setup wizard quit before the installation was complete.

#### Generic Rack Layout Manager: Moving element to rack failed \[ID_23807\]

In some cases, when you moved an element to a rack, it could occur that this change was not implemented correctly.

#### Generic Rack Layout Manager: Custom device name reset upon refresh \[ID_23847\]

When a custom name was configured in the DataMiner Devices table, this name was reset whenever the button Refresh Elements was clicked.

#### Generic Rack Layout Manager: Not possible to copy/move elements in rack view \[ID_24152\]

In some cases, it could occur that it was not possible to copy and move elements within a rack view.

#### Rack Layout Manager: Negative values in Racks Table \[ID_24214\]

In some cases, the calculated value for *Device Space Usage* and *Expected Energy Consumption* could be negative in the Racks Table.

#### Rack Layout Manager: Message displayed incorrectly in rack visual overview \[ID_24247\]

In the visual overview for a rack, in the bottom right corner, a message is displayed if no device has been selected yet. However, when you clicked the picture icon, it could occur that another message was displayed on top of this first message, making both messages illegible.

#### Rack Layout Manager: Incorrect column widths in tables showing details child items per level \[ID_24254\]

In the table showing the details for the child items at a particular level in the infrastructure, it could occur that the width of the columns was not correct.

#### No devices discovered after Provisioning API restart \[ID_24307\]

If the provisioning API was restarted, it could occur that no devices could be discovered.
