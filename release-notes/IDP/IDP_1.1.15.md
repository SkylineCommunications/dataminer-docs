---
uid: IDP_1.1.15
---

# IDP 1.1.15

## New features

#### Provisioning debug logging \[ID_30249\]

To make it easier to troubleshoot provisioning issues in case Process Automation is used, the Provisioning element now has a debug toggle button on the *Settings* page. If this button is enabled, a *Debug* page is shown, where you can enable debug logging.

#### Enhanced properties UI in CI type management wizard \[ID_30265\]

The properties UI in the CI type management wizard has been enhanced. Previously, it consisted of an alphabetically sorted list of all element properties, which could make it hard to find the required properties for the configuration.

Now the UI consists of the following different sections.

- In the *Properties* section at the top, you can manage the properties that IDP adds to the system. The units and ranges of the properties are displayed where relevant. Any properties that should not be changed by the user are hidden in the wizard.
- Below this, all element properties related to rack and facility management are grouped in the *Configure Facility Details* section, which is collapsed by default.
- At the bottom of the window, the *Other Properties* section allows you to add other properties and specify a value for them. These can be both existing or new properties. If a new property is added, it is created in the DMS as soon as an element for the CI type is created.

#### Configuration \> Visualization page renamed and redesigned \[ID_30373\]

The section *Admin* > *Configuration* > *Visualization* of the IDP app has been renamed to *Admin* > *Configuration* > *Backup*. This section now contains two tables. At the top, the supported file extensions for visualizations are shown. Below this, a new table with configuration types is displayed, which allows you to enable or disable specific backup types. When you start a configuration backup, only the enabled types will be available. If all types are disabled, a notification will be displayed instead.

#### Support for removal of DCF connections \[ID_30432\]

Support has been added for the removal of DCF connections through IDP. Several methods have been added in *DataminerSolutions.dll* for this purpose, allowing the following kinds of behavior:

- Removal of all DCF connections for a specific element.

  This can be done by first creating a list of *DcfConnectionFilter* objects based on the DMA and element ID, and then calling the *RemoveAllDcfConnections* method from a *Connectivity* object using this list.

- Removal of a specific connection.

  This can be done by first creating a list of *DcfByConnectionIdFilter* objects based on the DMA ID, element ID, and connection ID, and then calling the *RemoveDcfConnectionsById* method from a *Connectivity* object using this list.

- Removal of all connections of a specific interface.

  This can be done by first creating a list of *DcfByInterfaceIdFilter* objects based on the DMA ID, element ID and interface ID. Optionally, the interface properties to be removed can also be provided. Then the *RemoveDcfConnectionsByInterface* method should be called from a *Connectivity* object using the list.

- Removal of all interface properties of a specific interface.

  This can be done by first creating a list of *DcfByInterfaceIdFilter* objects based on the DMA ID, element ID and interface ID, and then calling the *RemoveDcfInterfacePropertiesByInterfaceId* method from a *Connectivity* object using this list.

#### New Provisioning Started status in Discovered Elements table \[ID_30499\]

In the *Discovered Elements* table (available in the IDP app via *Inventory* > *Discovered*), a new status is now possible in the *Provisioning Status* column. When a provisioning request has been initiated, now the status *Provisioning Started* will be displayed in this column.

If this status is displayed for a specific device, it will not be possible to trigger a second provisioning request for the same device, which means that clicking the *Provision* button will have no effect for this device.

#### Software update example script \[ID_30545\]

A new software update example script is now available, which can be used as a starting point to create custom scripts to perform software updates for CI types. The script explains the usage of the new *SoftwareUpdate* class as well as how to inform IDP of errors during the software update operation.

The *SoftwareUpgrade* class that could previously be used for this is now considered obsolete.

## Changes

### Enhancements

#### IS-04 node ID automatically filled in in element property \[ID_30222\]

When an IS-04 node registers itself with the IS-04 registry, the node ID is now automatically provisioned in the element property. Previously, a custom update properties script was required for this.

#### Configuration update progress now mentions failure information \[ID_30400\]

When a backup cannot be stored in the Configuration Archive, the update progress on the *Configuration* > *Summary* page will now mention that the configuration backup has failed. It will also mention the cause of the failure if possible.

