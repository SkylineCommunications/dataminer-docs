---
uid: General_Main_Release_10.1.0_CU16
---

# General Main Release 10.1.0 CU16

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### QActionTable class - FillArray and FillArrayNoDelete methods: Argument 'row' renamed to 'columns' \[ID_33034\]

The *row* argument of the FillArray and FillArrayNoDelete methods in theQActionTable class has been renamed to *columns*.

#### SLPort: Enhanced performance when processing large HTTP responses \[ID_33128\]

Because of a number of enhancements, overall performance of SLPort has increased when processing large HTTP responses.

#### SLProtocol: SetParameterIndexByKey and SetParametersIndexByKey methods can now also be used to update a single cell \[ID_33198\]

From now on, the SetParameterIndexByKey and SetParametersIndexByKey methods can also be used to update a single cell.

#### Ticketing app: Tickets can now be filtered on fields of type 'drop-down list' \[ID_33370\]

In the Ticketing app, tickets can now also be filtered on fields of type “drop-down list”.

#### DataMiner Cube - Visual Overview: Shape that displays a page of the Visio drawing linked to a view, service or element will no longer be displayed when the element, service or view in question does not exist \[ID_33484\]

From now on, a shape that displays a page of the Visio drawing linked to a view, service or element (i.e. a shape with a shape data field of type VdxPage) will no longer be displayed when the view, service or element in question does not exist.

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

#### DataMiner Cube - Logging: Entries in the 'Communication' tab would not get cleaned up as long as System Center was kept open \[ID_33085\]

When, in *System Center*, you opened the *Logging* section, entries would be added in the *Communication* tab as long as *System Center* was kept open. The cleanup settings specified in *Settings \> Computer \> Advanced \> Communication* would incorrectly not be applied. On systems with a large amount of traffic, this could lead to memory problems.

From now on, the above-mentioned cleanup settings will be applied correctly.

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

#### Replicated main DVE element would incorrectly execute a sequence twice \[ID_33270\]

When, inside a replicated DVE parent element, the exporting DVE table that contained the column with DVE element IDs also contained a column with a \<Sequence>, then that sequence would incorrectly be executed twice on the replicated element.

#### DataMiner Cube - Trending: Legend would incorrectly show a unit when hovering over an exception value \[ID_33280\]

When, in a trend graph, you hovered the mouse pointer over an exception value, the legend would not only show the minimum value, the maximum value and the value of the data point, but also incorrectly a unit. From now on, when you hover over an exception value, the legend will no longer show a unit.

#### Values in a decimal logger table column would lose their decimals when the element was restarted or the database was queried \[ID_33315\]

When, in a logger table, a column with \<ColumnDefinition>DECIMAL\</ColumnDefinition> contained a value with decimals, then those decimals would be lost when the element was restarted or the database was queried.

#### SNMP forwarding: Problem with OID logging \[ID_33338\]

In the SNMP Managers log, in some cases, OIDs would incorrectly be replaced by hexadecimal numbers.

Also, when a table column contained an OID in an incorrect format, the table would only contain the first row up to the column with that incorrectly formatted OID. The rest of the rows would be missing. From now on, when an incorrectly formatted OID is detected, the table will no longer contain any data and Stream Viewer will show an error containing the OID in question.

#### Incorrect IP address could be added to DMS.xml during a DataMiner startup \[ID_33339\]

When the DataMiner software started up on an agent that was not part of a Failover setup, in some cases, an incorrect IP address could get added to the DMS.xml file. Later on, this could lead to e.g. agent synchronization issues.

#### Automation scripts would incorrectly succeed even when uploading a report had failed \[ID_33368\]

When, in an Automation script, you had configured an action that uploads a report to a shared folder or FTP, up to now, the script would still succeed even when it had not been able to copy the generated report to the remote location (shared folder or FTP). From now on, when a script is not able to copy a report to a remote location, it will fail.

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

#### Problem when trying to migrate elements of which the name contained square brackets \[ID_33455\]

When you tried to migrate an element with a name containing square brackets (e.g. “\[HQ\] Main Switch”), in some cases, the operation could fail with an error message like “Illegal 'Reference Protocol' syntax”.

#### Automatic Incident Tracking: Clearable base alarms of an incident were cleared when the incident was cleared \[ID_33481\]

When an incident (i.e. alarm group) was cleared, in some cases, its clearable base alarms would incorrectly be cleared as well when the AutoClear option was disabled.

#### Automation: SetParameterByPrimaryKey would fail to update a write-only parameter when using the parameter name as argument \[ID_33511\]

When, from an Automation script, a write parameter in a column of a table inside an element was updated using a ScriptDummy.SetParameterByPrimaryKey call with the parameter name as argument, the update would fail when that write parameter did not have a matching read parameter.

#### Problem when deleting a DVE child element or a virtual function \[ID_33519\]

When a DVE child element or a virtual function was deleted, all data related to the main DVE element and the other DVE child elements and virtual functions would incorrectly also be deleted from the service cache. As a result, alarm updates would no longer affect the services.

#### Problem with SLElement when updating bubble-up levels \[ID_33542\]

In some rare cases, an error could occur in SLElement when updating the bubble-up levels.

#### Problem in SLSNMPManager when element using SNMP polling was stopped \[ID_33563\]

When an element using SNMP polling was stopped, a problem could occur in the SLSNMPManager process. The cause of this was that the polling did not stop and requests kept being sent, leading to a stack overflow. To prevent this, now an error has been added when data is requested while the polling is halted.
