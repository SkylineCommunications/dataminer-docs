---
uid: General_Feature_Release_10.1.6
---

# General Feature Release 10.1.6

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### New alarm table field on MySQL and SQL Server databases: ExtraStatusId \[ID_29374\]

On MySQL and Microsoft SQL Server databases, the alarm table now has an extra field of type BIGINT: ExtraStatusId.

> [!NOTE]
>
> - This change will cause a small increase in latency when retrieving alarms from the database.
> - From now on, using a filter with an AlarmFilterItemExtraStatus in the GetAlarmDetailsFromDbMessage from within an Automation script will not work correctly in conjunction with a MySQL or Microsoft SQL Server database.

#### SimulationHelper API now allows loading, enabling and disabling element simulations at run-time \[ID_29517\]

Up to now, loading new element simulations always required a DataMiner restart. Now, the SimulationHelper API will allow you to load, enable and disable element simulations at run-time from within protocol QActions or Automation scripts.

Construction:

```csharp
SimulationHelper(Func<DMSMessage[], DMSMessage[]> messageHandler)
```

- Loading all simulation files stored in the C:\\Skyline DataMiner\\Simulations folder of a specified DMA

    ```csharp
    void LoadSimulations(int dataMinerId)
    ```

- Enabling an element simulation

    ```csharp
    void EnableSimulation(int hostingDataMinerId, int dataMinerId, int elementId)
    ```

- Disabling an element simulation

    ```csharp
    void DisableSimulation(int hostingDataMinerId, int dataMinerId, int elementId)
    ```

Example on how to use this in an Automation script:

```csharp
var simulationHelper = new SimulationHelper(Engine.SLNet.SendMessages);
simulationHelper.LoadSimulations();
```

#### Alarm storm mode for clearable alarms \[ID_29637\]

A protection has been added to avoid reduced performance of the system when an alarm storm happens that causes there to be a large number of clearable alarms at the same time. By default, when there are more than 1000 clearable alarm trees on a DMA, the newly generated clearable alarms will be closed instead of clearable. Once the number of clearable alarm trees has dropped to less than 100, this protection mode is lifted and newly generated alarms will be clearable again.

> [!NOTE]
> In DataMiner.xml, you can customize the above-mentioned default values for the minimum and maximum threshold with the min and max attributes of the DataMiner.ClearableAlarmStormProtection tag.
>
> If you change these settings, you must do so on every DMA in a cluster, as they are not automatically synchronized.

### DMS Protocols

#### DataMiner Connectivity Framework: DCF interfaces can now be marked internal \[ID_29326\] \[ID_29438\]

In an element protocol, it is now possible to make a distinction between

- internal DCF interfaces (i.e. virtual interfaces used within the protocol), and
- external DCF interfaces (i.e. physical interfaces that will appear in interface lists in the UI).

By default, all DCF interfaces are considered external. Interfaces that should be considered internal, have to be explicitly marked as internal. See the following example.

```xml
<Protocol xmlns="http://www.skyline.be/protocol">
  ...
  <ParameterGroups>
    <Group id="1" name="500_in" type="in" dynamicId="500" dynamicIndex="*" isInternal="true"/>
    <Group id="2" name="1000_out" type="out" dynamicId="1000" dynamicIndex="*"/>
    <Group id="3" name="1500_inout" type="inout" dynamicId="1500" dynamicIndex="*"/>
    <Group id="4" name="2000_inout" type="inout" dynamicId="2000" dynamicIndex="*"/>
    <Group id="5" name="fixed" type="inout" isInternal="true"/>
  </ParameterGroups>
  ...
```

#### SNMP polling: Retrieving polling delta time per row \[ID_29445\]

The notify protocol command NT_GET_BITRATE_DELTA, which can be launched from within a QAction, has been expanded to be able to retrieve the delta times per row when polling an SNMP table. However, this will only work for the multipleGetNext and multipleGetBulk polling schemes since only these polling schemes retrieve entire rows per request.

It is advised to enable this feature at startup using the notify protocol command NT_SET_BITRATE_DELTA_INDEX_TRACKING with either a single parameter ID or multiple parameter IDs. This information will not be saved and will only be kept as long as the element is running. See the following examples. The first call will enable the tracking for parameters 100 and 200. The second call will disable the tracking for parameter 100.

- `protocol.NotifyProtocol(/*NT_SET_BITRATE_DELTA_INDEX_TRACKING*/ 448, new int[] {100, 200}, true);`
- `protocol.NotifyProtocol(/*NT_SET_BITRATE_DELTA_INDEX_TRACKING*/ 448, 100, false);`

Once tracking has been enabled, the information can be retrieved by using the notify protocol command NT_GET_BITRATE_DELTA with a string as second argument. In the following example, the command will return the delta value for the specified key (“1”) of the specified parameter (100). If you set the second argument to an empty string (“”), then the command will return all currently tracked keys for the parameter in question.

`object delta = protocol.NotifyProtocol(269 /*NT_GET_BITRATE_DELTA*/, 100, "1");`

The information will be returned in the following format. If only a single key is requested, the initial array will have a length of 1:

`object[] { object[] {string key1, int delta1}, object[] {string key2, int delta2} }`

> [!NOTE]
>
> - If the requested key could not be found, or if no polling happened since the tracking was enabled, an empty array will be returned.
> - If there were no 2 poll cycles, or if the requested key was only present in 1 poll cycle, then the delta value will be returned as -1.

#### Protocols - QActions: #define ALARM_SQUASHING \[ID_29549\]

The preprocessor directive “#define ALARM_SQUASHING” will now automatically be added to each QAction when compiling a protocol.

In QActions, all code related to alarm squashing should be enclosed as follows:

```csharp
#if ALARM_SQUASHING
    // Code specific for alarm squashing (DataMiner 10.1.0 and later)
#else
    // Code for DataMiner 10.0.0 and earlier
#endif
```

This allows protocols that contain alarm squashing functionality to also be compiled on DataMiner versions that do not support alarm squashing.

### DMS Cube

#### Visual Overview: AlarmSettings tag of MaintenanceSettings.xml has new elementTimeoutMode attribute \[ID_29498\]

Next to the serviceTimeoutMode and viewTimeoutMode attributes, the AlarmSettings tag of the MaintenanceSettings.xml file now also has an elementTimeoutMode attribute.

Similar to the other two attributes, it can be set to one of the following values.

| Value | Description |
|--|--|
| displayTimeout | Shapes linked to elements will only show the timeout color. The current alarm color will not be shown. (Default setting.) |
| displayBoth | Shapes linked to elements will show both the current alarm color and the timeout color. The timeout color will be shown as a hatch pattern. |

#### Visual Overview: Prevent a child shape from inheriting the service context of its parent shape \[ID_29503\]

By default, an element shape that is a child of another element shape will inherit the service context of its parent when it does not have a service context of its own.

