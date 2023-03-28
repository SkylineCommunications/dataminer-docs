---
uid: General_Main_Release_10.3.0_CU2
---

# General Main Release 10.3.0 CU2 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

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

#### GQI data sources that require an Elasticsearch database will now use GetInfoMessage(InfoType.Database) to check whether Elasticsearch is available [ID_35907]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Up to now, GQI data sources that require an Elasticsearch database used the `DatabaseStateRequest<ElasticsearchState>` message to check whether Elasticsearch was available. From now on, they will use the `GetInfoMessage(InfoType.Database)` message instead.

#### Improved error handling when elements go into an error state [ID_35944]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When an element goes into an error state after an attempt to activate it failed, from now on, no more calls to SLProtocol, SLElement or SLSpectrum will be made for that element.

Also, when an element that generates DVE child elements or virtual functions goes into an error state, from now on, the generated DVE child elements or virtual functions will also go into an error state. However, in order to avoid too many alarms to be generated, only one alarm (for the main element) will be generated.

The following issues have also been fixed:

- When a DVE parent element in an error state on DataMiner startup was activated, its DVE child elements or virtual functions would not be properly loaded.

- When a DVE parent element was started, the method that has to make sure that ElementInfo and ElementData are in sync would incorrectly not check all child elements.

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

#### DataMinerException thrown the first time an InfoData message was deserialized [ID_35897]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

The first time a message with an object of a type that inherited from `InfoData` was sent from SLNet to a client, the following DataMinerException was thrown when the message was deserialized:

```txt
Skyline.DataMiner.Net.Exceptions.DataMinerException: Failed to deserialize message (ProtoBuf). Possible version incompatibility between client and server.  ---&gt; System.InvalidOperationException: It was not possible to prepare a serializer for: Skyline.DataMiner.Net.InfoData ---&gt; System.InvalidOperationException: Unable to resolve a suitable Add method for System.Collections.Generic.IReadOnlyList`1[[System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]&#xD;
```
