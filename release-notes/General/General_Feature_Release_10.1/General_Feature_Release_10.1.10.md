---
uid: General_Feature_Release_10.1.10
---

# General Feature Release 10.1.10

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### Improved average trending \[ID_28684\]

The following improvements have been implemented to average trending:

- Because of improved performance and throughput, you will now be able to activate average trending for a larger number of parameters.
- Previously, average trending was discouraged in case there were a lot of different instances of a specific parameter. This is no longer the case. You can now use average trending even if millions of instances of the parameter are polled.
- Unexpected gaps in trend graphs, e.g. because an element is started or stopped, or because a parameter is cleared, will now be prevented.
- Issues with history sets not being averaged, e.g. when an element had been recently restarted, will now be prevent.
- Average data will be available more quickly. When parameter changes are averaged from 00:00:00 to 00:05:00, the average point is now guaranteed to become available in the database between 00:06:00 and 00:07:00, while previously this could take up to 5 minutes or longer. However, note that this does not apply if the parameter changes were pushed as a history set.

However, note that this results in a number of breaking changes:

- Some special status trend points will no longer be used. For more detailed information, see [Special status trend points](https://community.dataminer.services/documentation/average-trending-calculation/#special-status-trend-points).

- In some specific cases, intervals between two average trend points are no longer guaranteed to be constant. For more information, see [Granularity of averaged trend data](https://community.dataminer.services/documentation/average-trending-calculation/#granularity-of-averaged-trend-data).

- The exception values of continuous (non-discrete) parameters are now averaged in a discrete manner. For more information, see [Protocol-defined exception values](https://community.dataminer.services/documentation/average-trending-calculation/#protocol-defined-exception-values).

#### DataMiner Object Model: New field descriptors \[ID_30583\]

Two special types of field descriptors have been added to the DataMiner Object Model:

- DomInstanceFieldDescriptor
- ElementFieldDescriptor

From now on, the following special types of field descriptors are available:

| Field descriptor | Function |
|--|--|
| AutoIncrementFieldDescriptor | Defines a field of which the value will automatically be incremented when saved. |
| DomInstanceFieldDescriptor | Defines a field that should contain the ID of a DomInstance. This descriptor also contains a ModuleId property, which defines where the instance can be found, and a DomDefinitionIds list property, which can be used to define whether DomInstances should be linked to the defined definitions. Note that the validity and existence of these properties is not checked. FieldValues are of type “Guid”. |
| ElementFieldDescriptor | Defines a field that should contain the ID of an element. The ID must be saved as a string using the “\[DMA ID\]/\[ELEMENT ID\]” format (e.g. “868/65874”). The descriptor contains a ViewIds list property, which can be used to specify the views in which the element is located. FieldValues are of type “string”. |
| GenericEnumFieldDescriptor | Defines a field that has a list of possible preset values. |
| ResourceFieldDescriptor | Defines a field that should contain the ID of a Resource. The descriptor contains a ResourcePoolIds property, which can be used to define the ResourcePools from which users can select a Resource. |
| ServiceDefinitionFieldDescriptor | Defines a field that should contain the ID of a ServiceDefinition. The descriptor contains a ServiceDefinitionFilter property, which has a FilterElement that can be used to determine the ServiceDefinitions that will be presented to the user. |
| StaticTextFieldDescriptor | Defines a field that should contain a static value defined by the StaticText property. |

#### Alarm templates - Smart baselines: Calculated baseline values outside the value range will automatically be set to the nearest value in the range \[ID_30704\]

When a calculated baseline value is outside the baseline value range, from now on, it will automatically be set to the nearest value in the range.

Examples:

- If the baseline value range is 10-50 and the calculated value is 7, it will be set to 10.
- If the baseline value range is 10-50 and the calculated value is 58, it will be set to 50.

### DMS Security

#### New user permission to send emails via DataMiner \[ID_30425\]

A new user permission *Email* > *Send via DataMiner System* is now available under the general user permissions in Users/Groups section of System Center. This user permission determines whether a user is allowed to send emails via the DataMiner System.

### DMS Protocols

#### New polling scheme polls SNMP tables by row [ID_30780]

A new polling scheme can now be used to poll SNMP tables.

This new scheme works similar to the GetNext/MultipleGet polling scheme, but polls by row instead of by column. In other words, similar to the GetNext/MultipleGet scheme, this new scheme will first poll the instances (if they have not been provided) and will then poll the data row by row.

To use this new polling scheme, add the “multipleGet” to the SNMP options of the SNMP table to be polled.

- If you specify the “multipleGet” keyword without additional arguments, by default 10 rows will be polled in a single run. See the following example:

    ```xml
    <SNMP>
      <Enabled>true</Enabled>
      <OID type="complete" options="instance;multipleGet">1.3.6.1.4.1.34086.2.2.17.5.1</OID>
    </SNMP>
    ```

- If you want to have a specific number of rows polled in a single run, you can specify the “multipleGet” keyword, followed by a colon (“:”) and the number of rows to be polled in a single run. In the following example, 5 rows will be polled in a single run:

    ```xml
    <SNMP>
      <Enabled>true</Enabled>
      <OID type="complete" options="instance;multipleGet:5">1.3.6.1.4.1.34086.2.2.17.5.1</OID>
    </SNMP>
    ```

> [!NOTE]
>
> - The multipleGet option cannot be used together with the multipleGetNext, multipleGetBulk and bulk options.
> - The multipleGet keyword can be used together with options like Subtable.
> - The notify protocol command NT_GET_BITRATE_DELTA, which can be launched from within a QAction, was expanded in DataMiner version 10.1.6 to be able to retrieve the delta times per row when polling an SNMP table. This functionality will now also work in conjunction with the new multipleGet option.

### DMS Cube

#### Visual Overview: History mode for parameter values of element shapes \[ID_30333\]

It is now possible to make an element shape in Visual Overview show the parameter values for a specific point in the past. This time and date can optionally be selected using another Visual Overview component.

To retrieve the value, DataMiner will use the trend record stored for the selected time. To know whether real-time or average trending should be retrieved, the latest trending configuration will be taken into consideration. If both types of trending are available, by default real-time trending will be used.

To configure this history mode, add the shape data *HistoryMode* to the element shape or to the entire page. The value of the shape data field should consist of a state indication and a timestamp, separated by a pipe character ("\|"). The *State* can be *On* or *Off*. *On* means history mode is active, *Off* means real-time alarm information should be shown instead. Both the state value and the timestamp value can be configured using placeholders.

For example:

| Shape data field | Value                              |
|------------------|------------------------------------|
| HistoryMode      | State=On\|TimeStamp=\[var:myTime\] |

A number of options can also be added to the *HistoryMode* shape, again using a pipe character (“\|”) as separator:

| HistoryMode option         | Description                                                                                                                                                                                                                                                                                     |
|----------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| NoDataValue=               | This option allows you to specify the text that should be displayed in case no trending is available. If this option is not specified, the default value “N/A” is displayed. For example: *State=On\|TimeStamp=\[var:myTime\]\|NoDataValue=\<No data available>* |
| TrendDataType              | This option allows you to determine which kind of trend data should be used, if available: *Realtime* (default), *Average* or *RealtimeAndAverage*.                                                |
| AverageTrendDataIndication | This option allows you to specify a prefix to the parameter value in case it represents an average value. By default, no prefix is shown. For example:  *State=On\|TimeStamp=\[var:myTime\]\|AverageTrendDataIndication=\[AVG\]*                            |

> [!NOTE]
>
> - You can override history mode on shape level. In case there are shapes within shapes, the lowest level will be checked first. However, the full shape data of this lowest level is used, so you must make sure that the shape data is fully configured even if you only want to change one option (e.g. NoDataValue).
> - At present, for history values no unit is displayed. In addition, only updating the element or parameter shape data will not update the history mode result.

If you are using a datetime control to set the date and time, use the *SetVarOptions* shape data and set the value to *Control= DateTime*. Optionally, you can also add *DateTimeCulture=* followed by *Current* or *Invariant*. The latter is the default value.

For example:

| Shape data field | Value                                     |
|------------------|-------------------------------------------|
| SetVar           | myTime                                    |
| SetVarOptions    | Control=DateTime\|DateTimeCulture=Current |

The following new placeholders are now also supported in an *Element* shape. These will only contain values in case history parameter values based on average trend data are displayed:

- \[average value\]
- \[minimum value\]
- \[maximum value\]

#### Aggregation rule conditions can now be specified in the form of a regular expression \[ID_30640\]

Aggregation rule conditions can now be specified in the form of a regular expression.

1. Set the condition type to “regular expression”.
1. Choose “by value” or “by reference”.

    - If you chose “by value” (i.e. the default setting), then enter a regular expression.
    - If you chose “by reference”, then select a single-value parameter of type “string” containing a regular expression.

#### DataMiner Cube will now take into account ResourceManagerEventMessages sent when ReservationInstance properties were updated \[ID_30668\]

As from DataMiner feature release version 10.1.9, a ResourceManagerEventMessage is sent next to a ReservationInstanceChangePropertiesEventMessage when a ReservationInstance property was updated using either ResourceManagerHelper#UpdateProperties or ResourceManagerHelper#SafelyUpdateProperties.

DataMiner Cube has now been adapted accordingly.

#### Visual Overview: New ChildrenFilter 'ResourceMapping' \[ID_30751\]

When, within a service context, child shapes are automatically generated, it is now possible to use a ResourceMapping filter. This will allow you to only show shapes that have a certain role (mapped, unmapped, inheritance) within the booking.

In a child shape, add a data field of type *ChildrenFilter*, and set its value to “ResourceMapping=”, followed by one or more roles (separated by commas). If you specify multiple roles, all shapes of which the roles match one of the specified roles will be shown.

See the following example.

| Shape data field | Value                                       |
|------------------|---------------------------------------------|
| ChildrenFilter   | ResourceMapping=mapped,unmapped,inheritance |

> [!NOTE]
> Within a data field of type *ChildrenFilter*, you can specify multiple filters separated by pipe characters (“\|”). If you do so, only shapes matching all specified filters will be shown.

#### Visual Overview: Linking an element shape to a resource that is using that element \[ID_30752\]

It is now possible to link an element shape to a resource that is using that element.

To link an element shape to the last-known resource using the element in question, add a data field of type “Options” and set its value to “UseResource=True” (default value is false).

| Shape data field | Value            |
|------------------|------------------|
| Options          | UseResource=True |

> [!NOTE]
>
> - Within a service instance connectivity chain, the elements will automatically be linked to the resource.
> - Children of an element shape in which the “UseResource” option is specified will automatically inherit this setting unless overridden.

##### Placeholders that can retrieve resource-related data

When a resource is linked to an element shape, you can use the following placeholders to retrieve data from that resource.

| Placeholder | Data |
|--|--|
| \[Element Name\] | The name of the resource’s function element, if such an element could be found. If none could be found, this placeholder will contain the name of the element linked to the element shape. |
| \[Function Name\] | The name of the resource function. |
| \[Name\] | The name of the element linked to the element shape. |
| \[Resource ID\] | The ID of the resource (GUID). |
| \[Resource Name\] | The name of the resource. |

#### Visual Overview: New \[ServiceDefinition:\] placeholder & new \[Reservation:\] placeholder property 'ServiceDefinitionID' \[ID_30757\]

##### New \[ServiceDefinition:\] placeholder

The new \[ServiceDefinition:\] placeholder allows you to retrieve one of the following properties of a service definition:

| Property | Description |
|--|--|
| Name | The name of the service definition. |
| Actions | The name of the scripts that are defined on the service definition. Names of multiple actions will be separated by colons (“:”). This will allows them to be inserted directly into e.g. a setvar shape. |
| Property=\<propertyName> | The value of any of the custom properties of the service definition. |

Full syntax: \[ServiceDefinition:\<ServiceDefinitionID>,\<Property>\]

##### New \[Reservation:\] placeholder property 'ServiceDefinitionID'

The \[Reservation:\] placeholder now allows you to retrieve the service definition ID of a specific booking.

Full syntax: \[Reservation:\<Service ID or Booking ID>,ServiceDefinitionID\]

### DMS Automation

#### Interactive Automation scripts: New 'TreeViewItemCheckingBehavior' property of TreeViewItem \[ID_29993\]\[ID_30603\]

You can now configure what happens when you select a tree view item in an interactive Automation script, using the new *TreeViewItemCheckingBehavior* enum property of the *TreeViewItem* object.

This property can have the following values:

- *FullRecursion*: All child items will automatically be selected when this item is selected, and vice versa.
- *None*: Only this item will be selected. The selection state of child items will not change. In addition, if all child items are selected, this tree view item will not be automatically selected.

Regardless of which type of behavior you choose, if one or more child items of a tree view item are selected, the checkbox of the tree view item will be colored.

For example:

```csharp
UIBuilder uib = new UIBuilder();
   uib.Title = "Treeview - Regular";
   uib.RequireResponse = true;
   uib.RowDefs = "*";
   uib.ColumnDefs = "*";
   UIBlockDefinition tree = new UIBlockDefinition();
   tree.Type = UIBlockType.TreeView;
   tree.Row = 0;
   tree.Column = 0;
   tree.DestVar = "treevar";
   tree.TreeViewItems = new List<TreeViewItem>
   {
      new TreeViewItem("Slapp", "Slapp (Nexus)", false, new List<TreeViewItem>
      {
         new TreeViewItem("Nitro", "Nitro (Squad)", false, new List<TreeViewItem>
         {
            new TreeViewItem("Brian", "Brian (Member)", false) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Gilles", "Gilles (Member)", true) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("KevinM", "KevinM  (Member)", true) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("KevinV", "KevinV  (Member)", false) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Seba", "Seba  (Member)", false) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Ward", "Ward  (Member)", true) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
         }) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
         new TreeViewItem("Nitro", "Nitro (Squad)", true, new List<TreeViewItem>
         {
            new TreeViewItem("Jordy", "Jordy (Member)") { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Jorge", "Jorge (Member)") { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Ronald", "Ronald (Member)") { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Victor", "Victor (Member)") { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Wim", "Wim (Member)") { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Quinten", "Quinten (Member)") { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None }
         }) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None }
     }) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None }
   };
   uib.AppendBlock(tree);
   _treeResults = _engine.ShowUI(uib);
```

#### Interactive Automation scripts: Input components now have a 'WantsOnFocusLost' property & other input component enhancements \[ID_30638\]

In an interactive Automation script that is used in the DataMiner web apps, the following components now have a *WantsOnFocusLost* property. If you set this property to true, then an *OnChange* event will be triggered when the component loses focus.

- Calendar
- Checkbox
- CheckboxList
- Dropdown
- Numeric
- Passwordbox
- RadioButtonList
- Textbox
- Time

Other enhancements:

- A Dropdown component will now keep the focus after an option was selected. This will enable users to still browse through the options using the arrow keys even when the options popup window is closed.
- In a Checkbox, a CheckboxList or a RadioButtonList component, users can now select or clear options using the space bar.
- In a CheckboxList or a RadioButtonList component, users can now go from one checkbox or radio button to another using the TAB keys.

#### Interactive Automation scripts: File selector component can now be configured to only allow a script to continue after a file has been uploaded \[ID_30728\]

In an interactive Automation script that is used in Dashboards, you can now configure a file selector component to only allow a script to continue after a file has been uploaded. To do so, set the property *IsRequired* to true.

For example:

```csharp
UIBlockDefinition uibDef = new UIBlockDefinition();
uibDef.Type = UIBlockType.FileSelector;
...
uibDef.IsRequired = true;
```

### DMS Web Services

#### Web Services API v1: SetParameter and SetParameterRow methods can now also be used to update parameters of enhanced services \[ID_30823\]

The SetParameter and SetParameterRow methods of the DataMiner Web Services API v1 can now also be used to update parameters of enhanced services.

### DMS Service & Resource Management

#### Automation - Service & Resource Management: Option to return time-dependent capabilities when requesting eligible resources \[ID_30576\]

When the eligible resources for a booking are requested, it is now possible to calculate all booked time-dependent capabilities for the eligible resources. For this purpose, the *CalculateAllCapabilities* flag should be set to true on *EligibleResourceContext*. This feature is intended to be used in the DataMiner Booking Manager app.

### DMS Mobile Gateway

#### Getting and setting the value of a table column parameter \[ID_30399\]

It is now possible to get and set values of table column parameters using text messages.

Syntax:

- GET:\<ElementName>:\<ParameterName>\|\<TableIndex>
- SET:\<ElementName>:\<ParameterName>\|\<TableIndex>:\<Value>

Examples:

- Use “GET:MyElement:MyParam\|10113” to get the value stored in row 10113 of parameter “MyParam” of element “MyElement”.
- Use “SET:MyElement:MyParam\|10113:100” to set the value stored in row 10113 of parameter “MyParam” of element “MyElement” to 100.

Using special characters:

- If an argument contains a colon (“:”), a backslash character (“\\”) must be put in front of it. For example, the command “SET:MyElement:MyParam\|a\\:b:100” will set the value stored in row a:b to 100.
- If the table index contains a pipe character (“\|”), a backslash character (“\\”) must be put in front of it. For example, the command “SET:MyElement:MyParam\|a\\:b\\\|c:100” will set the value stored in row a:b\|c to value 100.

> [!WARNING]
> BREAKING CHANGE: Due to the introduction of this new syntax, it is no longer possible to get and set single-value parameters of which the name contains pipe characters.

## Changes

### Enhancements

#### Security enhancements \[ID_30124\] \[ID_30345\] \[ID_30479\] \[ID_30570\] \[ID_30581\] \[ID_30597\] \[ID_30600\] \[ID_30604\] \[ID_30786\]

A number of security enhancements have been made.

#### Improved performance when including/excluding elements in services based on alarm or element alarm state \[ID_30303\]

Performance has improved when elements are dynamically included or excluded in a service based on alarm state or element alarm state.

#### Cassandra cluster: SLA tables now stored in one table \[ID_30369\]

If one Cassandra cluster database is used for the entire DMS, the SLA database tables will now all be stored in one table instead of in a table per SLA. This will improve the performance of Cassandra.

#### Profile Manager: Objects added, updated or deleted in bulk will now be grouped into one single event \[ID_30465\]

When profile parameters, profile instances or profile definitions are added, updated or deleted in bulk, from now on, a single event listing all objects will be sent. Up to now, a separate event would be sent for every object.

To prevent events from getting too large, the maximum amount of objects listed in one event has by default been set to 100. Events that contain more than 100 objects will be split into multiple events.

Also, due to a number of enhancements, overall performance has increased when deleting profile objects in bulk.

#### DataMiner Cube: Enhanced performance of Booking Manager and Resource Manager \[ID_30483\]

In DataMiner Cube, the Resource Manager and the Booking Manager always run side by side. Up to now, when the Booking Manager was being used, in some cases, data would also be requested from the Resource Manager. A number of enhancements have now been made to prevent this. As a result, overall performance of both the Booking Manager and the Resource Manager has increased.

#### Profiles module: Parameter list improvements \[ID_30530\]

A number of small improvements have been implemented to the list of parameters in the Profiles module:

- When you open the list of parameters, by default no parameter will be selected.
- When you create a new parameter, that parameter is automatically selected.
- It is now possible to search for a parameter in the list by typing its first characters.

#### Service & Resource Management: Interface state calculation for virtual function interfaces disabled \[ID_30537\]

As the interfaces of virtual functions are generated from a table that cannot be monitored, the interface state calculation for these interfaces is now disabled. This may result in improved performance.

#### Service & Resource Management: Improved performance when processing virtual functions \[ID_30585\]

A number of enhancements have been implemented to improve performance when processing virtual functions.

#### Improved logging in case encrypted password in DB.xml cannot be retrieved \[ID_30614\]

If a password is encrypted in DB.xml but for some reason (e.g. syncing issue) DataMiner is unable to retrieve it, this will now be indicated more clearly in the logging.

#### Ticket migration from Cassandra to Elasticsearch: Notice generated when unsupported characters are found in TicketFieldDescriptors \[ID_30624\]

When unsupported characters are found in TicketFieldDescriptors at the start of a ticket data migration from Cassandra to Elasticsearch, from now on,

- a notice with a link to a “known issues” Dojo article will be generated,
- an entry listing the invalid TicketFieldDescriptors will be added to the SLMigrationManager.txt log file, and
- the migration will be aborted.

See also: [Migration of Ticketing data from Cassandra to Elasticsearch fails](xref:KI_Migration_of_Ticketing_data_from_Cassandra_to_Elasticsearch_fails)

#### Web apps: Notification when reconnect happens in background \[ID_30628\]

When a reconnect happens in the background in the DataMiner web apps, a notification will now be displayed to inform the user.

#### SLAnalytics: pollingtime values in ParameterInfo records can no longer be equal to zero \[ID_30729\]

In a Cassandra database, from now on, pollingTime values in ParameterInfo records will no longer be allowed to be equal to zero. pollingTime values between 0 and 1 seconds will automatically be updated to 1 before they are stored in the database.

#### Dashboards app - Table components: Selecting multiple rows on an Apple Mac computer \[ID_30734\]

When working inside a table component using an Apple Mac computer, up to now, it was not possible to select multiple rows. From now on, users of an Apple Mac computer will be able to select multiple table rows while holding down the *Command* key.

Also, on an Apple Mac computer, it will now be possible to sort a table on multiple columns by clicking column headers while holding down the *Command* key.

#### SLElement: Enhanced performance when looking up linked rows after a foreign key has changed \[ID_30747\]

Due to a number of enhancements, overall performance of SLElement has increased when looking up linked rows after a foreign key has changed.

#### Dashboards app - GQI: Enhanced performance when fetching trend statistics \[ID_30783\]

Due to a number of enhancements, overall performance has increased when fetching trend statistics.

### Fixes

#### SRM module not starting after Failover switch \[ID_29169\]

In some rare cases, after a Failover switch, it could occur that an SRM module could not be started.

#### Slow initial synchronization of services in DMS \[ID_30074\]

In some cases, it could occur that the initial synchronization of services in a DMS was slow because of unnecessary errors generated in the SLDMS process. Usually, an error similar to the following was logged:

```txt
2021/06/03 01:00:00.302|SLDMS.txt|SLDMS.exe 10.1.2118.668|13524|26072|CSystem::ResolveServicePaths|ERR|-1|Failed resolving hosting DMA info for 10.10.80.20 and service RT_ServiceCreationDelete_66_2021_06_03_00_58
```

#### DataMiner Cube: Missing alarms in Active alarms tab \[ID_30126\]

In some rare cases, after connecting to a busy system, it could occur that alarms were missing in the Active alarms tab in the Alarm Console.

#### No longer possible to disable a Failover setup \[ID_30458\]

In some cases, it would no longer be possible to disable a Failover setup.

From now on, when you disable a Failover setup

- the offline agent will be reset to factory settings using SLReset, and
- the online agent will be reconfigured to become a standalone agent.

#### Not possible to log in to web app using SAML \[ID_30469\]

In some cases, it could occur that it was not possible to log in to the Dashboards or Monitoring app using SAML.

#### Dashboards app: Query with filter on value discrete parameter not working correctly \[ID_30486\]

If a query in a dashboard was filtered on the value of a discrete parameter, it could occur that the filter was not executed correctly. This happened because the filter used the display value of the parameter instead of the actual value.

#### Profile parameter with mediation snippet incorrectly shown as changed \[ID_30530\]

When a profile parameter with a mediation snippet was loaded initially, it would incorrectly be shown as having unsaved changes.

#### Problem with conditional monitoring after alarm template update \[ID_30531\]

When an alarm template was refreshed in the SLElement process, e.g. because the alarm template was modified or the baseline changed, it could occur that conditional monitoring was ignored for standalone parameters. Because of this, if a parameter was not monitored because the condition for this was met, it was shown as monitored regardless.

#### Profiles module: Discrete capability parameter showed actual values instead of display values \[ID_30533\]

In the Profiles module, if a capability parameter of type Discrete was configured in a profile instance, the drop-down box for this parameter showed the actual discrete values instead of the display values.

#### Standalone Cassandra Backup Tool: Problem when using the clearsnapshot command without -name argument \[ID_30549\]

When you used the clearsnapshot command without -name argument in order to clear all snapshots, in some cases, an exception could be thrown.

#### Dashboards app: Table incorrectly identified by display name instead of ID \[ID_30591\] \[ID_30684\]

Previously, if a query in a dashboard used the data source "Get parameter table by ID", the table was identified by its display name. However, as this is not necessarily unique in a protocol, this could cause incorrect results. New queries will now us the table ID as the identifier, though they will display the name in the UI.

#### Insufficient information in exception message in case of invalid characters in dictionary keys \[ID_30602\]

When an exception was thrown because invalid characters were used in dictionary keys, it could occur that the message did not include all invalid characters, but only the string array type name.

#### Automation: CheckboxList and RadiobuttonList not decoding "\\" correctly \[ID_30605\]

In an interactive Automation script, it could occur that the *CheckboxList* and *RadiobuttonList* components did not correctly decode a backslash ("\\") character.

#### Automation: Problems with datetime filters in scripts \[ID_30611\]

Several issues have been resolved in case data is retrieved using a datetime filter in a script:

- DataMiner will now translate between UTC and local time when necessary. Previously, data objects could be in UTC time while the filter used local time.

- If *DateTime.Kind* is unspecified, now no action is performed.

#### Information about running elements missing in SLProtocol logging \[ID_30612\]

Since DataMiner 9.6.0/9.6.1, information about running elements could be missing in the SLProtocol logging.

#### Problem with SLNet due to unhandled exception \[ID_30626\]

In some rare cases, an unhandled exception could cause a problem in the SLNet process.

#### DataMiner Cube: /Bootstrap command line argument not copying files \[ID_30632\]

In some cases, it could occur that the */Bootstrap* command line argument for the DataMiner Cube launcher did not copy the files *DataMinerCube.exe.config* and *CubeLauncherConfig.json* to the target location.

#### DataMiner Cube - Spectrum Analysis: Problem when retrieved client session data contained duplicate keys \[ID_30644\]

When you open a spectrum analyzer element in Cube, it will retrieve all client sessions of that spectrum element. Up to now, when the retrieved client session data contained duplicate keys, an exception could be thrown. From now on, a log entry will be generated instead.

#### GetAlarmFilterResponse and GetTrendFilterResponse messages caused protocol buffer serialization errors \[ID_30650\]

In some cases, it could occur that the *GetAlarmFilterResponse* and *GetTrendFilterResponse* messages failed to be serialized even though these were marked as eligible for protocol buffer serialization. An error similar to the following could be displayed in the Cube logging:

```txt
Message : Index was outside the bounds of the array.
Exception : (Code: 0x80131508) Skyline.DataMiner.Net.Exceptions.DataMinerException: Index was outside the bounds of the array. ---> System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at System.Collections.Generic.List\`1.Add(T item)
   at Skyline.DataMiner.Net.Serialization.ProtoBufSerializationManager.Log(String method, String text)
   at Skyline.DataMiner.Net.Serialization.ProtoBufSerializationManager.ProtoBufPackMessage(DMSMessage rawMessage)
```

The scenarios where these messages cannot be serialized will now be handled better, so that they can no longer cause errors. In addition, to make it easier to troubleshoot errors with protocol buffer serialization, a new *SLProtobufSerialization.txt* log file is now available.

#### DataMiner Cube - Resources app: Not possible to link virtual function resources to elements of which the protocol version was set to 'production' \[ID_30655\]

In the Resources app, it is possible to create virtual function resources that are linked to compatible elements. Up to now, in some cases, it was not possible to link virtual function resources to elements of which the protocol version was set to “production”.

#### DataMiner Cube: Problem with table filters \[ID_30658\]

In Data Display and Visual Overview, in some cases, table filters could yield incorrect results when they contained numeric column filters with a “\<=”, “=”, or “=>” operator.

#### DataMiner Cube: No reports or alarm heatlines shown for view table parameters \[ID_30667\]

Up to now, for view table parameters, no reports were shown on the details page for the parameter in DataMiner Cube. In addition, no alarm heatline was shown for these parameters in trend graphs.

#### Spelling error in exception when minimum software version requirements for app package not met \[ID_30672\]

When an app package was installed on a DMA but the minimum software version requirements were not met, the exception message contained a spelling error.

```txt
Could not install the package because it requires DataMiner version {appInfo.MinDmaVersion}, but this agent us running version {dataMinerVersion}.
```

#### Dashboards app: Trace not displayed for spectrum buffer \[ID_30686\]

If a Spectrum analyzer component in the Dashboards app was used to visualize a spectrum buffer, it could occur that the buffer trace was not displayed.

#### Visual Overview: Property value not shown in shape text \[ID_30696\]

If an element shape was configured with property shape data and contained "\*" as its shape text, it could occur that the property value was not shown even though it was available.

#### Dashboards app: All pages of query initially loaded in table component \[ID_30697\]

If a table component showed a query with multiple pages of data, it could occur that all pages were initially fetched instead of only the first page.

#### Dashboards app: State component showed GQI query ID instead of display name \[ID_30702\]

The State component would incorrectly show the ID of a GQI query instead of its display name.

From now on, when you select the *Display query name* option in the *Layout* tab of the State component, the component will show the display name of the query.

#### Deadlock in SLDataGateway could cause data to not get written to the database \[ID_30717\]

In some cases, a deadlock in the SLDataGateway process could cause e.g. correlation rule data to not get written to the database and remain in memory indefinitely.

#### Problem with Protocol.ShowInformationMessage() method \[ID_30722\]

In some cases, the Protocol.ShowInformationMessage() method would not work properly.

#### CRC parameter with LengthType 'fixed' and RawType 'other', 'text' or 'numeric text' would incorrectly always be set to 0x20 or 0x30 \[ID_30730\]

When a CRC parameter with LengthType “fixed” and RawType “other”, “text” or “numeric text” was used in a command, it would incorrectly always be set to 0x20 characters for parameter of type “string” or 0x30 characters for parameters of type “double”.

#### Problem with SLDataMiner when using alarm templates with a monitoring schedule \[ID_30732\]

In some cases, an error could occur in SLDataMiner when alarm templates with a monitoring schedule were being used.

#### Problem with SLDataMiner when an element was restarted while a protocol exporting DVE or function protocols was being uploaded \[ID_30743\]

In some cases, an error could occur in SLDataMIner when an element was restarted while a protocol exporting DVE or function protocols was being uploaded.

#### DataMiner Cube - Visual Overview: Cube could become unresponsive while retrieving service states \[ID_30762\]

When a visual overview with at least one service shape was open when you opened a Cube, and the initial service states had not yet been received, in some cases, Cube could become unresponsive while retrieving the service states.

#### Dashboards - Button panel component: \[ID_30788\]

When a button panel component retrieved parameter data using a GetParameter call, in some cases, the following error would be thrown:

```txt
Parameter 'options' is not of type Skyline.DataMiner.Web.Common.v1.DMAGetParameterOptions.
```

#### DataMiner Cube: Problem when hovering the mouse pointer over an alarm storm warning \[ID_30799\]

When, during an alarm storm, you hovered the mouse pointer over the alarm storm warning, in some cases, an exception could be thrown.

#### DataMiner Cube - Alarm Console: Comments containing a new line would be displayed incorrectly \[ID_30801\]

When an alarm contains one or more comments, you can right-click it and select “View comments” to see all comments in the alarm tree in question. In that list, up to now, comments containing a new line would not be displayed correctly.

#### DataMiner Cube - Bookings app: check added of elastic support when retrieving virtual functions \[ID_30814\]

When, in DataMiner Cube, you opened the Bookings app while being connected to a DataMiner Agent without an Elasticsearch database, in some cases, an error could occur when trying to retrieve virtual function definitions. From now on, Cube will only retrieve virtual function definitions when it is connected to a DataMiner Agent with an Elasticsearch database.

#### DataMiner Cube - Settings: Boolean settings were either not saved or incorrectly saved \[ID_30952\]

When, in the Settings window, you changed the value of a boolean setting (i.e. a setting that can be set to true or false), in some cases, the new value would either not be saved or saved incorrectly.
