---
uid: General_Feature_Release_10.1.8
---

# General Feature Release 10.1.8

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### Configuration of credentials for Elasticsearch backup location \[ID_29024\]

It is now possible to configure specific credentials for the Elasticsearch backup location. To do so, send a *SetElasticBackupPath* message with the credentials using the SLNetClientTest tool. This will create a Windows scheduled task "elasticbackupwithcredentials", which is triggered on startup, and which makes it possible to access the backup path location.

> [!WARNING]
> Always be extremely careful when using SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Failover without virtual IP address [ID_29189] [ID_29911]

In a Failover system, which consists of two redundant DataMiner Agents, the offline Agent will stand by, waiting to take over as soon as the online Agent goes offline. Up to now, a Failover system always made use of a so-called "virtual IP address", an IP address that is shared by the two Agents and that the online Agent assigns to itself. However, in certain situations, it is very hard or even impossible to share a virtual IP address. In those situations, it is now possible to set up a Failover system using a shared hostname instead.

| Using a shared virtual IP address                      | Using a shared hostname                                                |
|--------------------------------------------------------|------------------------------------------------------------------------|
| DataMiner creates a virtual IP address on the NIC      | No modifications are needed on the NIC                                 |
| No additional IIS rules need to be created             | A "URL Rewrite" IIS rule will be created automatically (Reverse Proxy) |
| 2 NICs can be configured (Corporate & Acquisition) | Only one hostname (address)                                            |

##### Configuration

In DataMiner Cube, after opening the *Failover Config* window, you can now select either "Failover (Virtual IP)" or "Failover (hostname)".

Note that, in the DMS.xml file, two extra elements can now be specified:

- **FailoverType**: The type of Failover system: "VirtualIP" or "HostName".
- **Hostname**: The shared hostname (only applicable when FailoverType is set to "HostName".

  > [!NOTE]
  >
  > - The hostname you specify must be configured in the network. In other words, a corresponding DNS record must exist.
  > - The hostname must resolve to both primary IP addresses of the Failover agents. Example output of an nslookup of the hostname:
  >
  >   ```txt
  >   Name: ResetPlease.FailoverZone
  >   Addresses: 10.11.5.52
  >   10.11.4.52
  >   ```

When you set up a Failover system using a shared hostname, in IIS, a URL Rewrite rule will be created in order to forward all HTTP traffic to the online agent.

> [!NOTE]
> In order for this URL Rewrite rule to be created and enabled/disable automatically, the IIS extension "Application Request Routing" needs to be installed manually on both Failover agents.
>
> See: <https://www.iis.net/downloads/microsoft/application-request-routing>

#### NATS upgraded to version 2.2.6 + new NATS SLNet settings \[ID_30156\]

To improve support for previous enhancements, the NATS version used by DataMiner has been upgraded to version 2.2.6.

In addition, two new options are available to refine the NATS settings in *MaintenanceSettings.xml* (in the \<SLNet> element):

- *NATSLogFileCleanupMs*: Determines the time (in milliseconds) between NATS log file cleanup attempts. This timing will only be applied after the next cleanup attempt after the configuration change. For example, if the next cleanup attempt is in 15 minutes and you change this value, the next cleanup will still be in 15 minutes, but all subsequent cleanups will happen after 1-minute intervals. The default value of this setting is 900000 (15 minutes).
- *NATSLogFileAmountToKeep*: The number of log files to keep (default =10). This value only applies to the log files that do not have the .log extension.

For example:

```xml
<MaintenanceSettings>
  ...
  <SLNet>
    ...
    <NATSLogFileCleanupMs>60000</NATSLogFileCleanupMs>
    <NATSLogFileAmountToKeep>20</NATSLogFileAmountToKeep>
    ...
  </SLNet>
  ...
</MaintenanceSettings>
```

### DMS Protocols

#### Aggregation: Using regular expressions in the filter \[ID_30199\]

It is now possible to a regular expression in the filtering options of an aggregate action.

##### Syntax 1: Equation with a regular expression defined in a regex attribute

When using this syntax, add “equation:regex,” to the *options* attribute and specify the regular expression in a separate *regex* attribute.

Example:

```xml
<Action id="1">
  <Name>Regex aggregate with static equation</Name>
  <On id="304">parameter</On>
  <Type options="groupby:2;type:count;equation:regex,;return:3002" regex="^[a-zA-Z]{2}$">aggregate</Type>
</Action>
```

##### Syntax 2: Equation with a regular expression defined in a parameter

When using this syntax, to the *options* attribute add “equation:regex,”, followed by the ID of the parameter containing the regular expression.

Example:

```xml
<Action id="2">
  <Name>Regex aggregate with equation in parameter</Name>
  <On id="304">parameter</On>
  <Type options="groupby:2;type:count;equation:regex,3120;return:3102">aggregate</Type>
</Action>
```

##### Syntax 3: Equation value with a regular expression defined in a regex attribute

When using this syntax, to the *options* attribute add “equationvalue:”, followed by four comma-separated arguments, and specify the regular expression in a separate *regex* attribute.

| Argument | Description                                                                                                |
|----------|------------------------------------------------------------------------------------------------------------|
| a        | Type of equation: “regex”                                                                                  |
| b        | Empty when regular expression is specified in a separate *regex* attribute. |
| c        | The ID of the column parameter to which the equation has to be applied.                                    |
| d        | The row index. If this argument is not specified, the matching will be done on a row by row basis.         |

Example:

```xml
<Action id="3">
  <Name>Regex aggregate with static equation value</Name>
  <On id="306">parameter</On>
  <Type options="groupby:2;type:avg;equationvalue:regex,,304,;return:3202" regex="^[a-zA-Z]{2}$">aggregate</Type>
</Action>
```

##### Syntax 4: Equation value with a regular expression defined in a parameter

When using this syntax, to the *options* attribute add “equationvalue:”, followed by four comma-separated arguments.

| Argument | Description                                                                                        |
|----------|----------------------------------------------------------------------------------------------------|
| a        | Type of equation: “regex”                                                                          |
| b        | The ID of the parameter containing the regular expression.                                         |
| c        | The ID of the column parameter to which the equation has to be applied.                            |
| d        | The row index. If this argument is not specified, the matching will be done on a row by row basis. |

Example:

```xml
<Action id="4">
  <Name>Regex aggregate with equation value in parameter</Name>
  <On id="306">parameter</On>
  <Type options="groupby:2;type:avg;equationvalue:regex,3120,304,;return:3302">aggregate</Type>
</Action>
```

> [!NOTE]
> When you opt to store a regular expression in a parameter, then this parameter should be a standalone, single-value parameter of type string.

### DMS Cube

#### Profiles app: Failsafe mechanism added to prevent situations where updates made by one user get overwritten by updates made by another user \[ID_28651\] \[ID_30057\]

The Profiles app now contains a failsafe mechanism to prevent possible situations where updates made by one user get overwritten by updates made simultaneously by another user.

#### Visual Overview: History mode for alarm states + culture option for datetime control \[ID_29822\]

When shapes in Visual Overview are linked to an element, parameter or service, it is now possible to show the alarm state for this linked object at a specific point in the past. To do so, you can use the new shape data *HistoryMode*, which can be added to a specific shape, or to the entire page.

The value of the shape data field should consist of a state indication and a timestamp, separated by a pipe character ("\|"). The *State* can be *On* or *Off*. *On* means history mode is active, *Off* means real-time alarm information should be shown instead. Both the state value and the timestamp value can be configured using placeholders.

For example:

| Shape data field | Value                              |
|------------------|------------------------------------|
| HistoryMode      | State=On\|TimeStamp=\[var:myTime\] |

> [!NOTE]
> This feature is currently not yet supported for shapes linked to views.

An additional change introduced by this release note is that you can now define the culture that should be used for a shape that has been turned into a datetime control (using the *SetVarOptions* shape data set to *Control=DateTime*). To do so, add *DateTimeCulture=* followed by *Current* or *Invariant*. The latter is the default value.

For example:

| Shape data field | Value                                     |
|------------------|-------------------------------------------|
| SetVarOptions    | Control=DateTime\|DateTimeCulture=Current |

#### Visual Overview: History mode for spectrum thumbnails \[ID_30130\]

It is now possible to have a spectrum thumbnail in Visual Overview show the trace from a specific moment in the past, based on the recorded trending for a parameter in a spectrum monitor.

The trended trace record from right before the specified time will be displayed. For this purpose, the trended traces are queried with the following steps until a trace record is found or the maximum search extent has been reached: 1 hour – 3 hours – 12 hours – 24 hours – 48 hours (maximum).

To configure this:

1. Configure the shape in the same way as for a regular spectrum thumbnail, but as the parameter ID, specify the ID of the spectrum monitor trace parameter (which is always in the range 50000 - 59999). You can find this ID in the file *SpectrumMonitors.xml* in the folder *C:\\Skyline DataMiner*.

2. Add the *HistoryMode* shape data field to the shape, and configure its value as follows:

    ```txt
    State=[On/Off]|TimeStamp=[datetime value]
    ```

    Refer to the table below for the value syntax:

    | Value   | Explanation                                                                                                                                                                        |
    |-----------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | State     | Can be "On" or "Off". On means history mode is active, Off means the real-time spectrum trace should be shown instead. You can use a placeholder to change this value dynamically. |
    | TimeStamp | The date and time for which the spectrum trace should be displayed. You can use a placeholder to change this value dynamically.                                                    |

For example:

| Shape data field | Value                                                 |
|------------------|-------------------------------------------------------|
| Element          | 113/333                                               |
| Parameter        | 50016\|11\|trace_2mps\|5\|DisplayLabels;DisplayTime\| |
| HistoryMode      | State=On\|TimeStamp=\[var:myTime\]                    |

#### Visual Overview: New Collapse shape data field \[ID_30149\]

In Visual Overview, you can now hide a shape in a different way than with the *Hide* shape data field, using the new *Collapse* shape data field. This field is configured in the same way, as detailed under [Extended conditional shape manipulation actions](xref:Extended_conditional_shape_manipulation_actions). While on the face of it, the result of the *Collapse* action will be the same as for a *Hide* action, the shape is hidden in a different way, i.e. its visibility is collapsed.

This makes it a convenient alternative to the *ChildrenFilter* shape data, as it will keep all shapes in memory instead of removing and recreating them. This will allow better performance, though it will lead to slightly increased memory usage.

Using the *Collapse* action can also be convenient in a grid layout, as a collapsed shape will not take up room in a grid, unlike a shape hidden using *Hide*.This can allow you to use the "Auto" width or height more effectively.

#### Visual Overview: New icons added to Icons stencils \[ID_30198\]

The following icons have been added to the Icons stencil:

- TV streaming
- Microservices

### DMS Reports & Dashboards

#### Dashboards app: Data selected in a State, Gauge or Ring components used as a feed will be highlighted \[ID_29657\]

When State, Gauge or Ring components are used as feeds by other components, the data selected in those feed component will now be highlighted.

#### Dashboards app: Table visualizations now allow columns to be reordered \[ID_30091\]

In table visualizations, it is now possible to reorder columns.

To move a table column to another location, click its header and drag it to its new location.

#### Dashboards app: Column filter based on text in Node edge graph and Table component \[ID_30182\]

When you configure a column filter for a Node edge graph or Table dashboard component in order to highlight specific columns depending on the displayed value, you can now filter on specific text. Previously, it was only possible to apply a column filter on a selected range. Now, you can instead select the column you want to use for highlighting, and then specify text to filter on in a text box. You can then choose whether a positive or negative filter should be used, and whether the value should equal the filter, contain the filter or match a regular expression.

Multiple filters can be applied on the same value. In that case, the filters will be applied from the top of the list to the bottom. Positive filters will get priority over negative filters. You can also remove filters again by selecting No color.

### DMS Automation

#### ProcessAutomationHelper \[ID_30108\]

A new ProcessAutomationHelper has been added to manipulate PaToken and PaProcess objects. See the following example.

```csharp
public class Script
{
    public void Run(Engine engine)
    {
        var paHelper = new ProcessAutomationHelper(engine.SendSLNetMessages);
        var token = new PaToken() { Id = Guid.NewGuid() };
        var createdToken = paHelper.PaTokens.Create(token);
        var readToken = paHelper.PaTokens.Read(createdToken.ToFilter<PaToken>());
        paHelper.PaTokens.Delete(createdToken);
        var process = new PaProcess() { Id = "id" };
        var createdProcess = paHelper.PaProcesses.Create(process);
        var readProcess = paHelper.PaProcesses.Read(createdProcess.ToFilter<PaProcess>());
        paHelper.PaProcesses.Delete(createdProcess);
    }
}
```

> [!NOTE]
>
> - Save operations will always be executed synchronously. In other words, the method will only return once the data has been written to the database.
> - At present, bulk operations are not yet supported.
> - Both PaProcess and PaToken now have a new LastModifiedAt property, filled in by SLNet. It will be used to compare cached versions with versions retrieved from the database.

#### Interactive Automation scripts: File selector allowing multiple selections + file selector enhancements \[ID_30196\]

In an interactive Automation script that is used in the DataMiner web apps, you can now configure a file selector component that allows the user to upload multiple files. To do so, set the property *AllowMultipleFiles* to true.

For example:

```csharp
UIBlockDefinition uibDef = new UIBlockDefinition();
uibDef.Type = UIBlockType.FileSelector;
uibDef.DestVar = destvar;
uibDef.InitialValue = initialValue;
uibDef.Row = (int)row;
uibDef.RowSpan = (int)rowSpan;
uibDef.Column = (int)column;
uibDef.ColumnSpan = (int)columnSpan;
uibDef.HorizontalAlignment = GetHorizontalAlignment(horizontalAlignment);
uibDef.VerticalAlignment = GetVerticalAlignment(verticalAlignment);
uibDef.AllowMultipleFiles = true;
```

With this configuration, users will be able to add files one by one, but they will not be able to add the same file twice. They will also be able to add a file by dragging it to the file selector.

There have also been a number of enhancements to the file selector control in general, including improved layout and a more intuitive UI. These affect all the web apps, including the Dashboards app, the Jobs app, etc.

### DMS web apps

#### Visual Overview: Links starting with 'mailto:' now also work in web apps \[ID_30109\]

When, in shape data, you specify links starting with “mailto:”, those links will now also work in web apps.

### DMS Service & Resource Management

#### Profile manager errors with ErrorReason 'ReservationsMustBeReconfigured' now include a ReservationInstanceDetails list \[ID_29914\]

From now on, an error with ErrorReason “ReservationsMustBeReconfigured” will now include a ReservationInstanceDetails list containing the ID, the name and the start time of every affected ReservationInstance.

#### Availability checks for contributing resources \[ID_30017\]

From now on, the GetEligibleResources and AddOrUpdateReservationInstances calls will determine the availability of a contributing resource during a certain time range based on the following criteria:

- If the contributing booking linked to the resource has Status set to “Canceled”, “Disconnected”, “Interrupted” or “Undefined”, then the resource will be considered unavailable.
- If the contributing booking linked to the resource has Status set to a value other than “Canceled”, “Disconnected”, “Interrupted” or “Undefined”:

  - If the contributing booking linked to the resource has LockLifeCycle set to “Locked”, then the contributing resource will be considered available if the time range of the contributing booking is entire inside the time range.
  - If the contributing booking linked to the resource has LockLifeCycle set to “Unlocked”, then the contributing resource will be considered available if the timing of the contributing booking intersects with the passed time.
  - If the contributing booking linked to the resource has LockLifeCycle set to “Undefined”, then the contributing resource will be considered not available.

Based on those criteria, the GetEligibleResource call will not return any resources that are unavailable.

Adding or updating bookings with resources that are unavailable based on the above-mentioned criteria will cause the complete resource usage to be quarantined. The QuarantineTrigger will have reason ContributingResourceNotAvailable.

If the contributing booking has Status set to “Interrupted”, then the bookings using its linked contributing resources will also have their usages quarantined.

#### More detailed parameter check error messages when generating protocols for virtual functions \[ID_30093\]

When an error occurs during a parameter check while generating a protocol for a virtual function, the error message will now contain more detailed information.

- When a parameter is not of category “Monitoring” or “Configuration”, a CrudFailedException containing a VirtualFunctionDefinitionError with reason InvalidProfileParameterCategory will be thrown.
- When a parameter is of type “discrete” but has no discrete values assigned to it, a CrudFailedException containing a VirtualFunctionDefinitionError with reason InvalidProfileParameterDiscrete will be thrown.

The VirtualFunctionDefinitionError will have the following properties filled in:

- VirtualFunctionDefinitionID: The ID of the VirtualFunctionDefinition.
- ParameterID: The ID of the parameter that cannot be resolved.

### DMS tools

#### Standalone Cassandra Backup Tool \[ID_29005\] \[ID_30234\]

The StandaloneCassandraBackup.exe tool can be used by an administrator to take a backup of a Cassandra database (either a single node or a cluster).

From DataMiner 10.1.8 onwards, this tool will be available on each DMA server in the folder C:\\Skyline DataMiner\\Tools. As it only affects Cassandra files, it can be used on any DataMiner system regardless of version.

For more information on this tool, see [Standalone Cassandra Backup Tool](xref:Standalone_Cassandra_Backup_Tool).

## Changes

### Enhancements

#### Security enhancements \[ID_29980\] \[ID_30012\] \[ID_30086\] \[ID_30087\] \[ID_30192\] \[ID_30195\] \[ID_30202\] \[ID_30257\]

A number of security enhancements have been made.

#### Enhanced performance when executing offloaded database operations against a Cassandra or Elasticsearch database \[ID_29451\] \[ID_29857\]

Due to a number of enhancements, overall performance has increased when executing Cassandra and Elasticsearch database operations that were offloaded to a file when the database was unavailable.

> [!NOTE]
> While executing database operations that were offloaded to a file when the database was unavailable, an information event and a log entry will be created every 30 seconds to indicate the execution progress.

#### Limiting disk space occupied by offload files \[ID_29563\]

In the C:\\Skyline DataMiner\\Database\\DBConfiguration.xml file, you can now specify the maximum amount of disk space that can be occupied by database offload files.

Example:

```xml
<DatabaseConfiguration>
  <FileOffloadConfiguration>
    <MaxSizeMB>10</MaxSizeMB>
  </FileOffloadConfiguration>
</DatabaseConfiguration>
```

> [!NOTE]
>
> - If no DBConfiguration.xml file exists in C:\\Skyline DataMiner\\Database, then create one with the content of the example above.
> - If no limit is set in DBConfiguration.xml or if the file offload configuration is invalid, the size of the database offload files will by default be limited to 10 GB.
> - When the specified limit has been reached, an alarm with the following text will be generated: “Max file offload disk usage for certain storages has been reached, new data for these storages will be dropped.” Also, the following entry will be added to the SLDBConnection log file: “\|INF\|0\|112\|2021-04-14T13:34:19.559\|DEBUG\|DataGateway.FileOffload\|Max disk usage reached: True for storage Cassandra.TimeTrace (timetrace)”.

#### Enhanced handling of stack overflow exceptions \[ID_29796\]

A number of enhancements have been made to better handle stack overflow exceptions.

#### Smart-serial client connections: Logging incoming data \[ID_29874\]

When a smart-serial client connection receives incoming data, it will forward that data to SLProtocol and display it in Stream Viewer. However, when the incoming data does not match the configured response, the connection will forward TIMEOUT to SLProtocol, making it hard to find out what data was received by SLPort.

From now on, if you enable a specific connection in PortLog.txt (see DataMiner Help) and set SLPort debug logging to level 4 or higher, log entries like the one below will be added to SLPort.txt. These entries contain the IP address and port of the server, the size of the incoming data and the data itself.

```txt
2021/05/14 15:30:57.452|SLPort.exe 8.5.1519.6|39680|39544|CSmartIP::ProcessIncomming|DBG|4|Incoming data from 127.0.0.2:4598 (total length: 5 bytes) -    000000  576F72642E                                   Word.
```

#### SLUpgrade can now run BPA tests before starting the upgrade process \[ID_29903\]

When a DataMiner upgrade package contains a set of BPA tests in its Prerequisites folder, SLUpgrade will now run those tests before starting the upgrade process. Upon failure of one or more of these tests, the upgrade process will be aborted and a message will be displayed.

The BPA tests run before the start of an upgrade process will generally be tests designed to check whether the system meets the requirements necessary to upgrade to the new DataMiner version.

BPA tests added to the Prerequisites folder of a DataMiner upgrade package must comply to the following rules:

- They must have their CanRunOnOfflineAgents flag enabled. This will make sure that, in a Failover setup, the offline agent will also be checked.
- They must have their RequireSLNet flag disabled.

#### Enhanced performance when exporting function protocols \[ID_29929\]

When you uploaded a new version of a protocol that had an active functions file, up to now, all active function elements would be re-evaluated after the function protocols were exported. From now on, the function elements will only be re-evaluated when the function file is set to active.

#### Dashboards app - GQI: Enhanced performance when processing GQI query results \[ID_29977\]

Due to a number of enhancements, overall performance has increased when processing a GQI query result.

#### Enhanced logging of parameter update stack notices \[ID_29996\]

Up to now, when the number of items on the parameter update stack was divisible by 1000 after an item had been added to it, a log entry would be added to the log file of the element for which that last item had been added. As a result, parameter update stack notices would be scattered among different log files.

From now on, when the parameter update stack exceeds 5000 items, log entries will be added to the log files of all elements for which there are items on the stack. Also, similar log entries will be added to the same log files each time the number of items on the stack is divisible by 1000 until the number of items on the stack drops below 1000.

#### Service & Resource Management: Enhanced error message when a referenced resource capability does not exist \[ID_30065\]

When you created a ReservationInstance that referenced a non-existing capability of an existing resource, up to now, the following error message of type “ResourceCapabilityInvalid” would be displayed:

```txt
Could not find the profile with capability parameter {oneCapabilityUsage.CapabilityProfileID}.
```

From now on, the following error message will be displayed instead:

```txt
Could not find capability parameter {oneCapabilityUsage.CapabilityProfileID} on resource {resource.ID}.
```

#### DataMiner backup packages will now also include the SoftLaunchOptions.xml file \[ID_30076\]

From now on, DataMiner backup packages will also include the SoftLaunchOptions.xml file.

#### Service & Resource Management: Enhanced performance when creating bookings \[ID_30116\]

Due to a number of enhancements, overall performance has increased when creating bookings.

#### Logging: An entry will no longer by default be added to the SLDataMiner.txt and SLErrors.txt log files when the “C:\\Skyline DataMiner\\Simulations” folder cannot be found at DataMiner startup \[ID_30168\]

Up to now, at DataMiner startup, the following entry would by default be added to the SLDataMiner.txt and SLErrors.txt log files when no C:\\Skyline DataMiner\\Simulations folder could be found:

```txt
CDataMiner::LoadSimulations|ERR|0|Failed to query directory 'C:\Skyline DataMiner\Simulations' with filter 'Simulation_*.xml' (The system cannot find the path specified.).
```

From now on, such entries will no longer by default be added to the above-mentioned log files at DataMiner startup.

#### DataMiner Cube: 'DataMiner Cube mobile' changed to 'DataMiner web apps' \[ID_30201\]

Throughout the Cube UI, the term “DataMiner Cube mobile” has been replaced by the term “DataMiner web apps”.

#### Service & Resource Management: ReservationInstance will again be marked as interrupted when created with a start time before the Resource Manager was initialized \[ID_30211\]

Since DataMiner version 10.0.0 CU11/10.1.3, when a ReservationInstance was created with a start time in the past, before the Resource Manager was initialized, that ReservationInstance would no longer be marked as interrupted. From now on, when a ReservationInstance is created with a start time in the past, before the Resource Manager was initialized, that ReservationInstance will again be marked as interrupted.

#### DataMiner Cube - Data Display: Service cards now also support conditional page visibility \[ID_30217\]

In a protocol.xml file, it is possible to specify that a Data Display page should either be shown or hidden based on a parameter value. Service cards now also support this feature.

#### BPA test 'Report Active RTE' will now run more frequently \[ID_30250\]

The BPA test “Report Active RTE” will now run once every 8 minutes instead of once every hour.

#### Updated BPA tests: 'Minimum Requirements Check' & 'View Recursion' \[ID_30259\]

The following default BPA tests were updated:

- Minimum Requirement Checker: Name changed to “Minimum Requirements Check”
- View Recursion: Description updated

### Fixes

#### NATS service would fail to start on DataMiner startup \[ID_29143\]

When, in a DataMiner System with at least three agents, a DataMiner Agent was starting up, in some cases, the NATS service would fail to start without any log entry explaining the reason for this failure.

#### Dashboards app - Time range feed: Value passed along incorrectly when 'Use quick picks' option was selected \[ID_29471\]

When the “Use quick picks” option was selected, a time range feed would pass along the selected value incorrectly.

Also, custom quick picks would disappear when reloading the dashboard, and when the “Allow refresh” option was selected, the feed would not correctly update the linked trend graph when the refresh counter was reset.

#### DMS Alerter: Problem when closing Alerter while balloons are popping up \[ID_29725\]

In some cases, an exception could be thrown when you closed Alerter while balloons were popping up.

#### DataMiner Cube - Resources app: Labels not displayed in the correct color when using the Skyline Black theme \[ID_29767\]

When using the Skyline Black theme, labels in the Resources app would not be displayed in the correct color.

#### SLDataMiner: High-level log entries would incorrectly not get added to the log after increasing the log level \[ID_29781\]

When you increased the log level of SLDataMiner, high-level log entries would incorrectly not get added to the log.

#### DataMiner Cube - Visual Overview: Problem with SelectionSetVar option \[ID_29797\]

When, in Visual Overview, a table control had the SelectionSetVar option specified, in some cases, it would not be possible to select a row.

#### DataMiner Cube - Resources app: No scroll bars would appear when a pane was not able to show all content \[ID_29836\]

When, in the Resources app, you selected a resource with e.g. a large number of capacity and/or capability parameters, no scroll bars would appear, even when the pane was not able to show all content.

#### HTML5 apps: Incorrect overlay could appear when a timespan field got the focus \[ID_29849\]

When, in an HTML5 app, a timespan field got the focus, in some cases, an incorrect overlay could appear on top of the field.

#### Cassandra: 'tried to execute null statement' errors incorrectly added to SLDBConnection.txt log file \[ID_29947\]

On systems with a Cassandra database, errors similar to the one below would incorrectly be added to the SLDBConnection.txt log file:

```txt
[timestamp]|SLDBConnection.txt|SLDBConnection|SLDBConnection|ERR|0|335|Cassandra: tried to execute null statement.
```

#### DataMiner Cube - Visual Overview: Problem when using the FollowPathColor option \[ID_29959\]

In some cases, using the FollowPathColor option would cause Cube to become unresponsive.

#### Dashboards app - Group component: Visualizations would incorrectly be removed when opening the Layout tab \[ID_29962\]

When you opened the Layout tab of a Group component, in some cases, the visualizations will incorrectly be removed.

#### Problem when changing a protocol that had a production version \[ID_29966\]

When you changed a protocol that had a production version, in some rare cases, elements could receive an incorrect XML cookie, causing the following error to appear in the Alarm Console. Also, the elements in question would be prevented from starting up properly.

```txt
Initializing the protocol for X failed. The XML module is not initialized. (hr = 0x80040216)
```

#### Data offloading would incorrectly be disabled when saving the settings of the offload database \[ID_29985\]

When, in DataMiner Cube, you saved the settings of the offload database, the settings for offloading the real-time trend data would not be applied correctly. As a result, offloading would be disabled until the DataMiner Agent was restarted.

#### Part of SLNet initialization could be skipped when a client disconnected while the DMA was starting up \[ID_29986\]

When a client disconnected while the DMA was starting up, in some rare cases, part of the initialization of the SLNet process could get skipped, which would lead to issues later on. Up to now, the error would only be added to the logs. From now on, in cases like this, the following will happen:

- When a client cannot be re-registered during the SLNet initialization, an entry will be added to the logs, but the initialization will no longer fail.
- Any exception thrown during the SLNet initialization will now also show up in the Alarm Console as “Unexpected Exception \[Initialize DMA\]: xxxxxx”

#### Interactive Automation scripts: Only the value added in the last text box would be saved \[ID_29995\]

When, in interactive Automation scripts, you rapidly entered values in multiple text boxes, in some rare cases, only the value entered in the last text box would be saved.

#### Stopping an SLA would cause a 'window change' event that would lead to outages being closed when history set alarms were received \[ID_29998\]

When an SLA is stopped while it has an open outage, the open outage will be closed with a timestamp containing the time at which the SLA was stopped. This ensures that all outages are closed in case the SLA starts again when no impacting alarms are present to open and later close the outage.

However, this event would be logged as a “window change”, causing the SLA to close and reevaluate the current alarms at the time the SLA was stopped whenever a history set alarm was received with a timestamp earlier than the time at which the SLA was stopped. This would then cause extra non-intended outages.

#### Interactive Automation scripts: Values shown in datetime controls would be out of sync with the values sent to the server \[ID_30015\]

In interactive Automation scripts, in some rare cases, the value shown in a datetime control would be out of sync with the value sent to the server. Also, in some cases, datetime controls could trigger updates even when their WantsOnChange property was set to false.

#### Synchronization of a cleared DMS.xml file would incorrectly cause all agents to remove themselves from the DataMiner System \[ID_30023\] \[ID_30163\]

When a DataMiner Agent is starting up, it checks whether the DMS.xml file was changed while it was down. If changes are found, these are then synchronized among the other agents in the DataMiner System. However, up to now, when the DMS.xml file had been cleared and only contained either the IP address of the DataMiner Agent that was starting up or the name of the DataMiner System, this would incorrectly cause a cascade of delete operations throughout the DataMiner System, resulting in all the agents slowly removing themselves from the DataMiner System.

Also, when an outdated cluster configuration was left on a standalone DataMiner Agent after manually removing the DMS.xml file or after restoring a DataMiner backup, other agents in the DataMiner System could be triggered to leave the DataMiner System once the standalone agent was re-added to the cluster.

#### DataMiner Cube - Resources app: Contributing resources would not be visualized correctly \[ID_30031\]

In the Resources app, up to now, contributing resources would be visualized incorrectly.

#### Failover: Network interface would not properly release the virtual IP address when being re-attached after being disconnected during a Failover switch \[ID_30033\]

When a network interface was disconnected or disabled during a Failover switch, in some cases, it would not properly release the virtual IP address when it was re-attached.

#### InstanceAlarmLevel would not fall back to CellActualAlarmLevel when there was bubble-up information but no instance information \[ID_30044\]

In case of a view table with bubble-up information and view columns with alarm information, up to now, the InstanceAlarmLevel property on the primary key cell would incorrectly be set to “Undefined” instead of the highest severity of those columns.

#### Service & Resource Management: ReservationInstance property updates could incorrectly overwrite more recent updates when performed on an agent other than the hosting agent \[ID_30047\]

In some cases, ReservationInstance property updates would incorrectly overwrite more recent updates when performed on an agent other than the hosting agent.

#### DataMiner Cube - System Center: No longer possible to change a user’s group membership \[ID_30075\]

When, in a user card, you opened the *Group membership* tab, both the *Available groups* list and the *Included in groups* list would be empty. Hence, in a user card, it would not possible to make a user a member of a particular group. If you wanted to make a user a member of a particular group, you had to select the group in question, open the *Users* tab and add the user to the *Included users* list.

#### Dashboards app: Selection not set in parameter feed \[ID_30092\]

In a parameter feed, in some rare cases, the selection would not be set.

#### DataMiner Cube - Alarm Console: Problem when reconnecting after adding the 'Severity Duration' column \[ID_30099\]

When, in the Alarm Console, you added the Severity Duration column and then reconnected, on a large DataMiner System, Cube could become unresponsive.

#### DataMiner Cube desktop app: No DataMiner Systems shown on start window \[ID_30100\]

When you started the DataMiner Cube desktop app, in some cases, the start window would not show any DataMiner System.

#### Dashboards app - Tables: Primary key columns would have an incorrect background color \[ID_30110\]

In table visualizations, in some cases, primary key columns would have an incorrect background color. From now on, the Dashboards app will visualize primary key columns in the same way as they are visualized in DataMiner Cube.

#### BPA tests could fail with a 'BPA has an invalid signature' error \[ID_30118\]

On DataMiner Agents on which the latest Windows updates had not been installed, in some cases, BPA tests would fail with the following error:

```txt
BPA has an invalid signature
```

Also, the following entry would be added to the SLBpaManager.txt log file at DataMiner startup:

```txt
Ignoring certificate SkylineCodeSigning.cer: Certificate is not trusted by the machine
```

From now on, BPA tests that are signed with the Skyline code signing certificate will be forcefully loaded, and the following entry will be added to the SLBpaManager.txt log file:

```txt
Force loaded certificate: SkylineCodeSigning.cer (Skyline Certificate). WARNING! Machine might not have latest Windows Updates.
```

#### SNMPv1/SNMPv2 element could remain in a timeout state after its IP address had been first set to a non-existing address and then to its original address \[ID_30123\]

When you change the IP address of an SNMPv1 or SNMPv2 element that is polled using a “dynamic IP” parameter to a non-existing address, the element will go into timeout as it tries to poll that non-existing IP address. However, up to now, when you then changed the IP address back to the one the element had before, it would incorrectly remain in timeout until it was restarted.

Also, from now on, when an SNMP-related failure occurs, the log entry will include the error code. Where previously a log entry like “Unable to set destination port” would be added, DataMiner will now add a log entry like “Unable to set destination port (error code: 3)”.

#### DataMiner Cube - Backup: Users without 'Backup \> Configure' permission would incorrectly be allowed to update the “Indexing Engine location” backup path \[ID_30131\]

In the *Backup* section of *System Center*, users without *Modules \> System configuration \> Backup \> Configure* permission would incorrectly be allowed to update the *Indexing Engine location* backup path.

#### DataMiner Cube - Scheduler: Users with permission to add tasks but not to edit them would not be able to save a newly created task \[ID_30132\]

When, in the Scheduler app, users created a new scheduled task, they were not able to save that task when they had permission to add tasks but not to edit them.

#### NATS logfile_size_limit setting would not automatically be added after a DataMiner upgrade \[ID_30146\]

When a DataMiner Agent using NATS was upgraded to a version containing the logfile_size_limit setting, that setting would not automatically be added to the nats-server.config file in the C:\\Skyline DataMiner\\NATS\\nats-streaming-server folder. It would only be added the first time you manually sent a NatsCustodianRestartNatsRequest message.

From now on, when a DataMiner Agent starts up after being upgraded and the nats-server.config does not contain the logfile_size_limit setting, it will be added at SLNet startup. Its value will by default be set to 10 MB.

#### Dashboards app - GQI: 'Start from' option would not be available when the Queries.json file was empty or missing \[ID_30157\]

When building a GQI query, in some cases, the “Start from” option would not be available when the C:\\Skyline DataMiner\\Generic Interface\\Queries.json file was empty or missing.

#### DataMiner Cube - Users/Groups: Duplicate activity log entries \[ID_30162\]

When, in the *Users/groups* section of *System Center*, you opened a user card and selected the *Activity* tab, in some cases, the list would contain duplicate activity log entries.

#### DataMiner Cube - Visual Overview: Button to navigate to another card would no longer work after clicking the Back button \[ID_30167\]

When, on a visual overview, you clicked a button to navigate to another card and then clicked the Back button, in some cases, clicking the button to navigate to another card a second time would no longer open that other card.

#### DataMiner Cube - EPM: Problem opening an EPM card from an alarm when the 'System Name' alarm property contained a trailing space \[ID_30169\]

When the “System Name” property of an alarm contained a trailing space, in some cases, it would not be possible to open the EPM card from the alarm in question.

#### DataMiner Cube - Cassandra: Information events would not have the correct properties \[ID_30178\]

When you opened an information event on a DataMiner Cube connected to a system with a Cassandra database, in some cases, that information event would not have the correct properties. The problem was due to the properties being stored incorrectly into the database.

#### Dashboards app - GQI: Filter on protocol-based inter-element query would not be applied to all elements \[ID_30187\]

Up to now, a filter on a protocol-based inter-element query would incorrectly only be applied to the first two elements of the protocol. This caused the parameters of the other elements to be returned even when they did not match the filter.

#### SLLogCollector: Problem when process list update took longer than 1 second \[ID_30203\]

When SLLogCollector updated its list of processes, it would incorrectly try to update it again when the update took longer than 1 second.

#### Interactive Automation scripts: Lazy-loaded tree controls could no longer be expanded \[ID_30204\]

In interactive Automation scripts, in some cases, it would no longer be possible to expand lazy-loaded tree controls.

#### DataMiner Cube: Not possible to unmask a masked EPM object \[ID_30208\]

In some cases, it would not be possible to unmask a masked EPM object. When you right-clicked, the shortcut menu’s *Unmask* command would incorrectly be disabled.

#### Failover: Datetime values read from the \<Failover> section of DMS.xml would be parsed incorrectly \[ID_30215\]

In some cases, datetime values read from the \<Failover> section of DMS.xml would be parsed incorrectly.

#### DataMiner Cube could become unresponsive when you opened the Profiles app \[ID_30244\]

In some cases, DataMiner Cube could become unresponsive when you opened the Profiles app.

#### Dashboards app - GQI: Random values displayed in table when query returned an empty result set \[ID_30252\]

When a GQI query returned an empty result set, in some cases, the table would incorrectly display a series of random values.

#### DataMiner Cube - Data Display: Pie charts no longer displayed on the Reports page of element cards \[ID_30344\]

In some cases, the Reports page of an element card would no longer display pie charts.