#### IDP Process Automation scripts moved to different folder in Automation module \[ID_30442\]

All IDP Process Automation scripts are now located in the folder *DataMiner Solutions\\IDP\\Processes* in the Automation module. The following scripts are included:

- IDP_Configuration_TakeBackup
- IDP_Discovery_Actions_Start
- IDP_Discovery_ConvertToScanRange
- IDP_Facilities_AutoAssignRackPosition
- IDP_ProcessAutomationWizard
- IDP_Provisioning_ConvertToElement
- IDP_Provisioning_CreateElement
- IDP_Provisioning_DeleteElement
- IDP_Provisioning_ReapplyCIType
- IDP_Provisioning_ReassignCIType
- IDP_Register_IS04Nodes
- IDP_Software_UpdateImage
- SRM_LSO_IS04ProcessAutomation

Previously, these scripts (except IDP_ProcessAutomationWizard) were stored in the folder *DataMiner Solutions\\IDP\\Workflows*.

#### Improved configuration backup example script \[ID_30607\]

The configuration backup example script has been modified to be more user-friendly. The script now shows the most important steps to create backup scripts, indicates when to use specific methods, and contains examples of when to inform of failures or when to consider an action successful. More than one flow is illustrated in order to show the different available possibilities. The comments also indicate the best places to add custom code.

While the previous version of the example script remains usable, we recommend to no longer use its methods and constructors, as these are now considered obsolete.

#### Improved connectivity discovery example script \[ID_30608\]

The connectivity discovery example script has been modified to be more user-friendly. The script shows the most important steps to create connectivity discovery scripts, indicates when to use specific methods, and contains examples of when to inform of failures or when to consider an action successful. The comments also indicate the best places to add custom code.

While the existing connectivity discovery script remains usable, we recommend not to use its methods and constructors, as these are now considered obsolete.

### Fixes

#### Incorrect duration of configuration backup displayed \[ID_30113\]

When executing a configuration backup, IDP did not take the time for the script to get the configuration from the device into account. Only the time to store the file in the DataMiner Configuration Archive was considered. Because of this, it could occur that an incorrect duration was shown in the configuration summary table.

#### Problem when updating properties of element located in multiple views within Infrastructure view \[ID_30177\]

If multiple views in the Infrastructure view contained the same element, a problem could occur when its properties were modified. The element will now be removed from the other views in the Infrastructure view in accordance with the property change.

#### DMA ID not resolved during provisioning in Failover setup \[ID_30267\]

When a discovery is performed, a DMA name is suggested for provisioning. Previously, this was only resolved to a DMA ID at the time when the element was effectively provisioned. However, in case the DMA name referred to a DMA in a Failover pair, especially if a Failover switch happened between the discovery and provisioning operation, it could occur that the DMA ID could not be resolved.

Now the DMA ID will also be added at the time of discovery to prevent this issue.

#### Discovery resource created with incorrect name \[ID_30287\]

In some cases, when you ran the IDP setup wizard, it could occur that a new resource with the incorrect name "SLC IDP Discover**y** Data Sources" was created instead of "SLC IDP Discover Data Sources".

#### Problem with folder creation and detection of existing folder \[ID_30331\]

When a folder with a long path was specified in the IDP app, it could occur that the \\\\?\\ prefix was not applied correctly. In addition, in some cases it could occur that an existing folder was not correctly detected.

#### Default Update File field not displayed in CI type management wizard \[ID_30367\]

If the *Default Update File* field was empty, it could occur that it was not displayed in the CI type management wizard.

#### Null values in output tokens of SLC IDP Delete Element activity \[ID_30424\]

The output tokens of the SLC IDP Delete Element activity could have null values for volatile profile instances, which made it impossible for subsequent activities to use the tokens of this activity.

#### Rack Layout Manager not updated with newly created elements after refresh of Pending Elements table \[ID_30574\]

When the *Pending Elements* table was refreshed on the DataMiner IDP element, it could occur that a parameter was set incorrectly on the DataMiner IDP Rack Layout Manager element, which in turn could make it impossible for the Rack Layout Manager to updated its tables with newly created elements.
