---
uid: General_Main_Release_10.4.0_CU4
---

# General Main Release 10.4.0 CU4

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU4](xref:Cube_Main_Release_10.4.0_CU4).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU4](xref:Web_apps_Main_Release_10.4.0_CU4).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID 38263] [ID 39611]

<!-- 38263: MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.3 -->
<!-- 39611: MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

A number of security enhancements have been made.

#### Cassandra & Cassandra cluster: Enhanced performance when querying the maskstate table [ID 39192]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

Because of a number of enhancements, on systems using a Cassandra and Cassandra cluster database, overall performance has increased when querying the maskstate database table. As a result, elements will start up quicker depending on the number of masked objects in the database.

#### Enhanced performance when loading services during a DataMiner startup [ID 39286]

<!-- MR 10.4.0 [CU4] - FR 10.4.7 -->

Because of a number of enhancements, overall performance has increased when loading services during a DataMiner startup.

#### SLDataMiner: Enhanced log entry indicating progress of multithreaded operations that take longer that 30 seconds to complete [ID 39367]

<!-- MR 10.4.0 [CU4] - FR 10.4.7 -->

When a multithreaded operation takes longer that 30 seconds to complete, an entry is added to the *SLDataMiner.txt* log file to indicate that the operation in question is still in progress. This log entry has now been enhanced. It will now show the progress in more detail.

`Waiting for completion of %s : %lli/%lli completed`

#### Service & Resource Management: Enhanced performance when creating multiple bookings simultaneously [ID 39390]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

Because of a number of enhancements, overall performance has increased when creating multiple bookings simultaneously.

#### Replication buffering enhancements [ID 39428]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

A number of enhancements have been made with regard to the replication buffering functionality:

- In some cases, the replication buffering limits would not be taken into account, causing the buffer to keep on growing.

- When DataMiner restarted with an active ReplicationBuffer storage file, at the end of its startup routine, it would incorrectly not flush the contents of the file once the replication connection was re-established.

- When, after a DataMiner restart, the replication connection was not re-established, a new buffer would be created (with a new hash in the file name), and the old buffer would be left on the disk, never to be used again. From now on, ReplicationBuffer files will no longer have a unique hash in their file name. As a result, there will only be one ReplicationBuffer file per replicated element.

##### Manually removing old ReplicationBuffer files

On some systems, the `C:\Skyline DataMiner\System Cache\SLNet` folder can contain a large number of old ReplicationBuffer files. These files will not be removed automatically. If you want to remove them manually, you have two options:

1. If you no longer need the data stored in those files, you can delete all files with a name matching the following format:

   `ReplicationBuffer_[AgentNameReplicatedElement]_[AgentIpReplicatedElement]_[AgentDmaIdReplicatedElement]_[ElementIdReplicatedElement]_[SomeHashOfTheStorage]`

   Example: *ReplicationBuffer_slc-h32-g06_10.11.6.32_223_4_6992437*

1. If you want to flush the data in the ReplicationBuffer files to the agents that are hosting the replicated elements (i.e. in order to fill some gaps in their trend data), you can try to do the following:

   1. Connect to the DMA using the SLNetClientTest tool.
   1. Go to the *Build Message* tab of the main window.
   1. In the *Message Type* dropdown list, select *DiagnoseMessage*.
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

#### Failover: Enhanced agent performance when going online [ID 39435]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

Because of a number of enhancements, it will now take less time for a Failover agent to go online, especially when a large number of clients are trying to connect to it.

#### SLAnalytics: Enhanced alarm template monitoring [ID 39561]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

When an alarm template contained multiple lines for the same parameter, each with a different filter, up to now, SLAnalytics would only take into account the lines that were being monitored. From now on, as soon as one line related to a specific parameter is being monitored, SLAnalytics will take into account all lines related to that parameter.

#### ReIndexElasticSearchIndexes tool: Enhancements [ID 39614]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 [CU0] -->

