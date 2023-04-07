---
uid: General_Feature_Release_10.2.7
---

# General Feature Release 10.2.7

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS Protocols

#### QActionTable class - FillArray and FillArrayNoDelete methods: Argument 'row' renamed to 'columns' \[ID_33034\]

The *row* argument of the FillArray and FillArrayNoDelete methods in theQActionTable class has been renamed to *columns*.

#### Making all elements using a particular protocol.xml run in separate SLScripting and SLProtocol instances \[ID_33358\]

In a protocol.xml file, you can now define that all elements using that protocol.xml file should run in a separate SLScripting and SLProtocol instance.

To do so, use the following syntax:

```xml
<Protocol>
  <SystemOptions>
    <RunInSeparateInstance>true</RunInSeparateInstance>
  </SystemOptions>
</Protocol>
```

> [!NOTE]
> If SLScripting is registered as a service, this functionality is not available. Elements running a protocol.xml file in which RunInSeparateInstance is set to true will then create a notification alarm to indicate a potential memory problem.

##### DataMiner.xml: scriptingProcesses option now accepts integer values

From now on, in DataMiner.xml, you can set the scriptingProcesses option to an integer value, indicating the exact number of SLScripting processes that have to be launched. The SLProtocol processes will then be assigned one of the available SLScripting processes in a round-robin way.

For example, if protocolProcesses is set to 5 (i.e. the default value), and scriptingProcesses is set to 3, then...

- SLScripting 1 will host SLProtocol #1 and #4
- SLScripting 2 will host SLProtocol #2 and #5
- SLScripting 3 will host SLProtocol #3

> [!NOTE]
>
> - Assigning more SLScripting processes than SLProtocol processes will simply give every SLProtocol its own instance without launching additional SLScripting processes.
> - Up to now, the allowed values for scriptingProcesses were “\[service\]” and “protocol”. If scriptingProcesses is set to “protocol”, an SLScripting process is initialized for every SLProtocol process. This should not be confused with setting protocolProcesses to “protocol”. In that case, an SLProtocol process is launched for every protocol name.

### DMS Cube

#### DataMiner Cube - Alarm Console: Users can now manually create incidents even when 'Automatic incident tracking' is disabled in System Center \[ID_32990\] \[ID_33354\]

From now on, users will be able to manually create incidents even when “Automatic incident tracking” is disabled in System Center.

#### Alarm Console: Second-generation hyperlinks of type 'openview', 'openservice', 'openelement' and 'openparameter' now support '\[PROPERTY:\]' keywords \[ID_33166\]

Up to now, it was only possible to use “\[PROPERTY:\]” keywords in second-generation hyperlinks of type “url”, “execute” and “script”. From now on, these keywords can also be used in second-generation hyperlinks of type “openview”, “openservice”, “openelement” and “openparameter”.

For example, a hyperlink of type “openelement” could contain the following content:

```txt
[PROPERTY:ALARM:Booking Manager Element ID]
```

> [!NOTE]
>
> - If you want to use a view property, a service property or an element property in a hyperlink, then you must enable its “Make this property available for alarm filtering” setting in DataMiner Cube.
> - If you want to use a view property on an alarm of an element that has been added to multiple views, the property that will be used in the hyperlink will be the property of the view with the lowest ID that contains the element.

#### System Center - Failover Config: Miscellaneous UI enhancements \[ID_33245\]

A number of enhancements have been made to the Failover Config window. See below for a summary.

##### General

- The status indicator is now clickable and opens the status page when clicked.

- When the status page opens, the status indicator will now show the last known status until the first refresh.

- When the second agent is added,

  - the IP address or hostname of that second agent is checked to determine whether it refers to a valid DataMiner Agent, and
  - the DataMiner IDs of both agents are checked. In a Failover setup, both must be identical.

- Advanced options:

  - Synchronization NICs are automatically suggested for new setups. The list will now display the actual NIC names instead of the corporate/acquisition names.
  - Heartbeats are automatically suggested for new setups. The list will now display the actual NIC names instead of the corporate/acquisition names.
  - When a new heartbeat is added, the first NIC will automatically be selected.

