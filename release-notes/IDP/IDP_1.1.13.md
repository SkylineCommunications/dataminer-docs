---
uid: IDP_1.1.13
---

# IDP 1.1.13

## New features

#### Process Automation: Take Configuration Backup activity \[ID_27919\]

To allow users to take a configuration backup using Process Automation, IDP now supports the *SLC IDP Take Configuration* *Backup* activity. This activity requires a node profile definition specifying the backup type (*Running* or *Startup*) and an input interface specifying the elements for which a backup should be taken (possible values: Element ID, Element Name, Element Property, IP Address, IP Address List, IP Address Range, and View).

When the activity starts, it runs the "Take backup script" configured in the CI type for each element in the input interface. If the activity is successful, a success response with *SLC_TakeConfigurationBackup_Result* gateway key is sent with the value *Success*. If the activity fails, the same gateway key is sent with the value *Fail*.

#### Support for process definition containing generic gateway in Process Automation wizard \[ID_29098\]

In the Process Automation wizard, you can now select a process definition containing one generic gateway. You can then modify it in the same way as when another process definition is selected, except that it is not possible to remove activities.

#### Scan range profile instances \[ID_29127\]

If IDP is configured to be used with Process Automation and the *Scan Range* profile definition is available in the Profiles module, a profile instance will now be created whenever a scan range is created. If a scan range is renamed, the corresponding profile instance will also be renamed, and when a scan range is removed, the corresponding profile instance will be removed.

Approximately every hour, all scan ranges will be checked to adapt the profile instances accordingly if necessary. You can also trigger this sync manually with the *Sync* button in the *Discovery Address Range* table on the *Admin* > *Discovery* > *Scan Ranges* page. However, note that this button will only be displayed if IDP is configured to be used with Process Automation.

#### Process Automation: Convert To Element activity \[ID_29201\]

To allow users to search for an element that contains a specific IP address and port, IDP now supports the *SLC IDP Convert To Element* activity.

The input interface for this activity contains the IP address and port to look for. The metadata SLC_DMEID can also be specified, containing an element ID in the format DMA ID/Element ID.

When the activity starts, it will check if SLC_DMEID metadata is specified. If it is, it will search for an element with specified ID. If SLC_DMEID metadata is not specified, the activity will search for an element matching the IP address and port in the input interface. If there are multiple matching elements, the first one will be selected.

The *SLC_IDP_Provisioning_ConvertToElement_Result* gateway key contains the status of the activity: *Success* if a matching element was found, and otherwise *Fail*.

#### IDP elements now hidden \[ID_29208\]

The IDP setup wizard will now set all elements used by DataMiner IDP to be hidden, except for the IDP app itself.

#### Process Automation: Convert To Scan Range activity \[ID_29248\]

To make it possible to convert an IP address into a scan range using Process Automation, IDP now supports the *SLC IDP Convert To Scan Range* activity.

The input interface for this activity contains the IP address that should be converted.

The *SLC_IDP_Discovery_ConvertToScanRange_Result* gateway key contains the status of the activity: *Success* if the conversion succeeded, and otherwise *Fail*.

#### PA wizard can now create processes without start profile instance selection \[ID_29312\]

Previously, it was only possible to create a process with the Process Automation wizard if a start profile instance was selected in the last step of the wizard. Now it is possible to create a process without selecting a start profile instance if the token activity contains the property *StartEventType* with value the *NoneStartEvent*. In that case, it will not be possible to add or delete the activity or to set it to be executed with a timer.

Note that this requires that the first interface of the first activity has the property *IsProfileInstanceOptional* set to *True*.

#### New Racks and Locations pages in IDP app \[ID_29320\]

In the IDP app, two new pages have been added to the *Admin* > *Facilities* tab:

- *Racks*: Displays an overview of all racks in the system, with basic editing possibilities.
- *Locations*: Displays an overview of all levels of facility management and all locations on each level in the system, with basic editing possibilities.

