---
uid: General_Main_Release_10.5.0_CU10
---

# General Main Release 10.5.0 CU10 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU10](xref:Cube_Main_Release_10.5.0_CU10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU10](xref:Web_apps_Main_Release_10.5.0_CU10).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Minor enhancements made to BPAs [ID 40751]

<!-- MR 10.5.0 [CU10] - FR 10.4.12 -->

A number of minor enhancements have been made to the following BPAs:

##### Check Antivirus DLLs

- Renamed to *Antivirus on the DataMiner Agents*.

##### Check Cluster SLNet Connections

- Renamed to *SLNet connections between the DataMiner Agents*.
- Message `No potential issues detected` renamed to `No issues detected`.

##### Minimum Requirements Check

- Renamed to *DataMiner Agent Minimum Requirements*.
- When Cassandra is not installed, this BPA will no longer report Cassandra is a requirement.
- Memory calculation has been enhanced.

##### Report active RTE

- Renamed to *Active Runtime errors*.

#### New BPA test: Health Metrics [ID 43509]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

A new BPA test named "Health Metrics" has been added.

This BPA test will run every hour, and will fetch details about connections used within DataMiner, either through a diagnose message or by using information offloaded to disk.

In later versions, it will then also analyze those details and attempt to warn operators when load increases on specific DataMiner modules and/or connections.

#### SLNetClientTest tool now allows you to check the contents of the hosting cache used by SLDataMiner [ID 43605]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Using the *SLNetClientTest* tool, you can now send a DiagnosticMessage with LIST_HOSTAGENTCACHE to SLDataMiner to retrieve the contents of the hosting cache used by SLDataMiner. This will allow you to check if an element is local or not.

To send such a message, open the *SLNetClientTest* tool, and go to *Diagnostics > DMA > Elements (Hosting Cache)*.

> [!CAUTION]
> Always be extremely careful when using the *SLNetClientTest* tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Clearer message when SLCloud.xml cannot be found when using the legacy SLNet-managed NATS solution [ID 43890]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, when the *SLCloud.xml* file could not be found on systems using the legacy SLNet-managed NATS solution, the following generic exception would be thrown and logged:

`Unable to find file.`

From now on, the following exception will be thrown and logged:

`Unable to find file. SLCloud configured messageBrokers are unsupported as of DataMiner 10.6.0.`

#### SLASPConnection will now detect more quicker that a connection to a DMA has been lost or re-established [ID 44049]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Because of a number of enhancements, SLASPConnection will now detect more quicker that a connection to a DataMiner Agent has been lost or re-established.

#### DataMiner upgrade: New prerequisite will check whether .NET 10 is installed [ID 44121]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Before upgrading to this DataMiner release or above, you are expected to install the Microsoft .NET 10 hosting bundle.

When you start a DataMiner upgrade procedure, from now on, a new prerequisite will verify whether Microsoft .NET 10 is installed on the system. If this is not the case, the upgrade will be canceled.

#### Enhanced stuffing and unstuffing behavior when sending serial commands [ID 44149]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

A number of enhancements have been made to the stuffing and unstuffing behavior when sending serial commands.

Stuffing will now always be removed from the parameters, even if the current command did not add stuffing during a previous run. This will make it easier and more robust to reuse parameters across different commands.

### Fixes

#### Service templates: Problem when parsing conditions to dynamically include or exclude child elements [ID 43120]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

In some cases, conditional triggers to dynamically include or exclude child elements would be parsed incorrectly, especially when the first condition was a NOT clause.

#### Cleared alarms would incorrectly not be shown when using the history slider in DataMiner Cube [ID 43810]

<!-- MR 10.5.0 [CU10] - FR 10.5.12 -->

On systems with a Cassandra cluster database in combination with an OpenSearch indexing database, cleared alarms would incorrectly not be shown when using the history slider in DataMiner Cube.

#### SLElement could stop working when DVE elements were deleted [ID 43947]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, when DVE elements were deleted while multiple DVE elements were having their state changed to deleted/stopped, in some cases, SLElement could stop working.