A number of enhancements have been made to the *ReIndexElasticSearchIndexes* tool, which must be used when [migrating from Elasticsearch to OpenSearch](xref:Migrating_from_Elasticsearch_to_OpenSearch).

- Up to now, when iterating over all indexes, the process would stop when it reached an index that could not be re-indexed. From now on, all indexes will always be processed, and a list of failed indexes will be written to disk.

- Up to now, logging would only be available during program execution. No logging would be written to file. From now on, a log file will be kept, allowing investigation of any failures that occurred during a re-indexing process.

- Up to now, when a re-indexing process failed, a generic error would be visible in the logging. From now on, the underlying failures detailing the root cause will also be logged.

- Up to now, when a re-indexing process failed, the temporary index that was created would not be deleted. From now on, an attempt will be made to properly delete it.

- Up to now, when the aliases were checked, a correction would be attempted before continuing. However, when a correction was necessary, the process would not continue. From now on, a retry will be made after a correction attempt.

- A command-line option has been added to allow you to retry the failed indexes (which will now be stored in the failed indexes list on disk). This can prove useful if, after investigation, the cause of the failure to re-index has been resolved.

  `ReIndexElasticSearchIndexes.exe [-R <path to failed indexes file>]`

#### SNMP++: Trap processing enhancements [ID 39629]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

Up to now, when SNMP++ was used for trap reception, a single thread would be responsible for reading the raw data from the UDP socket and forwarding it to SLSNMPManager.

From now on, one thread will read the raw data from the UDP buffer and add it to a queue. Another thread will then take the data from that queue, parse it into an appropriate SNMP object, and forward it to SLSNMPManager.

> [!NOTE]
>
> - If traps would get lost, the UDP buffer can be increased by changing the *DefaultReceiveWindow* and *DefaultSendWindow* REG_DWORD values under the Windows Registry key `HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\AFD\Parameters` (default value: 65536 bytes) and rebooting the server. Note that increasing these values will only have an effect when dealing with a small burst of traps. If traps are constantly entering at a higher rate than SLSNMPManager can process, it means that the DataMiner Agent is not able to catch up.
> - The throughput at which traps can be processed depends on various factors: the CPU benchmark and CPU usage, the log level of the SLSNMPManager logging, if traps need to be forwarded within the DMS, how long the QAction runs that processes the trap, and when an element is able to process a trap.

> [!CAUTION]
> Please take extreme care when modifying the Windows registry. We strongly advise you to back up the registry before you modify it.

#### Service & Resource Management: DVE activation enhancements [ID 39672]

<!-- MR 10.4.0 [CU4] - FR 10.4.7 -->

When a booking needs to start, SLNet will first try to activate the necessary function DVEs for that booking. If the booking is created a while before it needs to start, the DVEs will be activated at a set time before the start time (i.e. 10 minutes by default, but configurable using the [FunctionHysteresis](xref:Function_resource_settings) setting). For example, when you create a booking at 13:00 that needs to start at 15:00, the DVEs will be activated at 14:50.

When you create a booking that needs to start immediately, SLNet will enable the DVEs and wait for up to 1 minute until they are active before trying to start the booking. If the DVEs take more than 1 minute to activate, the booking will fail to start since the DVEs need to be activated before the booking can be started.

##### DVE activation delay is now configurable

From now on, the one-minute DVE activation delay is configurable by running a script similar to the one below. Changing this delay does not need DataMiner to be restarted.

```csharp
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Messages;
namespace Script
{
    public class Script
    {
        public void Run(Engine engine)
        {
            var protocolFunctionHelper = new ProtocolFunctionHelper(engine.SendSLNetMessages);
            var currentConfig = protocolFunctionHelper.GetProtocolFunctionConfig();
            currentConfig.ActiveFunctionResourcesThreshold = 123;
            currentConfig.FunctionActivationTimeout = TimeSpan.FromMinutes(10);
            protocolFunctionHelper.SetProtocolFunctionConfig(currentConfig);
        }
    }
}
```