On both pages, *New* and *Edit* buttons are available above the overviews, which can be used to add an item or access advanced editing options for an item, respectively.

#### Configuration IP address/host and accepted IP addresses for smart-serial connection in CI type \[ID_29411\]

When you edit a CI type containing a smart-serial connection (by going to *Admin* > *CI types* > *Overview* in the IDP app, and clicking *Edit* for the CI type in the table), new options are now available to specify the IP address/host and accepted IP addresses. To configure these options, in the CI type wizard, click the *Configure* button next to *Provisioning* and then the *Details* button next to *Element Details*. Then select the *Server Mode* checkbox to see the new options.

The *IP Address/Host* option can be set either to *any* or to *127.0.0.1*, to indicate that the elements will be listening to requests from the network

The *Accepted IP Address* allows you to configure the IP addresses from which the elements will accept requests. It is possible to use the *\[IPAddress\]* placeholder here, which will be replaced by the IP address of an element provisioned using this CI type after a discovery. Alternatively, you can use an actual IP address, but this means that the same IP will be used in all elements that are provisioned using the CI type. This could be useful in case there is a central device that will make requests to all provisioned elements.

Note that DNS domain names are not supported for the *Accepted IP Address*. It is also not possible to add the same value twice.

#### CI types now support TLS connection \[ID_29427\]

When you create or edit a CI type with a serial or smart-serial connection with TCP/IP connection type, and you click the *Configure* button next to *Provisioning* and then the *Details* button next to *Element Details*, a new checkbox is now available that allows you to enable SSL/TLS support for any elements provisioned using the CI type. To also apply this for existing elements, reapply the CI type after you have modified it.

#### Support for IS-04 registry \[ID_29436\]\[ID_29462\]\[ID_29562\]

DataMiner IDP now supports the use of an IS-04 registry to provision and update elements. This is achieved using Process Automation.

The following new out-of-the box processes are available in the setup wizard:

- IDP IS-04 Provision New Nodes
- IDP IS-04 Update Existing Nodes

You can create these processes with the Process Automation wizard. When you do so, you cannot select a start token in the third step of the wizard. This is because these are processes with the start event type "NoneStartEvent” (see [PA wizard can now create processes without start profile instance selection \[ID_29312\]](#pa-wizard-can-now-create-processes-without-start-profile-instance-selection-id_29312)), which means that when the activation window starts for these processes, no token is initiated. This is achieved by means of a custom LSO script.

This script ensures that tokens are put in the processes by an element with the connector *AMWA NMOS IS-04 Registry*. This connector uses a web socket connection to connect to an IS-04 registry. When an IS-04 node is added to the IS-04 registry, the connector detects this and triggers the script *IDP_Register_IS04Nodes*.

When no element exists in the DMS for the node, the *IDP_Register_IS04Nodes* script will push the token into the process *IDP IS-04 Provision New Nodes*. If an element already exists, the script will push the token into the process *IDP IS-04 Update Existing Nodes*. An existing element is recognized by its element property *IS-04 Node GUID*. For this reason, this element property has to be filled in after provisioning by means of the Update Properties script. With the IP address and port of the element as its input, the Update Properties script can look up the node ID in the connector *AMWA NMOS IS-04 Registry* and fill in the element property on the newly provisioned element.

#### CI types: Support for WebSocket connections \[ID_29485\]

CI types now support protocols with connections of type WebSocket.

#### Support for prefix in CI type IPAddress field \[ID_29486\]

You can now configure a CI type with a prefix such as  "https://", "http://" or "wss://" in the *IPAddress* field. This prefix can also be used before the \[IPAddress\] placeholder. This can among others be used to create elements with HTTPS connections that use another port than the default 443 port for HTTPS connections.

#### Option to delete empty location and its sublocations \[ID_29541\]