##### Failover with virtual IP address

- Subnet masks for IP inputs will be suggested based on the current subnet of the DMA.
- The local IP address will no longer be suggested as virtual IP address.
- All known information regarding the valid corporate IP addresses will be filled in automatically (hostname, acquisition IP address and subnet masks)
- It is now mandatory to fill in all three corporate IP addresses.
- It is no longer possible to switch from Failover with virtual IP address to Failover with hostnames when Failover with virtual IP address is active.

- In the advanced options, the (virtual) IP address information will be automatically filled in for new setups.

##### Failover with hostnames

- When setting up a new Failover with hostnames, in the hostname setup, the hostname will now be displayed instead of the IP address. If Failover with hostnames has already been set up, the hostname setup will display the currently used hostnames.

- It is now mandatory to fill in all three hostnames.
- It is no longer possible to switch from Failover with hostnames to Failover with virtual IP address when Failover with hostnames is active.

#### DataMiner Cube - System Center: Additional log files \[ID_33355\]

When, in *System Center*, you go to *Logging \> DataMiner*, you can now inspect the following additional log files:

- SLHistoryManager.txt
- SLIncrementManager.txt
- SLManagerStore.txt
- SLMasterSyncerManager.txt
- SLMigrationManager.txt
- SLModuleSettingsManager.txt
- SLProcessAutomationManager.txt
- SLSRMSettableServiceStateManager.txt
- SLVisualManager.txt

#### Alarm Console: A comment will now be added to an manually created incident when created or updated \[ID_33387\]

When users manually create an incident, change the display value of a manually created incident or add or remove base alarms to or from a manually created incident, from now on, a comment will be added to the incident (Created, Base alarm added, Base alarm removed, Value changed by \<user name> @ \<time>).

#### Alarm Console: Updating incidents using the side panel \[ID_33436\]\[ID_33450\]

In the Alarm Console, it is now possible to edit incidents (i.e. alarm groups) using the side panel.

When you open the side panel and select an incident, a *Drag-and-drop editing* button will appear. Clicking that button will freeze both the side panel and the alarm tab and will allow you to

- add alarms to the incident by dragging them from the Alarm Console onto the side panel, and
- remove alarms from the incident by clicking the “X” next to the base alarm.

When you are finished editing the incident, click *Apply* to apply your changes and unfreeze the side panel.

> [!NOTE]
> Instead of opening the side panel and clicking the *Drag-and-drop editing* button, you can also right-click an incident and select *Edit incident*. This will open the side panel (if it is not open yet) and enable the “drag and drop” mode.

#### Visual Overview - Service Manager component: Filtering on FunctionDefinitionType \[ID_33466\]

When you embed a Service Manager component in Visual Overview, it is now possible to apply a filter that will make the function tree only list functions with specific FunctionDefinitionType fields.

To do so, add a FunctionTypes option to the ComponentOptions shape data field.

| Shape data field | Value |
|--|--|
| Component | ServiceManager |
| ComponentOptions | FunctionTypes=\[comma-separated list of values\]<br> Possible values:<br> - Undefined (i.e. NULL value)<br> - UserTask<br> - ScriptTask<br> - ResourceTask<br> - Gateway<br> - NoneStartEvent<br> - TimeStartEvent<br> - EndEvent |

> [!NOTE]
>
> - The FunctionTypes option
>   - only works in conjunction with the options Interface=definition or Interface=definitions.
>   - can be used in combination with the HideChildFunctions option.
>   - can be set dynamically using session variables.
> - The filter will be cleared when no FunctionTypes option is specified or when the FunctionTypes option is set to an empty list of values.
> - Parent functions that do not match the filter but have child functions that match the filter will be displayed in the function tree to allow you to navigate to one of the child functions.

#### DataMiner Cube - Visual Overview: Shape that displays a page of the Visio drawing linked to a view, service or element will no longer be displayed when the element, service or view in question does not exist \[ID_33484\]

From now on, a shape that displays a page of the Visio drawing linked to a view, service or element (i.e. a shape with a shape data field of type VdxPage) will no longer be displayed when the view, service or element in question does not exist.

### DMS Automation

