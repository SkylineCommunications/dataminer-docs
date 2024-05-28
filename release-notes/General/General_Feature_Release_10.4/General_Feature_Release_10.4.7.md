---
uid: General_Feature_Release_10.4.7
---

# General Feature Release 10.4.7 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.7](xref:Cube_Feature_Release_10.4.7).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.7](xref:Web_apps_Feature_Release_10.4.7).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### DataMiner Object Models: DomInstance names now support GenericEnum fields that allow multiple values [ID_39510]

<!-- MR 10.5.0 - FR 10.4.7 -->

DomInstance names now support GenericEnum fields that allow multiple values. In other words, `list GenericEnumFieldDescriptor` will now be supported as a `FieldValueConcatenationItem` for a DomInstance name.

When you add a GenericEnumFieldDescriptor that supports multiple values to a DomDefinition NameDefinition, it will add the display names of the enum values separated by a semicolon (';').

Also, from now on, it will no longer be possible to create multiple enum values with the same values using the SLNetTypes method `AddEntry(GenericEnumEntry<T> entry)`. When you try to do so, an `InvalidOperationException` will now be thrown.

#### Factory reset tool: Additional actions [ID_39524] [ID_39530]

<!-- MR 10.5.0 - FR 10.4.7 -->

The factory reset tool `SLReset.exe` will now perform the following additional actions:

- If the DataMiner Agent is connected to *dataminer.services*, disconnect the DataMiner Agent from *dataminer.services*.
- Clear all custom appsettings of the DataMiner extension modules (DxMs).

## Changes

### Enhancements

#### GQI: Enhanced sorting of indexed logger tables [ID_38857]

<!-- MR 10.5.0 - FR 10.4.7 -->

A number of enhancements have been made with regard to the sorting of indexed logger tables.

#### Cassandra & Cassandra cluster: Enhanced performance when querying the maskstate table [ID_39192]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

Because of a number of enhancements, on systems using a Cassandra and Cassandra cluster database, overall performance has increased when querying the maskstate database table. As a result, elements will start up quicker depending on the number of masked objects in the database.

#### Enhanced performance when loading services during a DataMiner startup [ID_39286]

<!-- MR 10.4.0 [CU4] - FR 10.4.7 -->

Because of a number of enhancements, overall performance has increased when loading services during a DataMiner startup.

#### SLDataMiner: Enhanced log entry indicating progress of multi-threaded operations that take longer that 30 seconds to complete [ID_39367]

<!-- MR 10.4.0 [CU4] - FR 10.4.7 -->

When a multi-threaded operation takes longer that 30 seconds to complete, an entry is added to the *SLDataMiner.txt* log file to indicate that the operation in question is still in progress. This log entry has now been enhanced. It will now show the progress in more detail.

`Waiting for completion of %s : %lli/%lli completed`

#### Service & Resource Management: Enhanced performance when creating multiple bookings simultaneously [ID_39390]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

Because of a number of enhancements, overall performance has increased when creating multiple bookings simultaneously.

#### Replication buffering enhancements [ID_39428]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

A number of enhancements have been made with regard to the replication buffering functionality:

- In some cases, the replication buffering limits would not be taken into account, causing the buffer to keep on growing.

- When DataMiner restarted with an active ReplicationBuffer storage file, at the end of its startup routine, it would incorrectly not flush the contents of the file once the replication connection was re-established.

- When, after a DataMiner restart, the replication connection was not re-established, a new buffer would be created (with a new hash in the file name), and the old buffer would be left on the disk, never to be used again. From now on, ReplicationBuffer files will no longer have a unique hash in their file name. Also, there will only be one ReplicationBuffer file per replicated element.

##### Manually removing old ReplicationBuffer files

On some systems, the `C:\Skyline DataMiner\System Cache\SLNet` folder can contain a large number of old ReplicationBuffer files. These files will not be removed automatically. If you want to remove them manually, you have two options:

1. If you no longer need the data stored in those files, you can delete all files with a name matching the following format:

   `ReplicationBuffer_[AgentNameReplicatedElement]_[AgentIpReplicatedElement]_[AgentDmaIdReplicatedElement]_[ElementIdReplicatedElement]_[SomeHashOfTheStorage]`

   Example: *ReplicationBuffer_slc-h32-g06_10.11.6.32_223_4_6992437*

