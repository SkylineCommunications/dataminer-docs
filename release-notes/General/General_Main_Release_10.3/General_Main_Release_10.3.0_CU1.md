---
uid: General_Main_Release_10.3.0_CU1
---

# General Main Release 10.3.0 CU1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLAnalytics: Number of 'GetParameterMessages' requests has been optimized [ID_34936]

<!-- MR 10.3.0 [CU1] - FR 10.3.1 -->

The number of *GetParameterMessages* sent by SLAnalytics in order to check whether a trended table parameter is still active has been optimized.

#### Cassandra Cluster: Enhanced query performance [ID_35247]

<!-- MR 10.3.0 [CU1] - FR 10.3.3 -->

Previously, queries against Cassandra Cluster would always be executed with a page size of 1000, even when the limit defined in the query was smaller than 1000. This resulted in excess data being returned. From now on, the page size will be adjusted according to the limit defined in the query if it is lower than the default page size.

This change will considerably improve overall query performance, especially when retrieving trend data.

> [!NOTE]
> This change will not enhance performance when requesting trend data for an element that has no trend data points before the requested window. In cases like this, the full two-year range of shards will be queried to try and find an initial point.

#### Enhanced performance when creating or editing services [ID_35366]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Because of a number of enhancements made with regard to the communication between SLDataMiner and SLDMS, overall performance has increased when creating or editing services, especially in heavily loaded environments.

#### Enhanced SNMP trap distribution [ID_35480]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

From now on, stopped elements will no longer be taken into account when distributing SNMP traps. When a trap has to be sent to an element on another DataMiner Agent, it will no longer be sent when that element is stopped.

#### SLAnalytics - Automatic incident tracking: Focus value updates will no longer be taken into account when determining whether the maximum group event rate was exceeded [ID_35545]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

From now on, focus value updates will no longer be taken into account when determining whether the *Maximum group event rate* was exceeded.

#### Security enhancements [ID_35667]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

A number of security enhancements have been made.

#### SLLogCollector now also collects output of 'netstat -ano' command [ID_35674]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

SLLogCollector packages will now also include the following additional file:

| File | Contents |
|------|----------|
| Logs\Network Information\Netstat.exe -ano.txt | The output of an `netstat -ano` command. |

### Fixes

#### Memory leak in SLNet after closing a client connection that had been using a "SLDataGateway.API" subscription set [ID_35319]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a client connection that had been using a "SLDataGateway.API" subscription set was closed, in some rare cases, the subscription object memory would incorrectly not get cleaned up.

#### Problem with SLElement when stopping an EPM element [ID_35439]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1]  - FR 10.3.3 -->

When an EPM element was stopped, in some rare cases, an error could occur in SLElement.

#### SLAnalytics - Behavioral anomaly detection: Two identical behavioral anomaly alarms would incorrectly be created [ID_35511]

<!-- MR 10.3.0 [CU1] - FR 10.3.3 -->

In some cases, two identical behavioral anomaly alarms would incorrectly be created.

#### SLAnalytics : Problem after a DVE parent element had been deleted [ID_35521]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.3 -->

In some cases, an error could occur in the SLAnalytics process after a DVE parent element had been deleted.

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
