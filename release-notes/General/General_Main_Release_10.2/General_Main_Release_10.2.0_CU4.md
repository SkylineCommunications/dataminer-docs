---
uid: General_Main_Release_10.2.0_CU4
---

# General Main Release 10.2.0 CU4

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements \[ID_33242\] \[ID_33373\] \[ID_33479\]

A number of security enhancements have been made.

#### New option to enable/disable DCF interface state calculation on system level \[ID_31591\]

On protocol level, you can enable or disable DCF interface state calculation by setting the Protocol.ParameterGroups.Group@calculateAlarmState attribute to either true or false.

From now on, you will also be able to enable or disable this setting on system level. To do so, open the C:\\Skyline DataMiner\\MaintenanceSettings.xml file and set the ProtocolSettings.DCF.CalculateAlarmState element to either true or false.

```xml
<MaintenanceSettings xmlns="http://www.skyline.be/config/maintenancesettings">
  <ProtocolSettings>
    <DCF>
      <CalculateAlarmState>false</CalculateAlarmState>
    </DCF>
  </ProtocolSettings>
</MaintenanceSettings>
```

> [!NOTE]
>
> - This setting can only be configured in MaintenanceSettings.xml.
> - When you change this setting, the change will only be applied after a DataMiner restart.
> - The protocol-level setting will overrule the system-level setting.

#### QActionTable class - FillArray and FillArrayNoDelete methods: Argument 'row' renamed to 'columns' \[ID_33034\]

The *row* argument of the FillArray and FillArrayNoDelete methods in theQActionTable class has been renamed to *columns*.

#### DataMiner Application Framework: Tooltips on sidebar of root page \[ID_33275\]

When you click the apps button in the top-left corner of the root page and then hover over an app in the app list, a tooltip will now show the name of that app.

#### SLPort: Enhanced performance when processing large HTTP responses \[ID_33128\]

Because of a number of enhancements, overall performance of SLPort has increased when processing large HTTP responses.

#### SLProtocol: SetParameterIndexByKey and SetParametersIndexByKey methods can now also be used to update a single cell \[ID_33198\]

From now on, the SetParameterIndexByKey and SetParametersIndexByKey methods can also be used to update a single cell.

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

#### Ticketing app: Tickets can now be filtered on fields of type 'drop-down list' \[ID_33370\]

In the Ticketing app, tickets can now also be filtered on fields of type “drop-down list”.

#### VerifyClusterPorts.dmupgrade package can no longer be run on a single DMA \[ID_33429\]

The VerifyClusterPorts package can be used to check whether all agents of a DataMiner System are able to reach all other agents in the same DataMiner System over the ports used by NATS. This way, firewall configuration issues between servers can easily be detected.

When you run the package on a single agent, the results may be incorrect or confusing. From now on, the package will report an error when you try to run it on a single agent.

#### SLDataGateway: Enhanced performance \[ID_33464\]

Because of a number of enhancements, overall performance of SLDataGateway has increased.

#### DataMiner Cube - Visual Overview: Shape that displays a page of the Visio drawing linked to a view, service or element will no longer be displayed when the element, service or view in question does not exist \[ID_33484\]

From now on, a shape that displays a page of the Visio drawing linked to a view, service or element (i.e. a shape with a shape data field of type VdxPage) will no longer be displayed when the view, service or element in question does not exist.

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

#### SLElement: Enhanced performance when processing service and DCF information \[ID_33635\]

Because of a number of enhancements, overall performance of SLElement has improved when processing service and DCF information.

### Fixes

#### Protocol QActions: Problem when calling FillArray or FillArrayNoDelete with List\<object\[\]\> as columns value \[ID_28573\]

When, in a QAction, protocol.FillArray or protocol.FillArrayNoDelete were called with List\<object\[\]\> as columns value, an exception would be thrown.

#### Problem with synchronization of SLAnalytics configuration settings \[ID_31825\]

In some cases, SLAnalytics configuration settings would be constantly synchronized among agents in a DataMiner System. From now on, automatic synchronization of SLAnalytics configuration settings will be limited to once an hour.