If you want to prevent this from happening, from now on, you can add the AllowInheritance option to the child shape and set its value to false.

#### Visual Overview: New option to keep real-time charts from showing exception values in labels \[ID_29504\]

In the *ParametersOptions* shape data field for a parameter chart showing real-time values, you can now use the *VisualizeExceptions=false* option to keep the display value for exception values from being shown in a label.

| Shape data field  | Value                                                                     |
|-------------------|---------------------------------------------------------------------------|
| ParametersOptions | VisualizeExceptions=true (default behavior)<br> VisualizeExceptions=false |

#### Profiles app: New profile instance update errors \[ID_29546\]

When a ProfileInstance is updated while it is being used by one or more bookings, the following additional errors can now be returned.

When a ProfileInstance is updated without quarantine being forced (i.e. with forceQuarantine set to false):

- If no instances need to be quarantined, the update will be applied and the following warning will be returned:

  - A warning of type ProfileInstanceChangeCausedBookingReconfiguration, listing the running reservations that were reconfigured because of the update.

- If instances need to be quarantined, the update will not proceed and the following errors will be returned:

  - An error with reason ReservationsMustMovedToQuarantine, listing the reservations that need to be quarantined as well as the usages.
  - An error with reason ReservationsMustBeReconfigured, listing the bookings that will be affected by the ProfileInstance update.

When a ProfileInstance is updated with quarantine being forced (i.e. with forceQuarantine set to true), the update will proceed and the following TraceData will be returned:

- A warning of type ReservationInstancesMovedToQuarantine, listing the reservations and the usages that were quarantined.
- A warning of type ProfileInstanceChangeCausedBookingReconfiguration, listing the reservations that were reconfigured because of the update.

#### Profiles app: Profile parameters can now have settings configured \[ID_29580\]

It is now possible to configure a profile parameter to be hidden in scripts using the profile, with a new *Hide from scripts* checkbox for profile definitions and profile instances in the Profiles app.

#### EPM: Hiding chains and chain fields based on parameter values \[ID_29640\]\[ID_29656\]

DataMiner Cube now supports hiding specific chains (normal chains and search chains) and chain fields in an EPM topology based on parameter values, in the sidebar as well as in EPM Manager cards.

Below, you can find examples of how to configure conditional visibility in an element protocol.

##### Chain visibility

Example:

```xml
<Chain>
  <Display>
    <Visibility default=”false”>
      <Standalone pid=”8”>
        <Value>1</Value>
        <Value>2</Value>
      </Standalone>
    </Visibility>
  </Display>
</Chain>
```

> [!NOTE]
>
> - The default visibility defines the visibility when none of the conditions are met. Default: true
> - Multiple \<Standalone> elements are possible. Each one has to contain a parameter ID that refers to the trigger parameter and a set of values that toggle the visibility to the opposite setting of the one defined in the default attribute.

##### Chain field visibility

Example:

```xml
<Chain>
  <Field>
    <Display>
      <Selection>
        <Visibility default=”false”>
          <Standalone pid=”18”>
            <Value>1</Value>
            <Value>2</Value>
          </Standalone>
        </Visibility>
      </Selection>
    </Display>
  </Field>
</Chain>
```

> [!NOTE]
>
> - The default visibility defines the visibility when none of the conditions are met. Default: true
> - Multiple \<Standalone> elements are possible. Each one has to contain a parameter ID that refers to the trigger parameter and a set of values that toggle the visibility to the opposite setting of the one defined in the default attribute.

##### Search chain visibility

Example:

```xml
<SearchChain>
  <Display>
    <Visibility default=”false”>
      <Standalone pid=”8”>
        <Value>1</Value>
        <Value>2</Value>
      </Standalone>
    </Visibility>
  </Display>
</SearchChain>
```

> [!NOTE]
>
> - The default visibility defines the visibility when none of the conditions are met. Default: true
> - Multiple \<Standalone> elements are possible. Each one has to contain a parameter ID that refers to the trigger parameter and a set of values that toggle the visibility to the opposite setting of the one defined in the default attribute.

### DMS Reports & Dashboards

#### Dashboards app - GQI: New 'DCF connections' data source \[ID_25827\]\[ID_26491\]\[ID_26744\] \[ID_29505\]\[ID_29703\]

In the Generic Query Interface, a new “DCF connections” data source is now available. It will return all DCF connections in the DMS.

> [!NOTE]
>
> - The “Is Internal” column indicates whether a connection has been marked internal (i.e. virtual) or external (i.e. physical).
> - External connections are configured both on the source element and the destination element. Hence, each external connection will be listed twice.
> - Connections of which both the source element and the destination element are stopped will not be listed.
> - Connections of which only the destination element is stopped will be listed once.

#### Dashboards app - State, Gauge and Ring components: Enhancements \[ID_28984\]

A number of enhancements have been made to the Gauge and Ring components:

- As to the Ring component, labels are now displayed underneath the ring.
- The Gauge and Ring components can now display the configured range (minimum and maximum value). Also, it is now possible to configure a custom range in each of those components.
- The Gauge and Ring components are now more in line with the State component. When configuring these components, it is now possible to select one of three designs (small, large and autosize) and to specify the alignment (left, center and right).

#### Dashboards app - GQI: Regular expressions in column filters will now be converted to standard table filters \[ID_29458\]

From now on, when regular expressions with the following structure are found in column filters, they will be converted to standard table filters.

| Regular expressions with the following structure ... | will be converted to ...                                 |
|------------------------------------------------------|----------------------------------------------------------|
| ^(Value01\|Value02\|Value03)$                        | (XXX == Value01) OR (XXX == Value02) OR (XXX == Value03) |

#### Dashboards app: Enhanced data source counters in edit panel \[ID_29495\]

In the edit panel, up to now, the counter next to each data source would indicate the total number of draggable items in that data source that matched the applied filters. From now on, each data source counter will instead indicate the amount of items in the next level only.

Imagine a DataMiner Agent with the following view tree:

Root

- child 1

  - child 3
  - child 4

- child 2

  - child 5

From now on...

- the counter of the views data source will show “(1)”, i.e. the root, and
- the counter of the root view data source will show “(2)”, i.e. child view 1 and 2.

> [!NOTE]
> The counter of the parameters data source will show the total amount of parameters.

#### Dashboards app - GQI: Aggregated and manipulated columns now have metadata \[ID_29494\] \[ID_29514\]

Metadata will now be added to columns created by an aggregation or manipulation operation within the GQI environment. This metadata will provide information regarding the operation (aggregation or manipulation) and the columns involved.

#### Dashboards app - Line chart component: New 'Fill graph' and 'Stack trend lines' options \[ID_29527\]

When configuring a line chart component, you will now find two new options in the *Styling and Information* section of the *Layout* tab.

