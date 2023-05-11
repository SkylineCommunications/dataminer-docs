---
uid: General_Feature_Release_10.3.4
---

# General Feature Release 10.3.4

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.4](xref:Cube_Feature_Release_10.3.4).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.4](xref:Web_apps_Feature_Release_10.3.4).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

#### Correlation alarms will now by default contain the value of the alarm property by which they are grouped [ID_35583]

<!-- MR 10.4.0 - FR 10.3.4 -->

When a correlation rule is configured to use alarm grouping via an alarm property, from now on, the value of the alarm property by which the alarms are grouped will now by default be added to the correlated alarm.

If you do not want the alarm property value to be added to the correlation alarm, then you can disable this behavior by adding the `NewAlarmOptions.DisableGroupedProperty` flag to the `NewAlarmActionDefinition.Properties` using the *SLNetClientTest* tool.

> [!WARNING]
> Always be extremely careful when using the *SLNetClientTest* tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

## Changes

### Enhancements

#### SLXML no longer used to read out element data [ID_33515] [ID_33616] [ID_33625] [ID_33659]

<!-- MR 10.4.0 - FR 10.3.4 -->

From now on, SLXML will no longer be used to read out the following files containing element data:

- *Element.xml* files
- *ElementData.xml* files
- *EPMConfig.xml* files
- *Description.xml* files
- *Ports.xml* files

> [!IMPORTANT]
> This is a breaking change. Make sure that none of the protocols in your system is using the following deprecated Notify types:
>
> - DMS_GET_INFO
> - DMS_GET_INFO_ALL
> - NT_ADD_DESCRIPTION_FILE
> - NT_GET_ITEM_DATA
> - NT_GET_PARAMETER_BY_DATA
> - NT_GET_XML_COOKIE
> - NT_RELOAD_ELEMENT
> - NT_SET_ITEM_DATA
> - NT_SET_PARAMETER_BY_DATA

#### Enhanced performance when creating or editing services [ID_35366]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Because of a number of enhancements made with regard to the communication between SLDataMiner and SLDMS, overall performance has increased when creating or editing services, especially in heavily loaded environments.

#### Security enhancements [ID_35434] [ID_35667]

<!-- 35434: MR 10.4.0 - FR 10.3.4 -->
<!-- 35667: MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

A number of security enhancements have been made.

#### SLAnalytics - Pattern matching: Enhanced performance when detecting large patterns [ID_35474]

<!-- MR 10.4.0 - FR 10.3.4 -->

Because of a number of enhancements, overall performance has increased when detecting trend patterns that cover more than 30,000 data points.

#### Enhanced SNMP trap distribution [ID_35480]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

From now on, stopped elements will no longer be taken into account when distributing SNMP traps. When a trap has to be sent to an element on another DataMiner Agent, it will no longer be sent when that element is stopped.

#### SLAnalytics - Automatic incident tracking: Enhanced performance when fetching relation information [ID_35508]

<!-- MR 10.4.0 - FR 10.3.4 -->

Because of a number of enhancements, overall performance has increased when fetching relation information for the automatic incident tracking feature.

#### SLAnalytics - Automatic incident tracking: Focus value updates will no longer be taken into account when determining whether the maximum group event rate was exceeded [ID_35545]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

From now on, focus value updates will no longer be taken into account when determining whether the *Maximum group event rate* was exceeded.

#### SLAnalytics will now send regular notifications instead of client notifications [ID_35591]

<!-- MR 10.4.0 - FR 10.3.4 -->

Up to now, when SLAnalytics sent a notification, it would generate an event of type *client notification* with parameter ID 64574. From now on, it will instead generate an event of type *notification* with parameter ID 64570.

#### DataMiner upgrade: Additional prerequisite will now check for incompatible connectors [ID_35605]

<!-- MR 10.4.0 - FR 10.3.4 -->

When you start a DataMiner upgrade, the `ValidateConnectors` prerequisite will now scan the system for any connectors that are known to be incompatible with the DataMiner version to which the DataMiner Agent is being upgraded. If such connectors are found, they will have to be removed before you can continue with the upgrade.

#### SLLogCollector now also collects output of 'netstat -ano' command [ID_35674]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

SLLogCollector packages will now also include the following additional file:

| File | Contents |
|------|----------|
| Logs\Network Information\Netstat.exe -ano.txt | The output of an `netstat -ano` command. |

#### SLAnalytics - Proactive cap detection: Enhanced accuracy [ID_35695]

<!-- MR 10.4.0 - FR 10.3.4 -->

Proactive cap detection predicts future issues based on trend data in the Cassandra database. Because of a number of enhancements, overall prediction accuracy has increased.

#### Service & Resource Management: Bookings of type 'Custom Process Automation' no longer consume license credits [ID_35742]

<!-- MR 10.4.0 - FR 10.3.4 -->

From now on, ReservationInstances of type *Custom Process Automation* will no longer consume SRM credits. This means that, from now on, you can schedule an unlimited number of concurrent bookings of type *Custom Process Automation*.

### Fixes

#### Memory leak in SLNet after closing a client connection that had been using a "SLDataGateway.API" subscription set [ID_35319]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a client connection that had been using a "SLDataGateway.API" subscription set was closed, in some rare cases, the subscription object memory would incorrectly not get cleaned up.

#### Failover: Profile Manager would incorrectly not be initialized on the agent that was brought online [ID_35534]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a failover was triggered, in some rare cases, the Profile Manager would incorrectly not be initialized on the agent that was brought online.

In the Alarm Console, an error would appear with the following message:

```txt
Unexpected exception while triggering failover for BaseProfileManager: Skyline.DataMiner.Net.ManagerStore.CrudFailedException: Exception of type 'Skyline.DataMiner.Net.ManagerStore.CrudFailedException' was thrown.
```

#### Problem when modifying the production version of a protocol with an SNMPv3 connection [ID_35538]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you modified the production version of a protocol with multiple connections, of which one was an SNMNv3 connection, in some cases, the element could lose its SNMPv3 port settings. As a result, the SLSNMPManager process would fail to initialize the SNMPv3 communication, and the following alarm would appear in the Alarm Console:

```txt
Error parsing SNMPv3 password for port: <port number> on element: <element name>
```

Also, an error could occur in SLDataMiner when you tried to re-enter the SNMPv3 port settings.

#### SLAnalytics - Automatic incident tracking: Alarm groups could incorrectly be created without a focus value [ID_35551]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

In some cases, alarm groups could incorrectly be created without a focus value.

#### Problem with parameter update throttling when subscribing to column parameters [ID_35578]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a client subscribed on a column parameter with a filter as index (e.g. *), the messages would be throttled incorrectly.

From now on, parameter update throttling can be disabled by setting the *MessageThrottlingThreshold* option to -1 in the *MaintenanceSettings.xml* file.

```xml
<MaintenanceSettings>
  ...
  <SLNet>
    ...
    <MessageThrottlingThreshold>-1</MessageThrottlingThreshold>
    ...
  </SLNet>
  ...
</MaintenanceSettings>
```

#### When retrieving the protocol of a DVE parent element, its alarm filter would not get returned correctly for some of its parameters that are exported as standalone parameters [ID_35607]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a client retrieved the protocol of a DVE parent element, its alarm filter would not get returned correctly for some of its parameters that are exported as standalone parameters.

#### A number of alarm-related issues have been fixed [ID_35611]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

A number of alarm-related issues have been fixed:

- In some cases, the alarm that closed an alarm tree would incorrectly not contain the root GUID.
- If no comment was passed when an alarm was cleared, in some cases, the comment of the previous alarm would incorrectly not be added to the closing alarm.
- In some cases, an incorrect `Alarm didn't have the correct format.` error would be logged.

#### Service & Resource Management: ResourceManager module could briefly be uninitialized during a midnight synchronization [ID_35621]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

During a midnight synchronization, in some cases, the ResourceManager module could briefly be uninitialized.

The logging indicating the start and the end of the initialization, synchronization and cache load of the ResourceManager module has now been changed from log level 4 to log level 0.

#### SLAnalytics - Behavioral anomaly detection: Suggestion events or alarm events for change points of type 'flatline' would not get cleared [ID_35645]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When SLAnalytics was stopped while suggestion events or alarm events for change points of type *flatline* were still open, these events would stay open until they were cleared manually. From now on, suggestion events or alarm events for change points of type *flatline* will automatically be cleared as soon as SLAnalytics has restarted.