#### New subscript option 'ExtendedErrorInfo' \[ID_33306\]

The SubScriptOptions class now has an ExtendedErrorInfo property (default: false).

If an error occurs in a subscript with extended error info, the HadError property will be set to true. Calling the SubScript.GetErrorMessages method will then retrieve the actual error messages.

Example:

```csharp
var script = engine.PrepareSubScript("MySubScript");
script.ExtendedErrorInfo = true;
script.SelectScriptParam("Info", "{}");
script.SelectScriptParam("ProfileInstance", "{}");
script.SelectDummy("dummy1", dmaId, elementId);
script.StartScript();
if (script.HadError)
{
    string[] errors = script.GetErrorMessages();
    // Handle errors...
}
```

> [!NOTE]
> Up to now, when an element was not running, the following error message would be thrown:
>
> *Element {elementName} is not active, not available or does not exist*
>
> From now, when an element is not running, the following error message (in which elementState will have one of the following values: paused, stopped, in timeout or not active) will be thrown instead:
>
> *Element {elementName} is {elementState}*

### DMS web apps

#### Dashboards app: New sidebar icons to list private and shared dashboards \[ID_32854\]

In the sidebar, next to the *All dashboards* and *Recent dashboards* icons, there are now two new icons:

- *Private dashboards*, and
- *Shared dashboards*.

The first icon will only be available when there are private dashboards, the second icon will only be available when the DataMiner Agent is connected to the cloud and there are shared dashboards.

#### Ticketing app: Tickets can now be filtered on fields of type 'drop-down list' \[ID_33370\]

In the Ticketing app, tickets can now also be filtered on fields of type “drop-down list”.

#### Web apps - Data table component: Search box \[ID_33385\]

When you hover over a data table component (e.g. a GQI table), a search box will now appear in the bottom-right corner. When you enter a search string, a case-insensitive client-side search will be performed.

#### Web apps: Dashboards, app pages and app panels now all have a 'Fit to view' setting \[ID_33401\]

In the Dashboards app and the Application Framework, dashboards, app pages and app panels now all have a “Fit to view” setting that, when enabled, will make sure the items in question are automatically adapted to fit the screen.

#### Web apps - Data table component: Sorting, grouping and filtering options \[ID_33403\] \[ID_33433\] \[ID_33454\]

When you right-click a column header of a data table component (e.g. a GQI table), you will now be presented with a number of sorting, grouping and filtering options.

- To sort by the column in question, select a sort order (e.g. A \> Z, Z \> A, etc.).
- To group by the column in question, select *Group*.
- To filter the data in the table, construct a single or composite condition depending on the column type:

| Column type | Filter option |
|--|--|
| String/GUID | One or more of the following conditions (combined with OR):<br> - contains some text (case insensitive)<br> - does not contains some text (case insensitive)<br> - matches a regular expression<br> - does not match a regular expression<br> - equals some text (case insensitive)<br> - does not equal some text (case insensitive) |
| Numeric/DateTime | One or more ranges (combined with OR) |
| Boolean | True or false |

> [!NOTE]
>
> - You can specify multiple column filters. If you do, they will be combined with AND.
> - Column filters can be used in combination with the component’s search box.
> - Grouping and column filters are not persistent. When you leave the page, all grouping and filtering will be cleared.

#### Web apps - Data table component: Copy cell/row/column/table \[ID_33440\]

When you right-click a non-empty cell in a data table component (e.g. a GQI table), you can now choose to copy the cell value, the entire row, the entire column or the entire table.

If you choose to copy the entire row or the entire table, the data will be copied in CSV format.

> [!NOTE]
>
> - If you copy a cell or an entire column, the values will not be enclosed in double quotes.
> - If you copy an entire row or an entire table, the values will be enclosed in double quotes.
> - If a value contains double quotes, they will be escaped upon copying.

### DMS Service & Resource Management

#### ReservationInstanceType and ServiceDefinitionType: New values 'ResourceScheduling' and 'ResourceOrchestration' \[ID_33390\]

ReservationInstanceType and ServiceDefinitionType can now be set to the following additional values:

- ResourceScheduling
- ResourceOrchestration