#### DataMiner Cube - Logging: Entries in the 'Communication' tab would not get cleaned up as long as System Center was kept open \[ID_33085\]

When, in *System Center*, you opened the *Logging* section, entries would be added in the *Communication* tab as long as *System Center* was kept open. The cleanup settings specified in *Settings \> Computer \> Advanced \> Communication* would incorrectly not be applied. On systems with a large amount of traffic, this could lead to memory problems.

From now on, the above-mentioned cleanup settings will be applied correctly.

#### Dashboards app: Selection in parameter feed would incorrectly be cleared whenever the linked EPM feed was updated \[ID_33153\]

When an EPM feed was linked to a parameter feed, in some cases, the current selection in the parameter feed would incorrectly be cleared whenever the EPM feed was updated.

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

#### Dashboards: Not possible to share dashboards that contained query components of which the 'Update data' option was enabled \[ID_33267\]

Up to now, it would not be possible for users to share dashboards that contained GQI components of which the *Update data* option was enabled.

#### Replicated main DVE element would incorrectly execute a sequence twice \[ID_33270\]

When, inside a replicated DVE parent element, the exporting DVE table that contained the column with DVE element IDs also contained a column with a \<Sequence>, then that sequence would incorrectly be executed twice on the replicated element.

#### DataMiner Cube - Trending: Legend would incorrectly show a unit when hovering over an exception value \[ID_33280\]

When, in a trend graph, you hovered the mouse pointer over an exception value, the legend would not only show the minimum value, the maximum value and the value of the data point, but also incorrectly a unit. From now on, when you hover over an exception value, the legend will no longer show a unit.

#### Values in a decimal logger table column would lose their decimals when the element was restarted or the database was queried \[ID_33315\]

When, in a logger table, a column with \<ColumnDefinition>DECIMAL\</ColumnDefinition> contained a value with decimals, then those decimals would be lost when the element was restarted or the database was queried.

#### DataMiner Cube - Alarm Console: Problem when playing a spectrum recording \[ID_33335\]

When, in the Alarm Console, you right-clicked an alarm on a spectrum element and selected *Open \> Spectrum recording*, the recording would incorrectly not be played. The spectrum element was opened instead.

#### SNMP forwarding: Problem with OID logging \[ID_33338\]

In the SNMP Managers log, in some cases, OIDs would incorrectly be replaced by hexadecimal numbers.

Also, when a table column contained an OID in an incorrect format, the table would only contain the first row up to the column with that incorrectly formatted OID. The rest of the rows would be missing. From now on, when an incorrectly formatted OID is detected, the table will no longer contain any data and Stream Viewer will show an error containing the OID in question.

#### Incorrect IP address could be added to DMS.xml during a DataMiner startup \[ID_33339\]

When the DataMiner software started up on an agent that was not part of a Failover setup, in some cases, an incorrect IP address could get added to the DMS.xml file. Later on, this could lead to e.g. agent synchronization issues.

#### DataMiner Cube: No longer possible to go to the previous or the next frame after pausing a replay of a spectrum recording \[ID_33349\]

When you paused a replay of a spectrum recording, in some cases, it would no longer be possible to go to either the previous or the next frame.

#### DataMiner upgrades: Problems related to upgrade prerequisites \[ID_33353\]

A number of issues were solved related to how DataMiner executes prerequisites as part of a DataMiner upgrade.

#### Automation scripts would incorrectly succeed even when uploading a report had failed \[ID_33368\]

When, in an Automation script, you had configured an action that uploads a report to a shared folder or FTP, up to now, the script would still succeed even when it had not been able to copy the generated report to the remote location (shared folder or FTP). From now on, when a script is not able to copy a report to a remote location, it will fail.

#### DataMiner Cube - Alarm Console: Incidents would incorrectly appear when enabling 'Automatic incident tracking' in an Information tab \[ID_33382\]

When you enabled the *Automatic incident tracking* option in an Information tab, the incidents (i.e. alarm groups) would incorrectly appear in that tab.

#### DataMiner Cube: Casing incorrectly not taken into account when comparing the name of a newly created property against the existing property names \[ID_33388\]