In the IDP app, on the page *Admin* > *Facilities* > *Locations*, you can now remove a rack, aisle, room, floor or building (level) from the facility management locations, if no devices are assigned to it or to any of its sublocations. To do so, select the location, click *Edit*, and then click the *Delete* button in the pop-up window. The location and any sublocations will then be removed. If the location or a sublocation still contains devices, an error message will be displayed instead, to inform the user that all devices must be removed before the location can be removed.

## Changes

### Enhancements

#### Process Automation now uses ProfileHelper class instead of ProfileManagerHelper class \[ID_29035\]

As the *ProfileManagerHelper* class is now considered obsolete, the Process Automation code has been updated to use the *ProfileHelper* class instead.

#### Scan range creation criteria revised \[ID_29055\]

When a new scan range is created or a custom discovery is launched, a scan range will now only be considered valid if the following criteria are met:

- At least one IP address is specified in the first step of the scan range creation.
- At least one range is of type "included".
- The first range is of type "included".

#### Activities now inform PA of issues during execution \[ID_29178\]

To keep tokens from remaining in the queue unnecessarily, activities will now inform the Process Automation framework if issues occurred during activity execution.

#### Terminology in IDP app adjusted to improve consistency \[ID_29184\]

To improve consistency in the IDP app, on the *Admin* > *Settings* > *Configuration Management* page, the setting *Default Script Folder* has been renamed to *Update Script Folder*. In addition, in the CI type management wizard, the *Default* subtitle has been changed to *Update*, and the *Directory* box below this has been renamed to *Default Update File*.

#### Configuration update progress messages improved \[ID_29279\]

In the *Update Progress* column on the *Configuration* > *Update* tab of the IDP app, the messages that are displayed when a configuration update is run have been improved. Previously, these were the same as to restore a default configuration, which could be confusing.

#### Process Automation wizard improvements \[ID_29283\]

In the Process Automation wizard, profile parameters from an activity profile instance for which a value still has to be defined are now displayed above the *Show All* section. They will only be included within that section if a value is already defined. In addition, for discrete profile parameters, the display value will now be shown.

#### PA wizard: Token activity automatically selected \[ID_29384\]

When a new process is created with the Process Automation Wizard, in the third step of the wizard, the token activity is now automatically selected.

#### Discovery activity now supports volatile process profile instances \[ID_29391\]

The discovery activity now also supports volatile process profile instances.

#### IDP setup wizard now supports new activities \[ID_29450\]

In the IDP setup wizard, support has been added for the following activities:

- SLC IDP Take Configuration Backup
- SLC IDP Convert To Element
- SLC IDP Convert To Scan Range

The wizard will now create and configure the necessary resources and profile definitions for these activities.

#### Mandatory fields better indicated in Process Automation wizard \[ID_29518\]

In the Process Automation wizard, mandatory fields will now be indicated more clearly.

#### Unnecessary profile parameters removed from node profile definition for Delete Element activity \[ID_29559\]

The node profile definition for the Process Automation activity “SLC IDP Delete Element” no longer has the profile parameters *Element\_ Selection_Type* and *Element_Selection_Value*, as these are not required for this activity.

### Fixes

#### SLScripting handles increasing \[ID_29176\]

In some cases, it could occur that SLScripting handles kept increasing because the file and directory handles were not properly disposed of.

#### Exception when loading process profile instance \[ID_29390\]

In some cases, when process profile instance was loaded, an exception could be thrown.

#### Problem when running IDP setup wizard on system with existing IDP setup with Process Automation \[ID_29447\]

When the IDP setup wizard was run on a system that already contained IDP with Process Automation, an exception could be thrown by the *SRM_ServiceDefinitionImportExport* script.

#### Discovery: Problem when polling same OID with SNMPv1 and SNMPv2 \[ID_29484\]

If a CI type was configured to discover a device using either SNMPv1 or SNMPv2, and the SNMPv1 discovery failed, incorrect caching of the results caused the SNMPv2 discovery to fail as well.

#### Exception when removing element in rack assignment overview \[ID_29519\]

An exception could be thrown when you tried to remove an element on the *Admin* > *Facilities* > *Rack assignment* page of the IDP app.
