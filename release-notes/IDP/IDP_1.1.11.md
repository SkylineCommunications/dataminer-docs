---
uid: IDP_1.1.11
---

# IDP 1.1.11

## New features

#### New Processes tab instead of Workflows tab \[ID_28230\]

The *Workflows*tab of the IDP app has now been renamed to the *Processes* tab.

If IDP uses Process Automation, the *Bookings*Visual Overview page of the SRM Booking Manager will be displayed on the *Processes*> *Schedules*tab. Otherwise, the same activity overview is displayed as on the *Workflows* tab in the previous version of the app.

#### Possibility to take configuration backup or restore default configuration in bulk \[ID_28315\]

It is now possible to take a configuration backup or to restore a default configuration on multiple devices at the same time. To do so, go to the *Configuration*> *Summary*tab of the IDP app, select multiple devices and click *Backup*or *Default*, respectively.

For a configuration backup operation, IDP will check if *Take Backup*is enabled for all devices (via *Processes*> *Automation*). If it is not, no action will be performed until this is enabled. If it is enabled, you will be asked to specify the configuration type: *Startup*, *Running*, or *Golden*.

For a restore default backup operation, IDP will check if *Restore Default*is enabled for all devices (via *Processes*> *Automation*). If it is not, no action will be performed until this is enabled.

#### Possible to perform software update in bulk \[ID_28332\]

It is now possible to perform a software update on multiple devices at the same time. When you do so, IDP will validate if *Software Update*is enabled for all devices (via *Processes*> *Automation*). If it is not, no action will be performed until this is enabled. If it is, the software update script will be launched per CI type of the selected elements. If no CI type exists for one or more elements, no action will be performed until the CI type is created.

#### New buttons on Software tab \[ID_28414\]

On the *Software*tab of the IDP app, the following three buttons have been added above the *Software Update* table:

- *Show Details*: Only available if a single element is selected. Displays the software details for the element, such as the expected software version, detected software version, software image location and deployed software version.
- *Update*: Opens a wizard to perform a software update on the selected elements.
- *Check compliancy*: Checks if the selected elements use the expected software version.

#### New Managed and Discovered Connectivity subtabs \[ID_28488\]

The *Connectivity* tab of the IDP app now has the following subtabs:

- *Managed*: Displays an overview of existing managed connections.
- *Discovered*: Displays an overview of discovered connections, and allows easy DCF provisioning.

#### Inventory \> Imported tab removed \[ID_28554\]

The *Inventory*> *Imported* tab has been removed from the IDP app, as this tab was not used.

#### Info tab renamed and redesigned \[ID_28560\]

The *Info*tab of the IDP app has been renamed to the *About*tab. It no longer contains subtabs. The tab now provides access to the IDP Help page, to the documentation of the Provisioning API, and to information about the installed IDP application and its component versions.

## Changes

### Enhancements

#### Minimum DataMiner version increased + setup wizard improvements \[ID_27818\]

The minimum DataMiner version required for DataMiner IDP is now DataMiner 10.0.0 CU6.

In addition, some improvements have been implemented to the UI of the IDP setup wizard.

#### DataMiner IDP Connectivity improvements \[ID_27822\]

On the *Provision*data page of the *DataMiner IDP Connectivity*element, two new tables have been added:

- *Unmanaged Connections*: Lists the connections that are ready to be provisioned.
- *Interface Properties*: Lists the DCF interface properties. An interface property in this table can be provisioned either when a connection is provisioned or when the *Provision*button is clicked for that property.

In addition, the *Managed Connections*table on the *General*data page of the *DataMiner IDP Connectivity* element now lists the provisioned connections.

After the connectivity component of IDP has received a request, the following things can now happen next:

- If all connections for the element are known, the DCF connections will be provisioned automatically and there will be no entries for the element in the *Connections* table.
- If not all connections are known in both directions, there will be some entries for the element in the *Connections*table and the unknown connections will be displayed in the *Unmanaged Connections* table, where they can be provisioned manually.
- If no connections can be mapped to connections reported by other elements, all connections for the element will still be listed in the *Connections* table.

Finally, the Connectivity API has also been extended so that interface properties can be provided when a DCF connection is reported. The method *AddOrUpdateInterfaceProperties*can be used to provide DCF interface properties without specifying a connection.