When you created a new view, element, service or alarm property, up to now, the name of that new property would be checked against all existing property names without taking the casing into account. From now on, when the name of a newly created property is checked against existing property names, the casing will be taken into account.

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

If you add a shape data field of type *AlarmFilter* to a shape, clicking the shape will cause Alarm Console tabs of type *Active alarms linked to cards* only to show alarms that match the alarm filter specified in the field value. However, in some cases, this no longer worked.

#### Problem when trying to migrate elements of which the name contained square brackets \[ID_33455\]

When you tried to migrate an element with a name containing square brackets (e.g. “\[HQ\] Main Switch”), in some cases, the operation could fail with an error message like “Illegal 'Reference Protocol' syntax”.

#### DataMiner Cube - Visual Overview: Problems with History Mode shape data field \[ID_33456\]

When a shape linked to a parameter had a *History Mode* shape data field set to “State=On”, in some cases, no units would be shown. Also, in case of a parameter with discreet values, the shape would incorrectly show the actual value instead of the display value.

#### Interactive Automation scripts: Tree view component would incorrectly collapse when selecting an item that unselected the previously selected item \[ID_33480\]

When, in a tree view component of an interactive Automation script, you selected an item that unselected the previously selected item, in some cases, the entire tree view component would incorrectly collapse.

#### Automatic Incident Tracking: Clearable base alarms of an incident were cleared when the incident was cleared \[ID_33481\]

When an incident (i.e. alarm group) was cleared, in some cases, its clearable base alarms would incorrectly be cleared as well when the AutoClear option was disabled.

#### Problem when running multiple GQI queries simultaneously \[ID_33482\]

When multiple GQI queries were run simultaneously, in some rare cases, a “There are no open sessions” exception could be thrown.

#### Automation: SetParameterByPrimaryKey would fail to update a write-only parameter when using the parameter name as argument \[ID_33511\]

When, from an Automation script, a write parameter in a column of a table inside an element was updated using a ScriptDummy.SetParameterByPrimaryKey call with the parameter name as argument, the update would fail when that write parameter did not have a matching read parameter.

#### Problem when deleting a DVE child element or a virtual function \[ID_33519\]

When a DVE child element or a virtual function was deleted, all data related to the main DVE element and the other DVE child elements and virtual functions would incorrectly also be deleted from the service cache. As a result, alarm updates would no longer affect the services.

#### VerifyClusterPorts.dmupgrade package failed to run when it no longer had its original name \[ID_33529\]

When the VerifyClusterPorts.dmupgrade package no longer had its original name (e.g. “VerfiyClusterPorts (1).dmupgrade”), it would fail to run.

From now on, the name of the package is allowed to have a prefix and/or a suffix. In other words, its name must match \*VerifyClusterPorts\*.dmupgrade.

#### Problem with SLElement when updating bubble-up levels \[ID_33542\]

In some rare cases, an error could occur in SLElement when updating the bubble-up levels.

#### DataMiner Cube - Resources app: prevent updating new unsaved resource with updated existing resource \[ID_33543\]

In some cases, when the data related to a newly created resource was not yet saved on the DataMiner Agent, in the UI, that data would incorrectly be replaced by data related to another resource.

#### Upgrading to DataMiner 10.2.0 Main Release did not install Microsoft .NET 5 \[ID_33557\]

Up to now, Microsoft .NET 5 would incorrectly not get installed when you upgraded to DataMiner 10.2.0 Main Release.

#### Problem in SLSNMPManager when element using SNMP polling was stopped \[ID_33563\]

When an element using SNMP polling was stopped, a problem could occur in the SLSNMPManager process. The cause of this was that the polling did not stop and requests kept being sent, leading to a stack overflow. To prevent this, now an error has been added when data is requested while the polling is halted.

#### DataMiner Cube desktop app: Problem when installed by means of an MSI package \[ID_33590\]

When using a DataMiner Cube desktop application that had been installed by means of an MSI package, in some cases, the following errors could be thrown:

- *The required version is not available.*
- *Value cannot be null.*