> [!NOTE]
> If the activation fails after half the timeout, a retry will be made. In case of the one-minute default, a retry will be made after 30 seconds. If the timeout is increased to 10 minutes, the retry will be made after 5 minutes.

##### Waiting for DVE activation confirmation will now be processed asynchronously

Waiting for DVEs to get activated will now be processed asynchronously. This will avoid that bookings with function DVEs that take longer to get activated will prevent other bookings with function DVEs that get activated faster from starting.

### Fixes

#### Issues with user accounts [ID 39234]

<!-- MR 10.4.0 [CU4] - FR 10.4.7 -->

In some cases, user accounts could become corrupted and group memberships could get lost.

Also, in some cases, SLDataMiner could stop working when an alarm template or trend template was uploaded, removed, assigned or unassigned.

#### SLNet: Problem when sending messages due to an issue with the protobuf serializers [ID 39275]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

When SLNet sent a message, in some cases, an error could occur due to an issue with the protobuf serializers.

#### Problem with SLNet when information on hanging calls was being retrieved [ID 39373]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

In some rare cases, an error could occur in SLNet when information on hanging calls was being retrieved.

#### SLSNMPAgent would incorrectly interpret variable trap bindings of type 'IpAddress' as bindings of type 'OctetString' [ID 39425]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

Up to now, SLSNMPAgent would incorrectly interpret variable trap bindings of type 'IpAddress' as bindings of type 'OctetString'.

#### Protocols: 'next' attribute would no longer work for SNMP parameters [ID 39430]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

The `next` attribute of a parameter inside a parameter group determines the number of milliseconds DataMiner has to wait before reading the next parameter. This functionality no longer worked for SNMP parameters.

Also, when a group contained single parameters in combination with a partial table, the single parameters would incorrectly also be requested each time the next batch of rows were requested from the partial table. From now on, the single parameters will only be requested once.

> [!NOTE]
> When a `next` attribute is defined on a partial SNMP table parameter inside a parameter group, then the delay will also be applied between the batches of rows that are requested.

#### Interactive Automation script was not able to continue once a lost connection was re-established [ID 39487]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

When a client application lost connection while an interactive Automation script was being run, up to now, the script would stop as it was not able to continue once the connection was re-established.

From now on, when a client application loses connection while an interactive Automation script is being run, the script will continue once the connection is re-established.

#### Service & Resource Management: Service Manager would initialize twice on Failover systems [ID 39598]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

On Failover systems, the Service Manager would incorrectly initialize twice.

#### 'Security Advisory' BPA test: Issues fixed [ID 39606] [ID 39716]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

The following issues have been fixed in the [Security Advisory](xref:BPA_Security_Advisory) BPA test:

- When the BPA was run on a cloud-connected DataMiner System with more than one agent, the logic that determines whether port 5100 should be opened in the firewall would always fail. When the port was open, the BPA advised to close it, and when the port was closed, the BPA advised to open it.

- When the BPA was run on a DMA using HTTPS, it would throw an exception when IIS had an HTTPS binding without a certificate configured.

  In cases like this, from now on, instead of throwing an exception, the BPA will now report that the certificate is missing.

#### Problem when setting up SLNet connections to the IPv6 loopback address or an FQDN pointing to a loopback address [ID 39667]

<!-- MR 10.4.0 [CU4] - FR 10.4.7 -->

When an SLNet connection was made to the IPv6 loopback address, the system would incorrectly not use a connection to `ipc://slnet-ipc-callback`. Instead, it would use a TCP connection to the primary IPv6 address.

Also, when an SLNet connection was made to a FQDN which points to a loopback address, the system would incorrectly use a TCP connection to the primary IPv4 address.

#### Problem during SLDataMiner startup when loading in services with duplicate IDs [ID 39896]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 [CU0] -->

In some cases, a deadlock would occur during startup of the SLDataMiner process when services with duplicate IDs were loaded in.