1. If you want to flush the data in the ReplicationBuffer files to the agents that are hosting the replicated elements (i.e. in order to fill some gaps in their trend data), you can try to do the following:

   1. Connect to the DMA using the SLNetClientTest tool.
   1. Go to the *Build Message* tab of the main window.
   1. In the *Message Type* drop-down list, select *DiagnoseMessage*.
   1. In the *ExtraInfo* field, specify "flush:[fileNamePattern]". For examples of file name patterns, see below.
   1. In the *Type* field at the bottom, select "ReplicationBufferStats".

   Examples of flush commands:

   | Enter... | to try to flush... |
   |----------|--------------------|
   | flush:* | all ReplicationBuffer files. |
   | flush:agentName* | all ReplicationBuffer files for DataMiner Agent *agentName* |
   | flush:agentName_10.11.6.32_223_4 | all ReplicationBuffer files for the replicated element 223/4 on DataMiner Agent agentName |

> [!IMPORTANT]
> DataMiner will only succeed in flushing a ReplicationBuffer if the replication connection for the replicated element in question is active. If not, it will fail to do so, and will leave the file untouched.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Failover: Enhanced agent performance when going online [ID_39435]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

Because of a number of enhancements, it will now take less time for a Failover agent to go online, especially when a large number of clients are trying to connect to it.

#### Caching of protocol signature information will enhance overall performance during a DataMiner startup [ID_39468]

<!-- MR 10.5.0 - FR 10.4.7 -->

Information regarding protocol signature validation will now be cached. This will considerably enhance overall performance during a DataMiner startup.

#### SLAnalytics - Behavioral anomaly detection: Enhanced rounding of anomaly threshold values & optimized linking of severities to anomaly thresholds [ID_39492]

<!-- MR 10.5.0 - FR 10.4.7 -->

In alarm templates, the rounding of anomaly threshold values has been enhanced. For example, 3.09999999999999 will now be displayed as 3.1.

Also, the mechanism used to associate severities with anomaly thresholds has been optimized.

#### SLLogCollector packages will now include nslookup output for hostnames [ID_39526]

<!-- MR 10.5.0 - FR 10.4.7 -->

From now on, SLLogCollector packages will also include the *nslookup* output for the hostname configured in

- *MaintenanceSettings.xml* (HTTPS) and/or
- *DMS.xml* (Failover).

#### SLLogCollector packages now include GQI and Web API logging [ID_39557]

<!-- MR 10.5.0 - FR 10.4.7 -->

From now on, SLLogCollector packages will also include the contents of the following folders:

- *C:\\Skyline DataMiner\\Logging\\GQI*
- *C:\\Skyline DataMiner\\Logging\\GQI\\Ad hoc data sources*
- *C:\\Skyline DataMiner\\Logging\\GQI\\Custom operators*
- *C:\\Skyline DataMiner\\Logging\\Web*

#### SLAnalytics: Enhanced alarm template monitoring [ID_39561]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

When an alarm template contained multiple lines for the same parameter, each with a different filter, up to now, SLAnalytics would only take into account the lines that were being monitored. From now on, as soon as one line related to a specific parameter is being monitored, SLAnalytics will take into account all lines related to that parameter.

#### Security enhancements [ID_39611] [ID_39387]

<!-- 39611: MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->
<!-- 39387: MR 10.5.0 - FR 10.4.7 -->

A number of security enhancements have been made.

#### SNMP++: Trap processing enhancements [ID_39629]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

Up to now, when SNMP++ was used for trap reception, a single thread would be responsible for reading the raw data from the UDP socket and forwarding it to SLSNMPManager.

From now on, one thread will read the raw data from the UDP buffer and add it to a queue. Another thread will then take the data from that queue, parse it into an appropriate SNMP object, and forward it to SLSNMPManager.

> [!NOTE]
>
> - If traps would get lost, the UDP buffer can be increased by changing the *DefaultReceiveWindow* and *DefaultSendWindow* REG_DWORD values under the Windows Registry key `HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\AFD\Parameters` (default value: 65536 bytes) and rebooting the server. Note that increasing these values will only have an effect when dealing with a small burst of traps. If traps are constantly entering at a higher rate than SLSNMPManager can process, it means that the DataMiner Agent is not able to catch up.
> - The throughput at which traps can be processed depends on various factors: the CPU benchmark and CPU usage, the log level of the SLSNMPManager logging, if traps need to be forwarded within the DMS, how long the QAction runs that processes the trap, and when an element is able to process a trap.