- **Fill graph**: When you select this option, the space underneath the line will be filled with the line color.
- **Stack trend lines**: When you select this option, all lines in a graph will be stacked on top of each other.

  > [!NOTE]
  > This option is not compatible with the *Show min/max shading*, *Show minimum*, and *Show maximum* options. When you select the *Stack trend lines* option, those options will be disabled and hidden.

Also, the following chart components have been renamed:

| Old name   | New name           |
|------------|--------------------|
| Bar chart  | Column & bar chart |
| Line chart | Line & area chart  |
| Pie        | Pie & donut chart  |

#### Dashboards app: State, Gauge and Ring components can now be used as feeds by other components \[ID_29570\]\[ID_29650\]

The State, Gauge and Ring components can now be used as feeds by other components.

In other words, components using a State, Gauge and Ring component as a feed will now be able to ingest the item (element, redundancy group, service, view, protocol or index) selected in that State, Gauge or Ring component.

### DMS Automation

#### Automation scripts: #define ALARM_SQUASHING \[ID_29613\]

The preprocessor directive “#define ALARM_SQUASHING” will now automatically be added to each C# block of an Automation script.

In C# blocks, all code related to alarm squashing should be enclosed as follows:

```csharp
#if ALARM_SQUASHING
    // Code specific for alarm squashing (DataMiner 10.1.0 and later)
#else
    // Code for DataMiner 10.0.0 and earlier
#endif
```

This allows C# blocks that contain alarm squashing functionality to also be compiled on DataMiner versions that do not support alarm squashing.

> [!NOTE]
> Up to now, the following directives would only be added to QActions. These will now also be added to C# blocks of Automation scripts.
>
> - #define DBInfo
> - #define DCFv1

### DMS Web Services

#### BREAKING CHANGE: Web Services API v0 is now disabled by default \[ID_29453\]

The Web Services API v0 is now disabled by default. It is recommended to use the Web Services API v1 instead (SOAP or JSON).

> [!NOTE]
> If necessary, the Web Services API v0 can be enabled by adding the following key inside the \<appSettings> element of the C:\\Skyline DataMiner\\Webpages\\API\\Web.config file:
>
> *\<add key="enableLegacyV0Interface" value="true"/>*

### DMS Mobile apps

#### Ticketing app: Executing scripts when a ticket is created, updated or deleted \[ID_29191\]

The TicketFieldResolver now includes a TicketFieldResolverSettings object, which can contain a ExecuteScriptOnTicketActionSettings object.

In an ExecuteScriptOnTicketActionSettings object, you can specify the names of the scripts that should be executed each time a ticket is created, updated or deleted. See the following example.

```csharp
var settings = new TicketFieldResolverSettings()
{
    ScriptSettings = new ExecuteScriptOnTicketActionSettings()
    {
        OnCreate = onCreateScriptName,
        OnDelete = onDeleteScriptName,
        OnUpdate = onUpdateScriptName
    }
};
var fieldResolver = new TicketFieldResolver(Guid.NewGuid())
{
    Settings = settings,
    TicketStateFieldDescriptor = { IsRequired = false }
};
```

The scripts must have an OnTicketCrud entry point defined. See the following example. This way, you can indicate the action, ticket and TicketFieldResolver for which the script was triggered.

```csharp
[AutomationEntryPoint(AutomationEntryPointType.Types.OnTicketCrud)]
public void OnTicketCrud(Engine engine, TicketID ticketId, CrudType crudType)
{
    engine.GenerateInformation($"Script triggered for {crudType} action on Ticket with ID: {ticketId.TID}")
}
```

### DMS Service & Resource Management

#### ResourceUsageDetails object now has a ConcurrencyLeft property \[ID_29592\]

The ResourceUsageDetails object now has a ConcurrencyLeft property.

When, in the ResourceManagerHelper class, you use the GetEligibleResources method, the returned ResourceUsageDetails object will now include a ConcurrencyLeft property, which will indicate the amount of concurrency left for the resource in question.

When ResourceUsageDetails is equal to null, ConcurrencyLeft will be equal to 0.

#### Export and importing ServiceProfileDefinitions and ServiceProfileInstances \[ID_29673\]

Using the ProfileHelper, it is now possible to export and import ServiceProfileInstances and ServiceProfileDefinitions.

##### Exporting ServiceProfileDefinitions and ServiceProfileInstances

The ExportServiceProfiles method allows you to export ServiceProfileDefinitions and ServiceProfileInstances. See the following example.

```csharp
var profileHelper = new ProfileHelper(engine.SendSLNetMessages);
var definitionsToExport = new List<Guid>(){ ... };
var instancesToExport = new List<Guid>(){ ... };
var exportResult = profileHelper.ImportExport.ExportServiceProfiles(definitionsToExport, instancesToExport);
```

As shown in the example above, two lists have to be provided:

- A list containing the IDs of the ServiceProfileDefinitions to be exported
- A list containing the IDs of the ServiceProfileInstances to be exported

Based on the information in those lists, the following data will be exported:

- All existing ServiceProfileDefinitions of which the ID is found in the first list.
- All existing ServiceProfileInstances of which the ID is found in the second list.
- All ServiceProfileInstances that are linked to the ServiceProfileDefinitions found in the first list.

> [!NOTE]
>
> - IDs of non-existing objects will be ignored.
> - If you only want to export the ServiceProfileInstances, you can leave the definitionsToExport list empty.

The ExportServiceProfiles method returns a ServiceProfilesExportResult object that contains the following data:

| Property                              | Type                             | Description                                                                  |
|---------------------------------------|----------------------------------|------------------------------------------------------------------------------|
| ZippedData                            | byte\[\]                         | A ZIP file containing all the exported data.                                 |
| ExportedServiceProfileDefinitions | List\<ServiceProfilesObjectInfo> | All ServiceProfileDefinitions that were successfully exported (ID and name). |
| ExportedServiceProfileInstances   | List\<ServiceProfilesObjectInfo> | All ServiceProfileInstances that were successfully exported (ID and name).   |

> [!NOTE]
>
> - When something goes wrong during an export operation, an unknown error will be added to the TraceData. which can be retrieved using profileHelper.ImportExport.GetTraceDataLastCall().
> - To pinpoint any non-existing objects, you can compare the list of IDs you provided to the list of IDs that was returned.
> - When two empty lists are passed to the export method, an ArgumentException will be thrown.

##### Importing ServiceProfileDefinitions and ServiceProfileInstances

The ImportServiceProfiles method allows you to import ServiceProfileDefinitions and ServiceProfileInstances. See the following example.

```csharp
var profileHelper = new ProfileHelper(engine.SendSLNetMessages);
byte[] zippedData = ...;
var importResult = profileHelper.ImportExport.ImportServiceProfiles(zippedData);
```