#### Only required fields displayed for SNMPv3 connections in CI type configuration \[ID_27846\]

When you configure the SNMPv3 connection setup for a CI type via *Admin*> *CI Types*> *Element Details*, now only the required fields are displayed, depending on the Security Level and Protocol configuration. For example, if Security Level and Protocol are set to None, only the User Name must be specified, but if Security Level and Protocol are set to AuthPriv, the User Name, Authentication Password and Encryption Password must be specified.

#### Improved information in case configuration backup fails because of exception \[ID_27929\]

In case a configuration backup fails because of an exception, on the *Configuration*> *Summary*tab of the IDP app, the *Update Progress*column will now display the reason why the backup failed.

#### Default alarm and trend template names modified \[ID_28187\]

The default alarm and trend templates for the different elements used by DataMiner IDP have been renamed to *Alarm_Default*and *Template_Default*, respectively.

> [!NOTE]
> If you update an existing IDP installation to this version and you want to continue to use the default templates provided with future updates, you will need to update the template names manually for each element used by DataMiner IDP.

#### Setup wizard: Password fields filled in automatically if user has already been configured \[ID_28334\]

In the IDP setup wizard, if an IDP user is assigned that has already been configured, the password fields will now be filled in automatically.

#### Setup wizard: 'localhost' now retained as binding address for provisioning \[ID_28393\]

If localhost is configured as the binding address for provisioning during IDP setup, the setup wizard will no longer replace this with the hostname of the machine.

#### Support for multiple devices without IP address for same CI type \[ID_28395\]

The managed inventory now supports multiple devices without an IP address for the same CI type. On the *Inventory*> *Unmanaged*tab, you can now add more than one element with a virtual protocol using the same CI type.

#### Improved feedback when enabling Discovery, Provisioning or Software Compliancy is not yet possible \[ID_28428\]

When you attempt to enable the *Discovery*, *Provisioning*or *Software Compliancy*options on the *Processes*> *Automation*tab but additional configuration is required before these can be enabled, a user-friendly message will now be displayed to clarify what still needs to be done.

#### IDP components no longer added to element license count \[ID_28464\]

The following elements, which are used as IDP components, are no longer added to the element license count of a DMA:

- DataMiner IDP
- DataMiner IDP CI Types
- DataMiner IDP Configuration
- DataMiner IDP Connectivity
- DataMiner IDP Discovery
- DataMiner IDP Provisioning
- DataMiner IDP Rack Layout Manager

> [!NOTE]
> This feature requires DataMiner 10.1.1 or higher.

#### Compliancy check now done automatically after software upgrade \[ID_28479\]

If *Software Compliancy*is enabled for a specific CI type, after a software upgrade, IDP will now immediately check if the software upgrade was applied and update the *Status* column.

### Fixes

#### CI type issues in case of empty provisioning configuration \[ID_27959\]

If the provisioning configuration of a CI type was empty, the following issues could occur:

- A problem could occur when the CI type was parsed.
- An incorrect exception could be thrown when the CI type was used to create an element.

#### Empty change detection file after taking configuration backup \[ID_27966\]

If the method *StoreResultAndChangeDetection*was used in a script to take a configuration backup, and *ConfigurationBackup.DataType*was set to *LocationPath*, it could occur that the change detection file was empty.

#### Status information not updated after default backup was restored \[ID_27972\]

In some cases, it could occur that the *Update Status*column on the *Configuration*> *Summary*tab was not updated when a default backup had been restored.

#### Restoring default configuration not possible when Take Backup was disabled \[ID_28296\]

If *Take Backup*was disabled on the *Processes*> *Automation*tab, restoring a default configuration was also not possible.

#### Provisioned element not removed from Discovered Elements table \[ID_28555\]

When an element was provisioned from the *Discovered Elements*table (on the *Inventory*> *Discovered* tab), it could occur that the element was not removed from the table.

#### Source DCF ID used for both source and destination of generated connection \[ID_28609\]

When a connection was created, it could occur that source and destination interface were the same because the source DCF ID was used for both interfaces.

Connections will now be created with the correct source and destination DCF interface. In addition, the DataMiner IDP Port ID and DataMiner IDP Interface Type default properties will now be added to the destination interface.