#### SLAnalytics - Behavioral anomaly detection: An upward level shift directly followed by a downward level shift would incorrectly get categorized as an "unlabeled" change event [ID_35646]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

When an upward level shift was directly followed by a downward level shift, in some cases, that change would incorrectly get categorized as an "unlabeled" change event.

#### SLAnalytics - Automatic incident tracking: Problem with duplicate alarms [ID_35664]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Up to now, when the SLAnalytics process started, the entire focus data cache of the agent hosting the process was cleared and recreated, causing the automatic incident tracking feature to clear any incident associated with the alarms removed from the focus data cache. When the focus data was then regenerated later on, this could lead to a recreation of the same groups.

Also, when the SLAnalytics processes of different agents in the same cluster were restarted right before a full hour, it was possible to trigger the internal duplication of active alarms hosted on non-leader agents. This could, in turn, lead to an incorrect internal alarm state and incorrect incidents containing copies of the same alarm.

From now on, the focus data cache will no longer be cleared when SLAnalytics process starts up. Instead, only the focus data associated with the alarms that are no longer active will be removed from the cache.

#### Cassandra Cluster Migrator tool would incorrectly not migrate the state-changes table from a single-node Cassandra to a Cassandra Cluster [ID_35699]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.4 -->

When you used the Cassandra Cluster Migrator tool to migrate a single-node Cassandra database to a Cassandra Cluster setup, up to now, the `state-changes` table would incorrectly not be migrated.

#### Automation: DataMiner would incorrectly remove the xmlns attribute when importing or saving an Automation script [ID_35708]

<!-- MR 10.4.0 - FR 10.3.4 -->

When DataMiner imported or saved an Automation script, it would incorrectly remove the `xmlns` attribute specified in the `<DMSScript>` element, even when that attribute had been added by DataMiner Integration Studio. From now on, when DataMiner imports or saves an Automation script, it will no longer remove this attribute. Moreover, if no such attribute is specified, it will automatically add `xmlns="http://www.skyline.be/automation"`.

Example:

```xml
<DMSScript options="272" xmlns="http://www.skyline.be/automation">
   <Name>...</Name>
   ...
</DMSScript>
```

#### SLElement could leak memory when updating alarm templates containing conditions [ID_35728]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.4 -->

In some cases, SLElement could leak memory when updating alarm templates containing conditions.

#### SLAnalytics - Automatic incident tracking: Problem when starting up [ID_35731]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a large number of groups needed to be created while automatic incident tracking was starting up, the `A timeout of 00:01:00.0 occurred while processing message of type AlarmFloodMessage` error could be thrown, causing automatic incident tracking to not start up correctly.

#### Behavioral anomaly detection: Suggestion alarms would incorrectly be re-evaluated as normal alarms after a DataMiner restart [ID_35744]

<!-- MR 10.3.0 [CU1] - FR 10.3.4 -->

After a DataMiner restart, suggestion alarms would incorrectly be re-evaluated as normal alarms.

#### Memory leak in SLAnalytics [ID_35758]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU1] - FR 10.3.4 -->

In some cases, SLAnalytics kept on waiting on a database call, which eventually led to the process leaking memory.

#### Problem with SLElement when creating an alarm with an 'SLA Affecting' property [ID_35776]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

In some rare cases, an error could occur in SLElement when creating an alarm with an *SLA Affecting* property.

#### Input/output values of a matrix element would incorrectly be overridden due to a caching issue [ID_35857]

<!-- MR 10.4.0 - FR 10.3.4 [CU0] -->

When an ElementProtocol object was being created, due to a caching issue in SLNet, the input/output values stored in the protocol of a matrix element would incorrectly be overridden with the input/output values in the ElementProtocol object that was being created.

#### Message broker: Memory leak [ID_35898]

<!-- MR 10.4.0 - FR 10.3.4 [CU0] -->

The native message broker code could leak memory when using the request/response workflow in combination with chunking. The message handlers would not be cleaned up after the response had been received.

#### Handle in the Timer class would not be cleaned correctly [ID_35959]

<!-- MR 10.4.0 - FR 10.3.4 [CU0] -->

In some cases, a handle in the Timer class would not be cleaned correctly, causing handles to leak.