> [!CAUTION]
> Please take extreme care when modifying the Windows registry. We strongly advise you to back up the registry before you modify it.

### Fixes

#### Issues with user accounts [ID_39234]

<!-- MR 10.4.0 [CU4] - FR 10.4.7 -->

In some cases, user accounts could become corrupted and group memberships could get lost.

Also, in some cases, SLDataMiner could stop working when an alarm template or trend template was uploaded, removed, assigned or unassigned.

#### SLNet: Problem when sending messages due to an issue with the protobuf serializers [ID_39275]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

When SLNet sent a message, in some cases, an error could occur due to an issue with the protobuf serializers.

#### Problem with SLNet when information on hanging calls was being retrieved [ID_39373]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

In some rare cases, an error could occur in SLNet when information on hanging calls was being retrieved.

#### MessageBroker: Problem when trying to read a file that was being updated by another process [ID_39408]

<!-- MR 10.5.0 - FR 10.4.7 -->

In some rare cases, an exception could be thrown when MessageBroker tried to read a file that was being updated by another process.

#### SLSNMPAgent would incorrectly interpret variable trap bindings of type 'IpAddress' as bindings of type 'OctetString' [ID_39425]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

Up to now, SLSNMPAgent would incorrectly interpret variable trap bindings of type 'IpAddress' as bindings of type 'OctetString'.

#### Protocols: 'next' attribute would no longer work for SNMP parameters [ID_39430]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

The `next` attribute of a parameter inside a parameter group determines the number of milliseconds DataMiner has to wait before reading the next parameter. This functionality no longer worked for SNMP parameters.

Also, when a group contained single parameters in combination with a partial table, the single parameters would incorrectly also be requested each time the next batch of rows were requested from the partial table. From now on, the single parameters will only be requested once.

> [!NOTE]
> When a `next` attribute is defined on a partial SNMP table parameter inside a parameter group, then the delay will also be applied between the batches of rows that are requested.

#### Problem when disposing an ISession with multiple subscriptions [ID_39483]

<!-- MR 10.5.0 - FR 10.4.7 -->

In some cases, an `InvalidOperationException` could be thrown when a .NET Framework host application (e.g. DataMiner Automation) disposed an ISession with multiple subscriptions without having disposed the subscriptions first.

#### Interactive Automation script was not able to continue once a lost connection was re-established [ID_39487]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

When a client application lost connection while an interactive Automation script was being run, up to now, the script would stop as it was not able to continue once the connection was re-established.

From now on, when a client application loses connection while an interactive Automation script is being run, the script will continue once the connection is re-established.

#### API Gateway: Problem when processing a large number of parallel calls [ID_39550]

<!-- MR 10.5.0 - FR 10.4.7 -->

When API Gateway had to process a large number of parallel calls, up to now, this could lead to a threading problem, causing clients to time out and get disconnected.

#### SLAnalytics: Elements imported after being deleted earlier would incorrectly be considered deleted [ID_39566]

<!-- MR 10.5.0 - FR 10.4.7 -->

When an imported element was deleted and then imported again, up to now, SLAnalytics would incorrectly considered that element as being deleted for at least a day. As a result, it would for example not detect any change points for that element during that time frame.

From now on, when an imported element is deleted and then imported again, SLAnalytics will no longer considered that element as being deleted.

#### Service & Resource Management: Service Manager would initialize twice on Failover systems [ID_39598]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

On Failover systems, the Service Manager would incorrectly initialize twice.

#### 'Security Advisory' BPA test: Issues fixed [ID_39606] [ID_39716]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

The following issues have been fixed in the [Security Advisory](xref:BPA_Security_Advisory) BPA test:

- When the BPA was run on a cloud-connected DataMiner System with more than one agent, the logic that determines whether port 5100 should be opened in the firewall would always fail. When the port was open, the BPA advised to close it, and when the port was closed, the BPA advised to open it.

- When the BPA was run on a DMA using HTTPS, it would throw an exception when IIS had an HTTPS binding without a certificate configured.

  In cases like this, from now on, instead of throwing an exception, the BPA will now report that the certificate is missing.