#### SLNet: Information messages triggered in a QAction would incorrectly only be forwarded to the DMA hosting the element in question [ID 43958]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When a QAction triggered an information message with regard to a particular element, SLNet would incorrectly only forward that message to the DataMiner Agent that hosted that element. As a result, that information message would not appear in client applications connected to any of the other DataMiner Agents in the system.

#### Element and parameter state timelines could show incorrect data [ID 43982]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, in some cases, element and parameter state timelines displayed in client applications like DataMiner web apps or DataMiner Cube could show incorrect data.

#### Failover: 'C:\\Skyline DataMiner\\Elements' folder on offline Agents could unexpectedly be cleared [ID 44005]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

In Failover clusters, in some rare cases where specific conditions related to DVE element handling and naming conflicts were met, the `C:\Skyline DataMiner\Elements` folder on offline Agents could unexpectedly be cleared, sometimes leaving no elements behind.

To detect whether this has occurred:

- Compare the number of elements on the online and offline Agents.
- Check the offline Agent's Recycle Bin for entries named "Element   deleted", indicating a deletion occurred without a known element name.

#### SLProtocol would silently fail to parse the Protocol.Advanced@stuffing attribute when its value contained spaces [ID 44010]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, SLProtocol would silently fail to parse the *stuffing* attribute of the *Protocol.Advanced* tag when its value contained spaces.

#### Failover: TLS handshakes of NATS connections would fail [ID 44060]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

On a newly created Failover system, in some cases, the TLS handshakes of the NATS connections would fail due to the virtual IP address not being updated in the TLS certificate.

#### Problem when importing Visio files associated with views or services via a .dmimport package [ID 44065]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, an issue would prevent Visio files associated with views or services from being imported via a *.dmimport* package.

This issue did not occur when importing Visio files associated with connectors via a *.dmprotocol* package.

#### Problem when importing a connector that contained information templates of which the name contained dots [ID 44079]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When you imported a connector that contained information templates of which the names contained dots ("."), a parsing error would cause an exception to be thrown.

#### Offload database: Not possible to offload information events without offloading alarms as well [ID 44080]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, it would incorrectly not be possible to offload information events when you had not opted to offload alarms as well. It would only be possible to offload information events together with alarms.

From now on, it will be possible to offload either alarms only, information events only, or both.

#### Failover: Security Advisory BPA test would show an incorrect result after checking the status of port 5100 of the firewall [ID 44093]

<!-- MR 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

When run on the offline agent of a Failover system, the Security Advisory BPA test would show an incorrect result after checking the status of port 5100 of the firewall.

#### Problem when retrieving history alarms with wildcard or regex filters that were applied case-sensitively [ID 44095]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When, in client applications like DataMiner Cube, history alarm were retrieved with a wildcard or regex filter that filtered on values that contained uppercase characters, up to now, an incorrect result set would be returned.

From now on, wildcard and regex filters will be applied case-insensitively.

#### Memory leak in SLDataMiner when documents were being handled [ID 44098]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

In some cases, SLDataMiner could leak memory when documents were being handled.

#### Problem when synchronizing create/update/delete actions performed on services [ID 44132]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

In some rare cases, certain create/update/delete actions performed on services would not get synchronized among the DataMiner Agents in a cluster, especially when they had been performed in rapid succession.

#### Problem when performing a row-based FillArray method with zero rows as input and with the SaveOption option set to 'Partial' [ID 44137]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When a row-based `FillArray` method was performed with zero rows as input and with the `SaveOption` option set to "Partial", up to now, the method would throw an unhandled exception due to a missing check.

#### NotifyDataMiner call NT_CLOSE_HISTORY_TREND_WINDOW (374) sent for a table cell would incorrectly ignore the specified timestamp [ID 44162]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, when a NotifyDataMiner call `NT_CLOSE_HISTORY_TREND_WINDOW` (374) was sent for a particular table cell, it would incorrectly ignore the specified timestamp.

This call closes all previous trend windows that are still open and have already passed since the specified time.
