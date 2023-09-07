---
uid: General_Main_Release_10.3.0_CU2
---

# General Main Release 10.3.0 CU2

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID_35668]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

A number of security enhancements have been made.

#### Alarms generated when a database goes in offload mode will now have severity 'Notice' instead of 'Critical' [ID_35749]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When a database went in offload mode, up to now, an alarm with severity *Critical* was generated. From now on, an alarm of severity *Notice* will be generated instead.

#### SLAnalytics will no longer disregard first-time alarm template assignments [ID_35794]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

Up to now, SLAnalytics only took into account changes to alarm templates that were already assigned to elements and disregarded first-time alarm template assignments.

From now on, SLAnalytics will also take into account first-time alarm template assignments.

#### SLAnalytics: Enhanced performance [ID_35871]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

Overall performance of SLAnalytics has increased because of a number of enhancements made to its caching mechanism.

### Fixes

#### SLLogCollector: Problem when collecting multiple memory dumps with the 'Now and when memory increases with X Mb' option [ID_35617]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When the *SLLogCollector* tool had to collect memory dumps of multiple processes with the *Now and when memory increases with X Mb* option, it would incorrectly only collect the memory dump of the first process that reached the specified Mb limit.

From now on, it will collect at least the "now" dump for each of the selected processes.

#### NATS would incorrectly be re-installed when a WMI query error occurred while the NATS installer was being run at DMA startup [ID_35647]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When the NATS installer was being run at DMA startup, in some cases, due to an issue with a WMI query, NATS could incorrectly be re-installed, even though NATS and NAS were already running.

From now on, the execution of the NATS installer at DMA startup will be skipped when NATS is already running. Also, if an error occurs when running a WMI query during the execution of the NATS installer, a message saying that the re-installation has failed will be added to the *SLUMSEndpointManager.txt* log file.

> [!NOTE]
> When an error occurs while running a WMI query, and no NATS/NAS service is running, NATS will not be installed automatically. A manual installation of NATS will be needed.

#### Existing masked alarms would incorrectly affect the overall alarm severity of an element [ID_35678]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Existing masked alarms would incorrectly affect the overall alarm severity of an element.

#### Failover: Offline agent would incorrectly try to take a backup of the Elasticsearch database [ID_35721]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When, in Failover setups, you configure a DataMiner backup on the online agent, the same backup will also be scheduled on the offline agent, and if these setups have a clustered Elasticsearch database, a backup of that database cluster will be included in the DataMiner backup.

In Failover setups where both agents included a local Elasticsearch database that was part of an Elasticsearch cluster, the online agent would fail to take a backup of the Elasticsearch databases due to a backup in progress, triggered earlier by the offline agent.

From now on, only the online agent will be allowed to take a backup of the Elasticsearch database, and the offline agent will log the following entry:

```txt
Elastic backup will not be taken - Only active agents from a failover pair can take the backup.
```

#### SLElement could leak memory when updating alarm templates containing conditions [ID_35728]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.4 -->

In some cases, SLElement could leak memory when updating alarm templates containing conditions.

#### SLProtocol would interpret signed numbers incorrectly [ID_35796]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

SLProtocol would interpret signed numbers incorrectly, causing parameters to display incorrect values.

#### Problem with SLNet when serializing a ModelHost error [ID_35802]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

An SLNet error could occur when serializing a ModelHost error.

> [!IMPORTANT]
> BREAKING CHANGE: To fix this issue, the `Exception` field had to be removed from the `ManagerStoreError` class.

#### SLAnalytics: Flatline events on child DVE elements would incorrectly be cleared automatically [ID_35818]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

Events generated after detecting change points of type "flatline" in trend data of child DVE elements would incorrectly be cleared automatically.

#### Business Intelligence: Enhancements with regard to the retrieval of data from logger tables and to general error handling [ID_35820]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

A number of enhancements have been made to the Business Intelligence module, especially with regard to the retrieval of data from logger tables and to general error handling.

#### SLAnalytics - Behavioral anomaly detection: Every parameter included in an alarm template would incorrectly be considered a monitored parameter [ID_35832]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

SLAnalytics would incorrectly consider every parameter included in an alarm template to be a monitored parameter, even it is was not being monitored.

#### DataMiner Maps: Markers could disappear when a layer was enabled or disabled [ID_35838]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

In some cases, markers could disappear when a layer was enabled or disabled.

#### SLAnalytics could keep on waiting indefinitely for large delete operations to finish [ID_35848]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

In some cases, SLAnalytics could keep on waiting indefinitely for large delete operations to finish.

#### Business Intelligence: At SLA startup, the active alarms would no longer be in sync with the actual alarms affecting the SLA [ID_35862]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

At SLA startup, in some cases, the active alarms would no longer be in sync with the actual alarms affecting the SLA.

Also, a number of other minor fixes with regard to SLA management have been implemented.

#### Problem when an SLA element was stopped or deleted while a parameter that triggered a QAction of the SLA in question was being updated [ID_35892]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

An error could occur when an SLA element was stopped or deleted while a parameter that triggered a QAction of the SLA in question was being updated.

#### DataMinerException thrown the first time an InfoData message was deserialized [ID_35897]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

The first time a message with an object of a type that inherited from `InfoData` was sent from SLNet to a client, the following DataMinerException was thrown when the message was deserialized:

```txt
Skyline.DataMiner.Net.Exceptions.DataMinerException: Failed to deserialize message (ProtoBuf). Possible version incompatibility between client and server.  ---&gt; System.InvalidOperationException: It was not possible to prepare a serializer for: Skyline.DataMiner.Net.InfoData ---&gt; System.InvalidOperationException: Unable to resolve a suitable Add method for System.Collections.Generic.IReadOnlyList`1[[System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]&#xD;
```

#### Problem with SLElement when a timed action was stopped [ID_35928]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

In some rare cases, an error could occur in SLElement when a timed action was stopped.

#### SNMP: OIDs with a leading dot would incorrectly no longer be allowed [ID_35954]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

OIDs with a leading dot would incorrectly no longer be allowed. From now on, OIDs with a leading dot are allowed again.

#### NT Notify type NT_GET_BITRATE_DELTA would not return a valid value for a table with a single row [ID_35967]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

In some rare cases, NT Notify type NT_GET_BITRATE_DELTA (269), which retrieves the time between two consecutive executions of the specified SNMP group (in ms), would not return a valid value for a table with a single row.

#### Dashboards app - Line & area chart: Legend would show an incorrect number of disabled parameters [ID_35970]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When configuring a line & area chart, you can use the *Chart limit* setting to specify the maximum number of parameters that can be displayed in the chart. The excess parameters will then be disabled but remain available in the chart legend, so that they can be enabled again manually.

In some cases, the number of disabled parameters shown in the legend would be incorrect.

#### 'SLA Affecting' property of cleared or re-opened alarm would incorrectly contain 'Y' instead of 'Yes' [ID_35987]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When an alarm was cleared and re-opened for the same parameter or parameter key combination, its *SLA Affecting* property would incorrectly contain "Y" instead of "Yes".