During an import operation, the objects are first unzipped from the byte array and then saved to the database after a number of compatibility checks.

Checks performed before saving a ServiceProfileDefinition:

- When a ServiceProfileDefinition already exists with the same name but a different ID, the ServiceProfileDefinition will not be imported and an error with reason ServiceProfileDefinitionNameInUse will be returned.
- When not all ProfileParameters referenced in the NodeDefinitionConfiguration exist, the ServiceProfileDefinition will not be imported and an error with reason ServiceProfileDefinitionRefersToNonExistingParameters will be returned.

Checks performed before saving a ServiceProfileInstance:

- When a ServiceProfileInstance already exist with the same name but a different ID, the ServiceProfileInstance will not be imported and an error with reason ServiceProfileInstanceNameInUse will be returned.
- When not all ParameterOverrides on the NodeInstanceConfigurations and InterfaceConfigurations refer to existing ProfileParameters, the ServiceProfileInstance will not be imported and an error with reason ServiceProfileInstanceRefersToNonExistingParameters will be returned.
- When not all NodeInstanceConfigurations and InterfaceConfigurations refer to existing ProfileInstances, the ServiceProfileInstance will not be imported and an error with reason ServiceProfileInstanceRefersToNonExistingProfileInstances will be returned.

The ImportServiceProfiles method returns a ServiceProfilesImportResult object that contains the following data:

| Property                              | Type                             | Description                                                                  |
|---------------------------------------|----------------------------------|------------------------------------------------------------------------------|
| TraceData                             | TraceData                        | All errors that occurred when importing the objects.                         |
| ImportedServiceProfileDefinitions | List\<ServiceProfilesObjectInfo> | All ServiceProfileDefinitions that were successfully imported (ID and name). |
| ImportedServiceProfileInstances   | List\<ServiceProfilesObjectInfo> | All ServiceProfileInstances that were successfully imported (ID and name).   |

> [!NOTE]
>
> - The TraceData returned by profileHelper.ImportExport.GetTraceDataLastCall() will match the TraceData included in the ServiceProfilesImportResult object.
> - If you want to know why an object was not imported, you can check the TraceData.
> - When an empty byte array is passed to the import method, an ArgumentException will be thrown.

##### ServiceProfilesImportError

When an object cannot be saved to the database during an import operation, a ServiceProfilesImportError will be added to the TraceData. Below, you can find the list of all possible error reasons.

| Error reason | Description |
|--|--|
| Unknown | An unknown error occurred. |
| GeneralFailure | An unexpected exception occurred while importing. The zipped data that was provided is probably invalid.<br> - Exception: The full exception message. |
| UnrecognizedType | The zip file contained an object with an unrecognized type.<br> - EntryName: The name of the unrecognized entry. |
| ExtractingJsonFailed | Something went wrong when trying to extract the JSON data associated with an entry.<br> - Exception: The exception that occurred while extracting.<br> - ObjectType: The type of the entry for which the JSON data was extracted.<br> - ObjectId: The ID of the entry for which the JSON data was extracted. |
| DeserializationFailed | Something went wrong when trying to deserialize the JSON data.<br> - Exception: The exception that occurred while deserializing.<br> - ObjectType: The type of the entry for which the JSON data was deserialized.<br> - ObjectId: The ID of the entry for which the JSON data was deserialized. |
| ErrorOccuredSavingServiceProfileDefinition | An error occurred while saving the ServiceProfileDefinition.<br> - ServiceProfileDefinitionError: The error message.<br> - ObjectId: The ID of the ServiceProfileDefinition.<br> - ObjectName: The name of the ServiceProfileDefinition. |
| ErrorOccuredSavingServiceProfileInstance | An error occurred while saving the ServiceProfileInstance.<br> - ServiceProfileInstanceError: The error message.<br> - ObjectId: The ID of the ServiceProfileInstance.<br> - ObjectName: The name of the ServiceProfileInstance. |
| ServiceProfileDefinitionNameInUse | The name of a ServiceProfileDefinition that is being imported is being used by another ServiceProfileDefinition.<br> - ObjectId: The ID of the ServiceProfileDefinition that is being imported.<br> - ObjectName: The name of the ServiceProfileDefinition that is being imported.<br> - ConflictingId: The ID of the ServiceProfileDefinition that is using the same name.<br> - ConflictingName: The name that is being used. |
| ServiceProfileDefinitionRefersToNonExistingParameters | The NodeDefinitionConfiguration of a NodeDefinition references parameters that do not exist in this system.<br> - ObjectId: The ID of the ServiceProfileDefinition that is being imported.<br> - ObjectName: The name of the ServiceProfileDefinition that is being imported.<br> - MissingIds: The IDs of the missing parameters. |
| ServiceProfileInstanceNameInUse | The name of a ServiceProfileInstance that is being imported is being used by another ServiceProfileInstance.<br> - ObjectId: The ID of the ServiceProfileInstance that is being imported.<br> - ObjectName: The name of the ServiceProfileInstance that is being imported.<br> - ConflictingId: The ID of the ServiceProfileInstance that is using the same name.<br> - ConflictingName: The name that is being used. |
| ServiceProfileInstanceRefersToNonExistingParameters | Either the NodeInstanceConfiguration or the InterfaceConfiguration contains parameter overrides that refer to parameters that do not exist in the system.<br> - ObjectId: The ID of the ServiceProfileInstance that is being imported.<br> - ObjectName: The name of the ServiceProfileInstance that is being imported.<br> - MissingIds: The IDs of the missing parameters. |
| ServiceProfileInstanceRefersToNonExistingProfileInstances | Either the NodeInstanceConfiguration or the InterfaceConfiguration contains references to ProfileInstances that do not exist in this system.<br> - ObjectId: The ID of the ServiceProfileInstance that is being imported.<br> - ObjectName: The name of the ServiceProfileInstance that is being imported.<br> - MissingIds: The IDs of the missing ProfileInstances. |

### DMS tools

#### Standalone Elasticsearch Cluster Installer will no longer automatically configure TLS and security \[ID_29113\]

From now on, the Standalone Elasticsearch Cluster Installer tool will no longer automatically configure TLS and security.