### DMS tools

#### VerifyClusterPorts.dmupgrade package can no longer be run on a single DMA \[ID_33429\]

The VerifyClusterPorts package can be used to check whether all agents of a DataMiner System are able to reach all other agents in the same DataMiner System over the ports used by NATS. This way, firewall configuration issues between servers can easily be detected.

When you run the package on a single agent, the results may be incorrect or confusing. From now on, the package will report an error when you try to run it on a single agent.

## Changes

### Enhancements

#### Security enhancements \[ID_33242\] \[ID_33365\] \[ID_33373\] \[ID_33479\]

A number of security enhancements have been made.

#### SLPort: Enhanced performance when processing large HTTP responses \[ID_33128\]

Because of a number of enhancements, overall performance of SLPort has increased when processing large HTTP responses.

#### SLProtocol: SetParameterIndexByKey and SetParametersIndexByKey methods can now also be used to update a single cell \[ID_33198\]

From now on, the SetParameterIndexByKey and SetParametersIndexByKey methods can also be used to update a single cell.

#### DataMiner upgrade will not be performed if NATS is not installed and running \[ID_33304\]

<!-- MR 10.3.0 - FR 10.2.7 -->
<!-- Also added to MR 10.2.0 [CU14] -->

When you launch a DataMiner upgrade, from now on, the upgrade process will not be allowed to start if NATS is not installed and running.

> [!NOTE]
> This check will be skipped if the current DataMiner version is older than version 10.1.0.

#### SLDMS will now use less memory when storing service information \[ID_33318\]

Because of a number of enhancements, the SLDMS process will now use less memory when storing service information.

#### QADeviceSimulator: Enhanced CPU usage when running SNMPv3 simulations \[ID_33376\]

Because of a number of enhancements, overall CPU usage of the QADeviceSimulator has improved when running SNMPv3 simulations.

> [!CAUTION]
> This tool is provided “As Is” with no representation or warranty whatsoever. Skyline Communications will not provide any maintenance or support for this tool.

#### Desktop app - Start window: Performance enhancements \[ID_33384\]

Because of a number of enhancements, overall performance has increased when opening the start window of the DataMiner Cube desktop app from the system tray icon.

#### Service & Resource Management: Function resources will no longer be deleted when their parent DVE element cannot be reached \[ID_33415\] \[ID_33668\]

From now on, the deletion of a function resource will be blocked when the deletion of its parent DVE element fails.

The ResourceManagerHelper now contains a new method to delete resources:

`public Resource[] RemoveResources(Resource[] resources, ResourceDeleteOptions options)`

> [!NOTE]
> Contributing resources can be deleted even when no parent element can be found. The parent element of a contributing resource is an enhanced service element. When the contributing booking is no longer running, the enhanced service element will no longer exist.

#### DataMiner Cube - Alarm Console: Pencil icon now identical to that used in Data Display tables \[ID_33442\]

The pencil icon used in the Alarm Console is now identical to that used in Data Display tables.

#### SLAnalytics: Enhanced performance when retrieving parameter information \[ID_33458\]

Because of a number of enhancements, overall performance has increased when retrieving parameter information.

#### Web apps: Enhancements with regard to the rendering of GQI tables \[ID_33463\]

A number of enhancements have been made with regard to the rendering of GQI tables.

#### SLDataGateway: Enhanced performance \[ID_33464\]

Because of a number of enhancements, overall performance of SLDataGateway has increased.

#### Alarm templates: All behavioral change points will now be considered anomalous \[ID_33476\]

From DataMiner 10.0.3 onwards, you can enable alarm monitoring on specific types of anomalies for parameters in an alarm template. Up to now, when you enabled this, an alarm was generated whenever the SLAnalytics engine considered a behavioral change point anomalous. From now on, all behavior change points will be considered anomalous and will hence trigger an alarm.

#### SLLogCollector will now also collect the VerifyClusterPorts files \[ID_33503\]

SLLogCollector will now also collect the following VerifyClusterPorts files:

- C:\\Skyline DataMiner\\Upgrades\\Helper\\VerifyClusterPorts\\VerifyClusterPorts.crash.txt
- C:\\Skyline DataMiner\\Upgrades\\Helper\\VerifyClusterPorts\\VerifyClusterPorts.LastRun.xml

#### DataMiner Cube: Enhanced performance when using the search box in the Cube header \[ID_33510\]

Because of a number of enhancements, overall performance has increased when using the search box in the Cube header.

#### SLLogCollector will now also collect the log files of the ArtifactDeployer, CloudFeed and Orchestrator processes \[ID_33514\]

SLLogCollector will now also collect the log files of the following cloud processes:

- ArtifactDeployer
- CloudFeed
- Orchestrator

#### QADeviceSimulator: Enhanced performance when loading a MySQL database at the start of a MySQL database simulation \[ID_33555\]

Because of a number of enhancements, overall performance of the QADeviceSimulator has improved when loading a MySQL database at the start of a MySQL database simulation.

Also, the overall memory footprint of MySQL database simulations has been reduced.

> [!CAUTION]
> This tool is provided “As Is” with no representation or warranty whatsoever. Skyline Communications will not provide any maintenance or support for this tool.

#### Frequency of smart baseline calculations is now configurable \[ID_33584\]

It is now possible to change the frequency of smart baseline calculations. On systems that aggregate large amounts of data from parameters with smart baselines, it is recommended to increase this frequency, which is 5 minutes by default.

To change this setting, do the following:

1. Open the SLNetClientTest tool.
2. Go to *Advanced \> Options \> SLNet Options*.
3. Select the *SmartBaselineThreadTime* option and change its value.

Minimum value: 1 minute - Default value: 5 minutes

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### SLElement: Enhanced performance when processing service and DCF information \[ID_33635\]

Because of a number of enhancements, overall performance of SLElement has improved when processing service and DCF information.

### Fixes

#### Protocol QActions: Problem when calling FillArray or FillArrayNoDelete with List\<object\[\]\> as columns value \[ID_28573\]

When, in a QAction, protocol.FillArray or protocol.FillArrayNoDelete were called with List\<object\[\]\> as columns value, an exception would be thrown.

#### DataMiner Cube - Logging: Entries in the 'Communication' tab would not get cleaned up as long as System Center was kept open \[ID_33085\]

When, in *System Center*, you opened the *Logging* section, entries would be added in the *Communication* tab as long as *System Center* was kept open. The cleanup settings specified in *Settings \> Computer \> Advanced \> Communication* would incorrectly not be applied. On systems with a large amount of traffic, this could lead to memory problems.

From now on, the above-mentioned cleanup settings will be applied correctly.

#### Failover: Problem when updating agent states in the Failover subtag of DMS.xml \[ID_33160\]

In some cases, an error could occur when updating agent states in the Failover subtag in the DMS.xml file. This could cause both agents to try to go either offline or online.

#### Failover: Problem when the Cassandra service was unexpectedly started by DataMiner during setup \[ID_33161\]

When a Failover system was being set up, an error could occur when the Cassandra service was unexpectedly started by DataMiner.

#### Protocols: WebSocket ports incorrectly interpreted as HTTP ports \[ID_33220\]

When you created an element with a protocol in which a WebSocket connection was configured as shown in the example below, up to now, the connection would incorrectly be interpreted as an HTTP port instead of a WebSocket port.

```xml
<Connections>
  <Connection id="0" name="WebSocket Interface">
    <Http>
      <CommunicationOptions>
        <WebSocket>true</WebSocket>
        <NotifyConnectionPIDs>
          <Connections>6</Connections>
        </NotifyConnectionPIDs>
      </CommunicationOptions>
    </Http>
  </Connection>
</Connections>
```

#### DataMiner Cube - Alarm Console: Incorrect values shown in summary alarms \[ID_33238\]

When, in the Alarm Console, you enable the alarm storm mode, the alarms are grouped into one summary alarm per parameter. In some rare cases, the values shown in those summary alarms could be incorrect.

#### DataMiner Cube - Trending: Legend would incorrectly show a unit when hovering over an exception value \[ID_33280\]

