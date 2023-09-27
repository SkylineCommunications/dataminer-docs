---
uid: IDP_1.1.5
---

# IDP 1.1.5

## New features

#### Configuration Management \[ID_23670\]\[ID_23688\]\[ID_23777\]\[ID_23848\]\[ID_23951\] \[ID_23962\]\[ID_24324\]\[ID_24369\]\[ID_24646\]\[ID_24654\]\[ID_24742\]\[ID_24774\] \[ID_24798\]

A new Configuration Management feature is now available in the IDP app. This new feature allows you to set the default configuration of an element and make a backup of a configuration.

For this purpose, a new *DataMiner IDP Configuration* element has been added to the Solution. This element uses the *Skyline Configuration Manager* driver, which makes it possible to store configuration files in a configuration archive in the network. When IDP is installed or upgraded, the setup wizard allows you to set the path and credentials for the configuration archive.

Two example Automation scripts have also been added:

- The script *IDP_Example_Custom_ConfigurationBackup* is configured to perform a configuration backup of a Cisco Manager element and can be used as an example to create configuration backup scripts for other CI types.
- The script *IDP_Example_Custom_ConfigurationDefault* is a generic script that can be used as an example to create scripts to load the default configuration for specific CI types.

A number of changes have been implemented in the IDP app as part of the Configuration Management feature.

- A new *Configuration* tab is available, with the subtabs *Summary* and *Backups*.

  - The *Summary* tab provides an overview of the elements of which the CI type has Configuration Management enabled. When you select an element in the table, you can use the buttons above the table to create a configuration backup or to apply the default configuration to the element. To make sure the default configuration is not applied by accident, a confirmation box will be displayed when you try to do so. If you click the button *Show Backups*, all available configuration backups from the last 30 days for the selected element will be displayed in the *Backups* tab.
  - The *Backups* tab allows you to view a list of configuration backups, either based on a selection in the *Summary* tab as mentioned above, or based on specific search criteria. Clicking the *Search* icon will open a wizard where you can specify these search criteria. Searching is possible by CI type, by element name or by time range (UTC), or a combination of these.

- Via *Workflows* > *Automation*, you can now enable or disable the Configuration Management features *Take Backup* and *Enable Restore* for each CI type.

- Configuring the Configuration Management features for each CI type is possible via *Admin* > *CI Types* > *Configuration Management*. This page contains a table listing the CI types and their Configuration Management settings. Clicking the *Advanced* button in this table opens the CI type management wizard on the Configuration Management page. Note that if you open the wizard by going to *Admin* > *CI Types* > *Overview* and clicking the *Edit* button for the CI type, this page will also be included.

- The *Admin* > *Configuration* tab now contains the following two pages with Configuration Management settings:

  - *Network Share*: Allows you to modify the credentials and path for the configuration archive.
  - *Purge Settings*: Allows you to configure the automatic cleanup of the configuration archive. You can set a limit on the total number of files, on the number of files per element and on how much space the files use on the disk. When one of these limits is enabled, it is checked whenever a file is added to the configuration archive. The oldest files are always removed first. The *Purge Settings* tab also displays the total number of files in the configuration archive, the number of elements in the configuration archive and the current disk space used. Alarm monitoring and trending can be enabled for these KPIs.

- Via *Admin* > *Settings*, you can configure the folders that contain the default and backup Automation scripts for Configuration Management. By default, these are the following folders:

  - Backup script folder: *DataMiner Solutions/IDP/CI Type Management/Configuration Management/Backup*
  - Default script folder: *DataMiner Solutions/IDP/CI Type Management/Configuration Management/Default*

#### Additional rack assignment possibilities in IDP app \[ID_24526\]

The IDP app now contains additional information and settings related to its Rack Layout Manager functionality. You can access these via *Admin* > *Facilities*. The *Facilities* tab consists of a *View Settings* page, which contains the previously available RLM settings, and a *Rack Assignment* page.

The *Rack Assignment* page displays an overview of the devices managed by the Rack Layout Manager. A toggle button at the top allows you switch between showing only assigned devices or showing only devices that have not yet been assigned to a rack. If a device in the overview table is selected, additional options become available at the top:

- *Show in Rack*: Opens the rack view in a new card.
- *Assign*: Allows you to assign the selected device to a rack.
- *Auto Assign*: Launches an Automation script to automatically assign the selected device to a rack. See [Automatic rack assignment \[ID_24528\]\[ID_24543\]](#automatic-rack-assignment-id_24528id_24543).
- *Remove*: Removes the device from the rack it is currently assigned to.

#### Automatic rack assignment \[ID_24528\]\[ID_24543\]

It is now possible for administrators to configure a rack assignment script per CI type in order to allow devices to be automatically assigned to racks.

The automatic rack assignment scripts can be configured via *Admin* > *CI Types* > *Facilities*. This page contains a table where a script can be selected for each CI type. By default, the scripts you can select are located in the folder *DataMiner Solutions/IDP/CI Type Management/Facilities/Rack Assignment*. A different folder can be selected via *Admin* > *Settings*.

If a script is selected for a CI type in the facilities table, the completeness column in the table will indicate *100%* and it will be possible to enable automatic rack assignment for this CI type on the *Workflows* > *Automation* page.

Via *Admin* > *Facilities* > *Rack Assignment*, you can then launch the automatic rack assignment. To do so, you must select one or more elements in the table and click *Auto Assign*. This will launch a wizard that will check if automatic rack assignment is possible for all selected elements.

If an element has a CI type for which auto rack assignment is not enabled, the wizard will indicate that automatic assignment is not possible for this element. In that case, the wizard will not be able to perform the automatic assignment for any of the selected elements. As such, you will need to close the wizard and either make a selection that does not include the element in question, or make sure automatic rack assignment is possible for the element before running the wizard again.

The automatic rack assignment script can also be launched silently in automated workflows. In that case, the *IDP Information* property will be updated for elements that do not have automatic rack assignment enabled in order to create an audit trail.

## Changes in version 1.1.5

### Enhancements

#### Automation: New configuration management methods \[ID_23718\]

In order to provide access to all configuration management options in Automation scripts, new methods have been made available in the *Skyline.DataMiner.DataMinerSolutions.IDP.ConfigurationManagement* namespace.

#### CI type name validation now ignores casing \[ID_24395\]

To ensure that the name validation of CI types is in line with the regular validation for DataMiner element names, it will now no longer take casing into consideration. As such, it will for example not be possible to create a CI type "Cisco manager" if the CI type "Cisco Manager" already exists.

#### Notification of discovery interruption \[ID_24642\]

In case a discovery request is interrupted because the *DataMiner IDP Discovery* element is restarted, a message will now be displayed to notify the user that the discovery request was not completed.

In addition, in such a case, the progress indicated under *Most Recent Discoveries* in the *Inventory* > *Discovered* tab will mention *Interrupted* for the requests that were in progress or were not yet started at the time of the discovery element restart, so that it is clear that a new discovery request is needed to get complete results.

#### IDP app: 'Create Elements' option renamed to 'Automatically Create Elements After Discovery' \[ID_24728\]

In the *Admin* > *Provisioning* tab of the IDP app, the option *Create Elements* has been renamed to *Automatically Create Elements After Discovery*.

If this option is enabled, and the toggle button *Provisioning* is enabled on the *Workflow* > *Automation* tab, discovered elements are automatically provisioned. If this option is not enabled, discovered elements are not provisioned, regardless of the *Provisioning* toggle button setting.

#### IDP app: Custom IDP icon \[ID_24778\]

The IDP app now has a custom IDP icon, instead of the general Skyline icon.

#### CI type management script enhancements \[ID_24813\]

The following changes have been implemented to the CI type management script:

- When the first discovery identifier is added, the condition field is now filled in with "1".
- In the main window of the script, the label *Discovery Actions* has been replaced with *Discovery*.

### Fixes

#### Out of memory exception when discovery request has large IP range \[ID_24391\]

When the IP range in a discovery request was too large, it could occur that an out of memory exception was thrown.

#### Elements not added to Software tab when Software update/Software compliancy was enabled \[ID_24588\]

When *Software Update* or *Software Compliancy* was enabled for a CI type via *Workflows* > *Automation*, it could occur that the corresponding elements were not added to the *Software* tab.

#### Removing scan range not possible without Resource Manager license \[ID_24613\]

When you tried to remove a scan range on a system without a Resource Manager license, the scan range failed to be removed.

#### CI type management script issue \[ID_24813\]

In the CI type management script, if the provisioning configuration was edited, it could occur that the pop-up window showed *Based on device address*, even though the DMA was configured differently. Now the correct value will be displayed.

#### Rack Layout Manager: Incorrect scaling Visio drawings \[ID_24818\]

Previously, some RLM Visio drawings did not apply the correct scaling. Now all Visio drawings will be scaled to use the maximum width or height.

#### No element properties created on empty DMA \[ID_24835\]

In some cases, it could occur that no element properties were created if IDP was installed on an empty DMA.

#### Not possible to generate CI types after new IDP installation \[ID_24890\]

If IDP was installed on a DMA that did not yet contain any CI types, it could occur that it was not possible to generate CI types for the production protocols.