For instructions on how to install this manually, see [Client-server TLS encryption](xref:Security_Elasticsearch#client-server-tls-encryption).

#### Standalone Elastic Backup tool will now have to be used to restore a backup of an Elasticsearch database \[ID_29677\]

When you take a backup of a DataMiner Agent, you can opt to also take a backup of its Elasticsearch database. However, as the latter will in most cases be a cluster, automatically restoring an Elasticsearch backup when restoring a DataMiner Agent is not advisable.

From now on, even when a DataMiner backup includes an Elasticsearch backup, the latter will not be automatically restored when the DataMiner backup is restored. Restoring an Elasticsearch backup will now have to be done using the Standalone Elastic Backup tool.

For more information on the Standalone Elastic Backup tool, see [Standalone Elastic Backup Tool](xref:Standalone_Elastic_Backup_Tool).

## Changes

### Enhancements

#### DMS.xml now supports using hostnames instead of IP addresses \[ID_28775\]

From now on, the DMS.xml file also supports using hostnames instead of IP addresses.

#### DataMiner Cube - Services app: Validation of service profile definition names and service profile instance names is now consistent with the name validation routines used in the other SRM apps \[ID_29155\]

In the Services app, the validation of service profile definition names and service profile instance names has now been made consistent with the name validation routines used in the other SRM apps (e.g. Profiles, Resources, Functions, etc.).

#### DataMiner Cube - Visual Overview: Viewport and Navigate variables of a Resource Manager timeline will now be read and applied upon opening \[ID_29299\]

When, in Visual Overview, you create a shape that should display the Resource Manager timeline by adding a shape data field of type Component set to “Reservations” or “Bookings”, the Navigate and Viewport session variables allow you to control navigation and zooming within the timeline.

- The Navigate variable can be used to automatically navigate to a specified time range.
- The Viewport variable can be used to zoom to a specified time range and to visualize the time range to which you zoomed manually.

From now on, both variables can be processed immediately upon opening a visual overview with a Resource Manager timeline.

- Setting the Navigate variable using a page-level InitVar will make the timeline navigate immediately to the chosen time slot and clear the Navigate variable.
- The Viewport variable will always be read upon opening the Resource Manager timeline. In other words, if a session variable already exists in the scope in question (e.g. when the time line was opened while using the global variable scope), the timeline will automatically zoom to the last-known view port.

> [!NOTE]
> The Navigate variable will be processed after the Viewport variable.

#### DataMiner Cube - SLAnalytics: Enhanced handling of errors that occurred at startup \[ID_29311\]

In DataMiner Cube, from now on, when errors occurred while SLAnalytics was starting up its different features, a message box will be displayed, listing the features that could not be started.

For more information about the listed errors, users can then check the SLAnalytics logging.

#### DataMiner Cube - Service & Resource Management: Enhanced performance \[ID_29398\]

Due to a number of enhancements, overall performance of the different Service & Resource Management modules has increased.

#### Dashboards app - PDF reports: Data overflow warnings will now be added at the bottom of the email body \[ID_29417\]

Up to now, when a data overflow was detected while generating a PDF report, a warning would be added to the “Report” section, which is closed by default. From now on, data overflow warnings will be added at the bottom of the email body, below the “Report” section. This will allow users to immediately notice the warnings when they open the email message.

#### Mobile apps: All timespan controls now support timespan grouping \[ID_29441\]

All timespan controls of all mobile apps (e.g. Monitoring, Jobs, Ticketing, Dashboards, etc.) now support timespan grouping.

#### Jobs app: Tool tips added to section definition settings \[ID_29443\]

The job section definition settings “Color”, “Icon” and “Allow Multiple Instances” now have tool tips that indicate that they are linked to the job domain and will not affect other referenced job section definitions in other domains.

#### Mobile apps - Visual Overview: Linking shapes to webpages \[ID_29444\]

When you link a shape to a webpage using a shape data field of type *Link*, that page will be opened each time a user clicks that shape. This feature will now also work on visual overviews in mobile apps (e.g. Dashboards, Monitoring, etc.).

#### DataMiner Cube - Visual Overview: Enhanced performance when loading and sorting children shapes \[ID_29448\]

Due to a number of enhancements, overall performance has increased when loading and sorting children shapes.

#### Dashboards app - GQI: Enhanced performance when executing large queries \[ID_29473\]

Due to a number of enhancements, overall performance has increased, especially when executing large queries.

#### Enhancements made to the method that decides which subscriptions to forward to other agents in the DMS \[ID_29490\]

A number of enhancements have been made to the method that decides which subscriptions to forward to other agents in the DMS. These enhancements will considerably reduce SLNet CPE usage, especially on systems with a large number of active subscriptions.

#### Ticketing app: Enhancements \[ID_29492\]

A number of enhancements have been made to the Ticketing app, especially with regard to masked domains.

- When a masked domain is deleted, all tickets associated with that domain will now also be deleted.
- On the Configuration page, masked domains will now be marked with a special icon.
- When a masked domain is opened via a URL, a warning will now be displayed, indicating that the domain is masked. Also, no edit buttons will appear.
- When you open the create ticket window or edit ticket window via a URL to create or edit a ticket from a masked domain, a warning will now be displayed, and all fields of that ticket will be disabled.

#### DataMiner Cube: Enhancements with regard to dragging, sizing and positioning of undocked windows and cards \[ID_29508\]

DataMiner Cube automatically scales each window based on the monitor it is displayed on. A number of enhancements have now been made, especially with regard to the dragging, sizing and positioning of undocked windows and cards.

Sizing:

- When a window is undocked via a drag operation, it will take the same size as the docked window.
- When a window is undocking via SHIFT-Click or via the Undock context menu action, it will take a size based on the type of window. If no specific size is provided (e.g. in case of an element card), the default size will be used (i.e. 80% of the screen size).
- Window size range: From 600x400 (minimum) to 80% of the screen (maximum)

Positioning:

- When a window is undocked, it will be centered on the Cube’s main window.
- Undocked windows will respect the screen boundaries and be confined to one screen.
- When a window is undocked via a drag operation, it will correctly follow the mouse cursor and initiate a window drag that can immediately snap to screen borders.

#### Increased SLNet startup performance due to DNS lookup enhancements \[ID_29522\]

Due to a number of DNS lookup enhancements, SLNet startup performance has increased.

#### Notice will now appear in the Alarm Console when the initial synchronization of a DMA fails \[ID_29532\]

When, after adding a DMA to the DataMiner System, the initial synchronization of that agent fails, a notice will now appear in the Alarm Console.

Also, a number of protective measures have been added to prevent an agent that has not yet completed its full synchronization from being synchronized at midnight.

#### Dashboards app: Enhanced performance when opening a dashboard \[ID_29548\]

Overall performance has increased when opening a dashboard.

When you opened a dashboard, up to now, its edit panel would already be loaded in the background. From now on, the edit panel will only be loaded when you enter edit mode.

#### Elasticsearch: Support for NotRegex filters \[ID_29567\]

DataMiner now supports the use of NotRegex filters in Elasticsearch.

#### DataMiner Cube - Visual Overview: Service child shapes will now be updated instead of recreated when a dynamic part changes \[ID_29568\]

When a series of service child shapes contained a dynamic part (e.g. ChildrenFilter, ChildrenSource, etc.), up to now, all those child shapes would be recreated each time one of those dynamic parts changed. From now on, when a dynamic part changes, the child shapes will be updated instead of being recreated.

#### DVE elements notifications no longer added to SLNetCOM Notification Stack \[ID_29601\]

On DataMiner startup and hourly at report generation, a batch of notifications gets forwarded between DataMiner modules, ending up on the SLNetCOM Notification Stack. Up to now, two such notifications were also forwarded for every DVE element. These will now no longer be sent.

#### SLNetCom notification thread will now only start ignoring messages after a grace period has passed \[ID_29631\]

When the SLNetCom notification thread reaches a certain threshold (defined by MaxStackSLNetCOMNotifications), the DMA assumes something is wrong and stops processing messages, requiring a restart. However, in some cases, this threshold can be reached even when nothing is wrong.

In order to prevent this, a grace period has now been introduced. When the number of SLNetCom notification messages reaches a peak, the DMA will only start ignoring messages when the number of messages on the stack is equal or greater than the threshold during the entire grace period.

Using the SLNetClientTest tool, you can specify this grace period by configuring the SLNetCOMNotificationsStackExceedsThresholdGracePeriodInMin setting (default value: 1 minute).

#### SLNet will now start up asynchronously in a background thread \[ID_29633\]

From now on, SLNet will start up asynchronously in a background thread.

#### Dashboards app - GQI: Enhanced performance when executing queries due to ability to detect redundant operations \[ID_29636\]

GQI is now able to detect any redundant operations contained within a query. As a result, overall performance has increased when executing queries.

#### DataMiner Cube - Element Connections app: Mechanism used to delete connections between a destination parameter and a non-virtual source parameter has been optimized \[ID_29653\]

Due to a number of enhancements made to the Element Connections app, the mechanism used to delete connections between a destination parameter and a non-virtual source parameter has been optimized.

#### Dashboards app - State component: Enhanced auto-size behavior \[ID_29654\]

When, in the *Layout* tab of the State component, you select “Auto size” in the *Advanced \> Style* section, an attempt will now always be made to fill up the entire component area with the information to be displayed.

Also, a number of other enhancements have been made with regard to auto-sizing.

#### SLDMS.xml will no longer be refreshed each time SLDataMiner.xml is updated \[ID_29664\]

Up to now, each time SLDataMiner.xml was updated, SLDMS.xml would also be refreshed. From now on, this will no longer happen.

#### DataMiner Cube - Surveyor: Enhanced performance when loading services \[ID_29715\]

Due to a number of enhancements, especially with regard to the loading of services into the Surveyor, overall performance of DataMiner Cube has increased when starting up.

#### SLDMS will now perform DNS lookups using 'getaddrinfo' instead of 'gethostbyname' \[ID_29740\]

From now on, SLDMS will perform DNS lookups using the getaddrinfo function instead of the deprecated gethostbyname function.

### Fixes

#### DataMiner Cube - Visual Overview: DCF connections of hidden shapes would incorrectly still be visible \[ID_28930\]

Up to now, DCF connections of shapes that were hidden because of a condition would incorrectly still be visible. From now on, any connection that is linked to a shape that is hidden will no longer be displayed.

Also, hidden shapes will no longer be taken into account when grouping shapes.

#### DataMiner Cube - Visual Overview: IDOfSelection session variable would not get updated when selected rows were removed or the selection was cleared in a ListView component \[ID_29057\]

When you select one or more rows in a ListView component, the IDs or GUIDs of the selected items are stored in the IdOfSelection session variable.

Up to now, when a selected row was removed or when the selection was cleared in any way, in some cases, the contents of the IdOfSelection session variable would not get updated.

#### DataMiner Cube - Trending: Extra data point would incorrectly be exported to CSV \[ID_29212\]

When you exported average trend data to a CSV file, in some cases, extra data points would incorrectly be added to the exported trend data.

#### Protocols: Problem with SLProtocol when the save attribute of a table parameter was incorrectly set to 'true' \[ID_29214\]

When, in a protocol.xml file, the save attribute of a table parameter was incorrectly set to “true”, in some rare cases, an error could occur in SLProtocol.

#### Suggestion indices would incorrectly not get deleted when an Elasticsearch logger table without custom naming was deleted \[ID_29223\]

When an Elasticsearch logger table without custom naming was deleted, the suggestion indices would incorrectly not get deleted.

#### Dashboards app - Pivot table component: Problem when adding indices \[ID_29253\]

When indices were added to a pivot table component, in some cases, the component would not get updated correctly and a spinner icon would appear in its Settings tab.

#### At DMA startup, NT_CLEAN_SUBSCRIPTION_FOR_STOPPED_ELEMENT would incorrectly be called before all elements were fully loaded \[ID_29257\]

When a DataMiner Agent was started in a DataMiner System, in some cases, errors would be logged due to NT_CLEAN_SUBSCRIPTION_FOR_STOPPED_ELEMENT being called before all element were fully loaded.

#### DataMiner Cube: No search results when using an element card search box on a system with an Elasticsearch database \[ID_29310\]

When using an element card search box on a system with an Elasticsearch database, in some cases, no search results would appear.

#### Interactive Automation scripts: 'continue script' action triggered after the script had already been detached \[ID_29357\]

In some rare cases, a “continue script” action could incorrectly be triggered after the script in question had already been detached.

#### Automation: UIBuilder properties MaxWidth and MaxHeight would incorrectly not get applied to interactive Automation script pop-up windows \[ID_29361\]

In some cases, the UIBuilder properties “MaxWidth” and “MaxHeight” would incorrectly not get applied to interactive Automation script pop-up windows.

#### Incorrect data could be returned during a migration from MySQL to Cassandra \[ID_29385\]

Due to a problem with certain COM calls, in some cases, incorrect data could be returned during a migration from MySQL to Cassandra.

#### Jobs app: Problem when sorting on a field added to the default job section \[ID_29386\]

In some cases, an error could occur when you sorted the jobs list on a field that had been added to the default section.

#### Dashboards app: Input boxes would extend beyond the borders of the screen \[ID_29406\]

When configuring certain components, a number of input boxes would not resize correctly. Instead, they would extend beyond the borders of the screen.

#### Dashboards app - GQI: Filters would not be applied when requesting aggregated values from an Elasticsearch logger table \[ID_29439\]

In some cases, filters in GQI queries would not be applied when requesting aggregated values from an Elasticsearch logger table. This would cause the values to be aggregated over the entire table instead of a subset of that table.

#### Jobs app: Name of default job section would incorrectly be set to 'DefaultJobDomain' when the section was updated \[ID_29460\]

When the default section was updated, its name would incorrectly be changed to “DefaultJobDomain” instead of “DefaultJobSection”.

#### SLAnalytics: Problem when retrieving data from DVE elements \[ID_29464\]

Due to a problem when retrieving data from DVE elements, in some cases, trend prediction and pattern matching would not work for this type of elements.

#### DataMiner Cube - EPM: Children of the siblings of the selected object would incorrectly also be displayed \[ID_29465\]

Up to now, when the *ShowSiblings* option was combined with the *ShowChildren* option, the children of the siblings of the selected object would incorrectly also be displayed. From now on, only the children of the selected object will be displayed.

#### Dashboards app - GQI: Problem when rebuilding a query \[ID_29468\]

In some cases, a query would not get rebuilt correctly after being edited, especially when it contained nodes that were linked to feeds.

#### DataMiner Cube - Alarm Console: Problem when clicking the 'Alarm storm' button \[ID_29472\]

If alarm storm protection by delaying is activated, during an alarm storm you can click the red *Alarm storm* button in the alarm bar to open a new card with a list of the delayed alarms.

In some cases, when you clicked that button, an exception would be thrown and no alarms would be displayed.

#### Dashboards app - GQI: Inconsistent column order when 'select' or 'get parameters' nodes were linked to a feed \[ID_29479\]

When the “Select” or “Get parameters for element where” nodes of a query were linked to a feed, in some cases, the order of the selected parameter columns would not be consistent with the feed selection.

From now on, the default columns will always come first, followed by the items supplied by the feed.

#### Legacy Dashboards app - Trend component: Custom range values would be ignored when the time range of the chart was updated \[ID_29480\]

In the legacy Dashboards app, the “Custom low range” and “Custom high range” options of the Trend component would incorrectly be ignored whenever the time range of the chart was updated.

#### Dashboards app: Data item dragged onto a component would not appear in the component’s edit panel \[ID_29481\]

When you dragged a data item (e.g. the entire Elements dataset) onto a component, in some rare cases, that item would not appear in the component’s edit panel.

#### Dashboards app: Index feed would remain in status 'Loading' when an error occurred while fetching the indices \[ID_29487\]

When an error occurred while fetching the indices, in some cases, the index feed would remain in status “Loading”. From now on, when an error occurs while fetching the indices, the reason of the failure will be displayed.

#### Serial communication: Problem when multiple potential responses were defined in a serial pair \[ID_29496\]

When multiple possible responses were defined in a serial pair, the responses after the first response potentially would not match the received data when header and trailer parameters were not identical.

In the following example, a pair has three responses defined (100, 101, and 102), of which one is expected to match the received data. When the headers and trailers of responses 101 and 102 were identical to those of response 100, the data was matched as expected. However, when the header or trailer was not identical, then a match could be missed for response 101 and 102.

```xml
<Pair id="100">
  <Name>Pair 100</Name>
  <Content>
    <Command>100</Command>
    <Response>100</Response>
    <Response>101</Response>
    <Response>102</Response>
  </Content>
</Pair>
```

#### SLLogCollector would incorrectly not take a dump when the temp folder did not exist \[ID_29500\]

In some cases, SLLogCollector would incorrectly not take a dump when the temp folder did not exist.

#### Mobile apps: Numeric values in text boxes would be clipped \[ID_29506\]

In some cases, numeric values in text boxes would be clipped.

#### Dashboards app: Strings containing decimal values would be sorted incorrectly \[ID_29512\]

In some cases, strings containing decimal values would be sorted incorrectly.

#### Mobile apps: Error 404 page would not list the 6th app \[ID_29521\]

When the DataMiner landing page listed 6 apps and you were redirected to an error 404 page due to an error with one of those apps, then the error 404 page would only list 5 apps.

#### DMA that was incorrectly cleaned after having been removed from a DMS would skip its initial synchronization when added to another DMS later on \[ID_29523\]

When a DataMiner Agent had been removed from the DataMiner System and was cleaned up incorrectly afterwards (e.g. by manually updating the DMS.xml file), in some cases, it would skip its initial synchronization when it was added to another DataMiner System later on.

#### Monitoring app: Alarms page of element card would not show any alarms \[ID_29524\]

When, in the Monitoring app, you opened an element card and navigated to the Alarms page, in some cases, that page would incorrectly not show any alarms.

#### Problem with SLASPConnection when processing the results of a GetAlarmHistory call \[ID_29525\]

In some cases, an error could occur in SLASPConnection when processing the results of a GetAlarmHistory call.

#### DataMiner Cube - Alarm Console: Blue footer bar had an incorrect dark blue color \[ID_29529\]

In some cases, the blue footer bar of the Alarm Console would have an incorrect dark blue color.

#### Baseline of standalone parameter would incorrectly be cleared when its condition had first been evaluated as true and then as false \[ID_29531\]

When relative or absolute monitoring was enabled on a standalone parameter of which the condition had first been evaluated as true and then as false, in some cases, the baseline of the parameter would incorrectly be cleared.

#### Problem with SLElement at DataMiner startup \[ID_29539\]

At DataMiner startup, in some rare cases, an error could occur in SLElement.

#### Dashboards app - GQI: Problem when executing a large query \[ID_29540\]

In some cases, the Dashboards app could become unresponsive when a large query was being executed.

#### DataMiner Cube - Surveyor: Newly created elements located in multiple views would incorrectly only appear in one of those views \[ID_29544\]

When you created a new element located in multiple views, in some rare cases, it would incorrectly only appear in one of those views. Only when you reconnected Cube would the element be displayed in all views in which it was located.

#### Service & Resource Management: Problem loading functions.xml files \[ID_29551\]

When the first attempt to load a functions.xml file would fail, in some cases, no further attempts would incorrectly be made.

#### Monitoring app & Dashboards app: Problem with alarm severity counters \[ID_29561\]

In both the Monitoring app and the Dashboards app, after a number of alarm updates had been processed, the alarm severity counters would indicate an incorrect number of alarms.

#### Problem when taking a backup of an Elasticsearch database after logging on with a password encrypted by DataMiner \[ID_29564\]

In some cases, it would not be possible to take a backup of an Elasticsearch database to which you had logged on using a password encrypted by DataMiner.

#### DataMiner Cube - Trending: Problem when exporting average trend data of a trend graph with multiple lines \[ID_29579\]

When you tried to export the average trend data of a trend graph with multiple lines, in some cases, the export operation would fail. The “retrieving data” notice would not disappear and the export file would not get created.

#### Dashboards app - GQI: Filters would unnecessarily be sent along with SLNet calls \[ID_29583\]

When a GQI query contains a filter to be applied to e.g. a parameter table, then that filter will be sent along with the SLNet call to allow SLElement to apply the filter for performance reasons. However, in some cases, a filter would also be sent along with the SLNet call when this was not applicable (e.g. when there was a join or aggregation operation between the filter and the data source).

#### DataMiner Cube - Embedded Chromium web browser engine: Problems with scaling \[ID_29596\]

In some cases, the following problems could occur with regard to Chromium web browser controls:

- When opened in a window on a high-DPI monitor, they would be scaled twice and the image would not match the mouse cursor.
- When displayed in a window that was moved from one monitor to another, they would not adapt to the new DPI scale.
- When displayed on a high-DPI monitor, they were rendered at 100% DPI and then upscaled, resulting in an imperfect image.

#### SLNetComNotificationThread: Delay between notifications \[ID_29599\]

In SLNet, up to now, the SLNetComNotificationThread had a delay of 15 ms between notifications. In cases where a large number of notifications had to be processed, the total delay could be significant.

#### Elasticsearch: Problem with postfilters \[ID_29602\]

When a client requested data from an Elasticsearch database with a filter, in some cases, an incorrect result set would be returned because the postfilter would incorrectly apply a filter in local time on a field formatted in UTC time. This issue has now been resolved. Also, from now on, postfilters will only be applied when necessary.

#### GetActiveHysteresisInfoResponseMessage would incorrectly contain entries for elements without alarm data \[ID_29604\]

Up to now, when a GetActiveHysteresisInfoMessage request was sent, the GetActiveHysteresisInfoResponseMessage would contain an entry for every element in the DataMiner Agent, whether it had alarm data or not. From now on, elements without active hysteresis data will be removed from the response.

> [!NOTE]
> GetActiveHysteresisInfoMessage now also contains a constructor that accepts a DataMiner ID. That way, an ID will no longer have to be provided after constructing the object.

#### Incorrect in-memory state in SLDMS when removing an agent from a DMS \[ID_29612\]

When a DMA was removed from a DataMiner System, in some cases, the memory of the SLDMS process would be left in an incorrect state.

This could prevent actions like initial synchronization from working when setting up a new DMS or a new Failover environment that included the agent in question.

#### Elasticsearch: Problem when trying to create a customdata object \[ID_29617\]

When a customdata object had to be created in an Elasticsearch database, in some rare cases, multiple DMAs in the DMS would try to create the same table. This would cause an exception to be thrown on some of those DMAs.

#### DataMiner Cube - Data Display: Problem with dynamic parameter ranges \[ID_29625\]

When a protocol updated parameter ranges using an NT_UPDATE_DESCRIPTION_XML call, in some cases, the ranges could be reverted to an old value, especially when the PageUnloadOnNavigatingAway option was enabled or when the ranges belonged to parameters located on pages that had not yet been visited.

#### Problem with SLSNMPAgent \[ID_29629\]

In some cases, an error could occur in SLSNMPAgent when dealing with issues caused by not being able to fetch XML cookies from SLDataMiner.

#### Monitoring app & Dashboards app would no longer receive any alarm page updates \[ID_29635\]

In some cases, the Monitoring app and the Dashboards app would no longer receive any alarm page updates.

#### Problem in SLDataMiner when reloading virtual functions \[ID_29641\]

In some cases, an error could occur in SLDataMiner when a functions.xml file was reloaded.

#### DataMiner Cube - Element Connections: Duplicated non-virtual parameters would be added twice when they referred to a destination parameter \[ID_29645\]

In the Element Connections app, in some cases, duplicated non-virtual parameters would be added twice when they referred to a destination parameter.

#### Dashboards app - Line chart component: Zero values would incorrectly be exported to CSV as null values \[ID_29660\]

When trend data was exported to a CSV file, in some cases, zero values would incorrectly be exported as null values.

#### DataMiner Cube - Spectrum Analysis: Start, stop and center frequencies incorrectly displayed without decimals \[ID_29661\]

When you opened a Spectrum element card, in some rare cases, the start, stop and center frequencies would incorrectly be displayed without decimals.

#### DataMiner Cube: No views visible in the Surveyor after clicking the 'Start' button on the message box saying that the agent was not running \[ID_29665\]

When you opened DataMiner Cube and clicked Start on the message box saying that the agent was not running, the agent would start up but, in some cases, no views would be visible in the Surveyor.

#### Problem when restarting a DMA without stopping SLNet \[ID_29667\]

When you restarted a DataMiner Agent without stopping SLNet, in some rare cases, an exception could be thrown.

#### DMS Alerter would start to consume an excessive amount a memory when configured to play a sound when the alarm in the pop-up matched a filter \[ID_29672\]

When you had configured Alerter to play a sound when the alarm displayed in the pop-up balloon matched a filter, in some cases, Alerter would start to consume an excessive amount a memory.

#### Problem when deleting a service by name \[ID_29691\]

When a SetDataMinerInfoMessage was used to delete a service using the service name, in some cases, an exception could be thrown.

#### Problem when installing an Elasticsearch database from within DataMiner Cube \[ID_29760\]

When you tried to install an Elasticsearch database from within DataMiner Cube, in some cases, an “Unable to load SLSearch assembly” error would appear and the installation process would be aborted.

## Addendum CU1

### CU1 enhancements

#### DataMiner Cube - Service & Resource Management: Enhanced performance when fetching initial data \[ID_29799\]

Due to a number of enhancements, overall performance of the different Service & Resource Management modules has increased, especially when fetching initial data.

### CU1 fixes

#### DataMiner Cube - Data Display: Problem when copying data from a table \[ID_29934\]

When, in DataMiner Cube, you tried to copy data from a table using either *Copy table* or *Copy selected rows*, the following exception could be thrown:

```txt
Export failed: Nullable object must have a value
```

#### DataMiner Cube - Services app: Functions not loaded in service definition diagrams \[ID_29954\]

When you opened a service definition in the Services app, in some cases, the functions would not get loaded into the service definition diagram.

## Addendum CU2

### CU2 fixes

#### DataMiner Cube could become unresponsive when you opened the Services app \[ID_30001\]

When you opened the Services app, in some cases, Cube could become unresponsive.

#### DataMiner Cube - Visual Overview: Booking placeholder would not update correctly when it was not able to resolve the booking ID at initialization \[ID_30011\]

When, at initialization, a booking placeholder was not able to resolve its booking ID to an actual GUID, any updates to that placeholder would not be processed correctly.

## Addendum CU3

### CU3 fixes

#### DataMiner Cube - Services app: Profile parameters not displayed when clicking a node of a service definition \[ID_30059\]

When, in the Services app, you clicked a node of the service definition, in some cases, the profile parameters would not be displayed. Also, it would not be possible to select a profile instance for that node.

#### MySQL and SQL Server databases: ExtraStatusId field was incorrectly added to the info table \[ID_30096\]

On MySQL and Microsoft SQL Server databases, since DataMiner version 10.1.6 the info table would incorrectly contain an *ExtraStatusId* field. As a result, on systems with a MySQL database (on which the STRICT option was set to true) or a Microsoft SQL Server database, it was no longer possible to store information events.

#### Resources and Services modules also loaded functions that were not active \[ID_30107\]

In the Resources and Services modules, it could occur that functions were loaded even though they were not marked as active, which could cause several functions with the same GUID to be loaded.