When, in a trend graph, you hovered the mouse pointer over an exception value, the legend would not only show the minimum value, the maximum value and the value of the data point, but also incorrectly a unit. From now on, when you hover over an exception value, the legend will no longer show a unit.

#### SLAnalytics - Automatic incident tracking: Incorrect error message would be generated [ID_33305]

<!-- MR 10.3.0 - FR 10.2.7 -->

In some cases, the following incorrect error message would be generated:

```txt
Ignoring alarm group update: unknown alarm group tree.
```

#### Values in a decimal logger table column would lose their decimals when the element was restarted or the database was queried \[ID_33315\]

When, in a logger table, a column with \<ColumnDefinition>DECIMAL\</ColumnDefinition> contained a value with decimals, then those decimals would be lost when the element was restarted or the database was queried.

#### DataMiner Cube - Alarm Console: Problem when playing a spectrum recording \[ID_33335\]

When, in the Alarm Console, you right-clicked an alarm on a spectrum element and selected *Open \> Spectrum recording*, the recording would incorrectly not be played. The spectrum element was opened instead.

#### SNMP forwarding: Problem with OID logging \[ID_33338\]

In the SNMP Managers log, in some cases, OIDs would incorrectly be replaced by hexadecimal numbers.

Also, when a table column contained an OID in an incorrect format, the table would only contain the first row up to the column with that incorrectly formatted OID. The rest of the rows would be missing. From now on, when an incorrectly formatted OID is detected, the table will no longer contain any data and Stream Viewer will show an error containing the OID in question.

#### Incorrect IP address could be added to DMS.xml during a DataMiner startup \[ID_33339\]

When the DataMiner software started up on an agent that was not part of a Failover setup, in some cases, an incorrect IP address could get added to the DMS.xml file. Later on, this could lead to e.g. agent synchronization issues.

#### SLCloud.xml files would incorrectly refer to the local agent using the IP address instead of the hostname when the agents were configured to use HTTPS \[ID_33342\]

When, in a DataMiner System, agents were configured to use HTTPS, the SLCloud.xml files of each of those agent would incorrectly refer to the local agent using the IP address instead of the hostname.

#### SLAnalytics: The automatic incident tracking feature would incorrectly not be disabled when the alarm focus feature was disabled [ID_33348]

<!-- MR 10.3.0 - FR 10.2.7 -->

When the alarm focus feature was disabled, up to now, the automatic incident tracking feature would not automatically be disabled as well. From now on, when the alarm focus feature is disabled, the automatic incident tracking feature will also be disabled.

#### DataMiner Cube: No longer possible to go to the previous or the next frame after pausing a replay of a spectrum recording \[ID_33349\]

When you paused a replay of a spectrum recording, in some cases, it would no longer be possible to go to either the previous or the next frame.

#### DataMiner upgrades: Problems related to upgrade prerequisites \[ID_33353\]

A number of issues were solved related to how DataMiner executes prerequisites as part of a DataMiner upgrade.

#### Automation scripts would incorrectly succeed even when uploading a report had failed \[ID_33368\]

When, in an Automation script, you had configured an action that uploads a report to a shared folder or FTP, up to now, the script would still succeed even when it had not been able to copy the generated report to the remote location (shared folder or FTP). From now on, when a script is not able to copy a report to a remote location, it will fail.

#### Web apps: Only part of the value would be selected when moving the mouse pointer over a selection box that had the focus \[ID_33379\]

When you moved the mouse pointer over a selection box that had the focus, in some cases, only part of the value would be selected.

#### DataMiner Cube - Alarm Console: Incidents would incorrectly appear when enabling 'Automatic incident tracking' in an Information tab \[ID_33382\]

When you enabled the *Automatic incident tracking* option in an Information tab, the incidents (i.e. alarm groups) would incorrectly appear in that tab.

#### DataMiner Cube: Casing incorrectly not taken into account when comparing the name of a newly created property against the existing property names \[ID_33388\]

When you created a new view, element, service or alarm property, up to now, the name of that new property would be checked against all existing property names without taking the casing into account. From now on, when the name of a newly created property is checked against existing property names, the casing will be taken into account.

#### SLAnalytics: Problem when predicting the trend of a history set parameter \[ID_33389\]

Up to now, negative status values in the trend data due to element restarts could cause the trend prediction engine to incorrectly interpret the trend data of a history set parameter.

#### Protocols: Mediation base protocols not available to DVE elements \[ID_33392\]

When a base protocol for a DVE element was configured at runtime, up to now, that base protocol would incorrectly only be taken into account after a DataMiner restart.

Also, after a DataMiner restart, only the base protocols of the main DVE element would be made available, even in situations where DVE child elements did not have the same base protocols as the DVE main element.

#### Protocols: \<UserSettings> element would not be taken into account when a new element was created \[ID_33394\]

When a protocol.xml file using the latest \<Connections> syntax contained a \<UserSettings> element, the user settings specified in the \<UserSettings> element would incorrectly not be taken into account when a new element was created.

#### Errors when different protocol selection for element was incompatible with existing SNMPv1 connection \[ID_33406\]

When a different protocol was selected for an element, causing one of the connections to no longer be compatible with SNMPv1, this could cause "Element not known yet" errors during polling and potentially even RTEs. To prevent this, the element will now be placed in an error state in such a case.

#### Service & Resource Management: Primary key of FunctionResource would be set to an invalid value after an update \[ID_33412\]

When an existing FunctionResource object was updated, in some cases, the primary key would be set to an invalid value.

#### Problems related to alarms \[ID_33413\]

A number of alarm-related issues have been fixed:

- When advanced naming was configured to create a display key that contained parameters from linked tables, in some cases, the service impact of the alarms would be incorrect.

- When a new row was added to a table, in some cases, the conditional monitoring based on service impact alarming would be incorrect.
- In some cases, alarms retrieved from the database would contain outdated fields in the alarm tree.

#### Dashboards app - GQI: Values of profile parameters without decimals defined would incorrectly be replaced by the maximum integer value \[ID_33418\]

When a profile parameter of type “number” had no decimals defined, its value would incorrectly be displayed as the maximum value that can be assigned to a parameter of type integer. From now on, when a profile parameter has no decimals defined, its value will be displayed as is, without decimals.

#### Interactive Automation scripts: Range limits of a numeric IBlockDefinition would be ignored \[ID_33419\]

When an Automation script was launch from the Dashboards app or from a custom web app, in some cases, the range limits of a numeric IBlockDefinition would be ignored when you clicked the Up or Down button.

#### Automation scripts: Problem with processor directives \[ID_33424\]

Up to now, the following preprocessor directives would incorrectly be inserted into the Automation script code, causing syntax errors to appear on the incorrect lines.

- #define DBInfo
- #define DCFv1
- #define ALARM_SQUASHING

#### Log entry containing an incorrect number of timers would be added to the element log file when an element was stopped \[ID_33438\]

When you stopped an element, an entry containing an incorrect number of timers would be added to the element log file. See the example below.

```txt
CProtocol::HaltPolling|INF|0|-- -7599514566606716925 timers to stop
```

#### DataMiner Cube - Visual Overview: No longer possible to filter Alarm Console tabs when clicking an AlarmFilter shape \[ID_33443\]

If you add a shape data field of type *AlarmFilter* to a shape, clicking the shape will cause Alarm Console tabs of type *Active alarms linked to cards* only to show alarms that match the alarm filter specified in the field value. However, in some cases, this no longer worked.

#### Ticketing app: Problem with ticket domains incorrectly marked as masked \[ID_33449\]

If, in the Ticketing app, you tried to edit a ticket of a domain linked to an element, in some cases, that domain would incorrectly be marked as “masked”.

#### Problem when trying to migrate elements of which the name contained square brackets \[ID_33455\]

When you tried to migrate an element with a name containing square brackets (e.g. “\[HQ\] Main Switch”), in some cases, the operation could fail with an error message like “Illegal 'Reference Protocol' syntax”.

#### DataMiner Cube - Visual Overview: Problems with History Mode shape data field \[ID_33456\]

When a shape linked to a parameter had a *History Mode* shape data field set to “State=On”, in some cases, no units would be shown. Also, in case of a parameter with discreet values, the shape would incorrectly show the actual value instead of the display value.

#### Interactive Automation scripts: Tree view component would incorrectly collapse when selecting an item that unselected the previously selected item \[ID_33480\]

When, in a tree view component of an interactive Automation script, you selected an item that unselected the previously selected item, in some cases, the entire tree view component would incorrectly collapse.

#### Problem when running multiple GQI queries simultaneously \[ID_33482\]

When multiple GQI queries were run simultaneously, in some rare cases, a “There are no open sessions” exception could be thrown.

#### Issues with NATS request/response actions \[ID_33487\]

A number of issues with NATS request/response actions have been solved.

#### Automation: SetParameterByPrimaryKey would fail to update a write-only parameter when using the parameter name as argument \[ID_33511\]

When, from an Automation script, a write parameter in a column of a table inside an element was updated using a ScriptDummy.SetParameterByPrimaryKey call with the parameter name as argument, the update would fail when that write parameter did not have a matching read parameter.

#### Service & Resource Management: Problem when booking all concurrency of a resource \[ID_33516\]

Up to now, booking all concurrency of a resource would not work correctly if a ServiceResourceUsageDefinition object was used to add the resource to the booking.

#### Problem when deleting a DVE child element or a virtual function \[ID_33519\]

When a DVE child element or a virtual function was deleted, all data related to the main DVE element and the other DVE child elements and virtual functions would incorrectly also be deleted from the service cache. As a result, alarm updates would no longer affect the services.

#### VerifyClusterPorts.dmupgrade package failed to run when it no longer had its original name \[ID_33529\]

When the VerifyClusterPorts.dmupgrade package no longer had its original name (e.g. “VerfiyClusterPorts (1).dmupgrade”), it would fail to run.

From now on, the name of the package is allowed to have a prefix and/or a suffix. In other words, its name must match \*VerifyClusterPorts\*.dmupgrade.

#### Problem with SLDataGateway when updating parameters \[ID_33535\]

In some cases, an error could occur in SLDataGateway when updating parameters.

#### Ticketing app: Problem when trying to add a value to the State field of a ticket domain \[ID_33537\]

When you tried to add a new value to the State field of a ticket domain, the following error would be thrown when the change was saved:

```txt
Error trapped: Unable to cast object of type 'Skyline.DataMiner.Web.Common.v1.DMATicketFieldPossibleValue' to type 'Skyline.DataMiner.Web.Common.v1.DMATicketStateFieldPossibleState'.
```

#### Problem with SLElement when updating bubble-up levels \[ID_33542\]

In some rare cases, an error could occur in SLElement when updating the bubble-up levels.

#### DataMiner Cube - Resources app: prevent updating new unsaved resource with updated existing resource \[ID_33543\]

In some cases, when the data related to a newly created resource was not yet saved on the DataMiner Agent, in the UI, that data would incorrectly be replaced by data related to another resource.

#### Booking instance created before DMA restart not starting \[ID_33556\]

In some cases, it could occur that a booking instance did not start. More specifically, this happened if the booking instance was created with a start time in the future, and the hosting Agent of the instance was restarted before that start time. After the Agent restart, the booking instance was not immediately loaded into the cache of the hosting Agent. If the custom properties of the booking instance were then updated, but no other updates happened to the booking instance before its start time, it would not start.

#### Problem in SLSNMPManager when element using SNMP polling was stopped \[ID_33563\]

When an element using SNMP polling was stopped, a problem could occur in the SLSNMPManager process. The cause of this was that the polling did not stop and requests kept being sent, leading to a stack overflow. To prevent this, now an error has been added when data is requested while the polling is halted.

#### DataMiner Cube desktop app: Problem when installed by means of an MSI package \[ID_33590\]

When using a DataMiner Cube desktop application that had been installed by means of an MSI package, in some cases, the following errors could be thrown:

- *The required version is not available.*
- *Value cannot be null.*

#### SLDataGateway: Communication via NATS could get stopped when a large number of parameter changes were being processed \[ID_33731\]

When a large number of parameter changes were being processed, up to now, communication entering or leaving SLDataGateway via NATS could get stopped.
