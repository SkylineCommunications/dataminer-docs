---
uid: General_Feature_Release_10.6.2
---

# General Feature Release 10.6.2 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version:
>
> - Make sure **version 14.40.33816** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation. The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
>   - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
>   - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)
>
> - Make sure all DataMiner Agents in the cluster have been migrated to the BrokerGateway-managed NATS solution. For detailed information, see [Migrating to BrokerGateway](xref:BrokerGateway_Migration).
>
>   See also: [DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43856] [ID 43861] [ID 44035] [ID 44050] [ID 44062]](xref:General_Feature_Release_10.6.1#dataminer-systems-will-now-use-the-brokergateway-managed-nats-solution-by-default-id-43856-id-43861-id-44035-id-44050-id-44062)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.2](xref:Cube_Feature_Release_10.6.2).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.2](xref:Web_apps_Feature_Release_10.6.2).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### DataMiner upgrade: New upgrade action will register DataMiner exe files with Windows Error Reporting [ID 39440]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

During a DataMiner upgrade, from now on, a new upgrade action will register all DataMiner SL\*.exe and "DataMiner \*.exe" files with Windows Error Reporting (WER). This will make sure that, each time a DataMiner process crashes for whatever reason, a full crash dump is created in `C:\Skyline DataMiner\Logging\CrashDump\wer\<ExeName>`. These WER crash dumps will allow Skyline to thoroughly investigate any issue that might occur.

> [!NOTE]
>
> - Each time a crash dump is created for a particular process, any existing crash dumps for the same process will be automatically deleted. Per DataMiner process, only the most recent crash dump will be kept.
> - Although the entire `C:\Skyline DataMiner\Logging\CrashDump\wer\` folder will be cleared during a DataMiner upgrade, DataMiner will not manage it. Removing crash dumps from this folder will not require a DataMiner restart.
> - Currently, WER crash dumps are not included in SLLogCollector packages, and CDMR is not aware of them.

#### Security enhancements [ID 43789]

<!-- 43789: MR 10.5.0 [CU11] - FR 10.6.2 -->

A number of security enhancements have been made.

#### OpenSearch: Enhanced health monitoring [ID 43951]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

A number of enhancements have been made with regard to health monitoring of OpenSearch databases.

Also, all logging with regard to OpenSearch health monitoring can now be found in *SLSearchHealth.txt*. Up to now, that logging was added to *SLCassandraHealth.txt*.

Note that, from now on, if not all nodes of the OpenSearch cluster are listed in the *Db.xml* file, a notice will be generated to warn operators.

#### Augmented Operations: Server-side support for new flatline detection modes [ID 44094]

<!-- MR 10.7.0 - FR 10.6.2 -->

When, in DataMiner client applications (e.g. DataMiner Cube), you are configuring the Augmented Operations alarm settings for a particular parameter in an alarm template, from now on, it will be possible to choose between the following flatline detection modes:

| Mode | Description |
|------|-------------|
| Smart flatline alarming    | In this mode, SLAnalytics will automatically determine when a flatline period is anomalous by comparing it to the parameter's historical behavior. A new flatline period will only trigger an alarm if it is significantly longer than previously observed flat periods. |
| Absolute flatline alarming | In this mode, you can define a fixed duration threshold (in seconds) for when a flatline event should trigger an alarm. Additionally, you can assign a severity level to the generated flatline alarm event. |

See also: [Alarm templates: New flatline detection modes in Augmented Operations alarm settings [ID 44191]](xref:Cube_Feature_Release_10.6.2#alarm-templates-new-flatline-detection-modes-in-augmented-operations-alarm-settings-id-44191)

#### dataminer.services: Restrictions when adding a DMA to a DMS [ID 44171]

<!-- MR 10.7.0 - FR 10.6.2 -->

From now on, when you try to add a DataMiner Agent to a DataMiner System, the operation will fail in the following cases:

- The DataMiner Agent is cloud-connected, but the DataMiner System is not.
- The DataMiner Agent and the DataMiner System are cloud-connected, but they do not have the same identity, i.e. they are not part of the same cloud-connected system.

If the DataMiner System is a STaaS system, adding a DataMiner Agent will also fail if the DataMiner Agent is not cloud-connected.  

#### Scheduler will now be able to start more than 10 synchronously running Automation scripts [ID 44200]

<!-- MR 10.7.0 - FR 10.6.2 -->

Up to now, using Scheduler, it would only be possible to start a maximum of 10 synchronously running Automation scripts.

From now on, it will be possible to start more than 10 synchronously running Automation scripts.

#### Enhanced performance when upgrading DxMs [ID 44210] [ID 44211]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

Because of a number of enhancements, overall performance has increased when the following DxMs are upgraded during a DataMiner upgrade:

- BrokerGateway
- StorageModule

#### Relational anomaly detection: GetRADParameterGroupInfoResponseMessage now also includes the ID of the RAD parameter group [ID 44237]

<!-- MR 10.7.0 - FR 10.6.2 -->

The response to a `GetRADParameterGroupInfoMessage` will now also include the ID of the RAD parameter group.

#### SLAnalytics: New database synchronization tasks will be paused when the queue is too long [ID 44243]

<!-- MR 10.6.0 - FR 10.6.2 -->

When database operations fail or take too long, the queue of database synchronization tasks (which update model information) can grow excessively, causing the SLAnalytics process to consume increasing amounts of memory.

From now on, SLAnalytics will pause the creation of new synchronization tasks for some types of model information whenever there are too many pending tasks already. New synchronization operations will only be created again once the backlog has decreased.

### Fixes

#### Not possible to export elements with logger tables on systems with Cassandra Cluster and OpenSearch [ID 44105]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

On a system with Cassandra Cluster and OpenSearch, up to now, it would incorrectly not be possible to export elements with logger tables.

A `Cassandra.InvalidQuery` exception with message "No keyspace has been specified" would be thrown and logged.

> [!NOTE]
> On a system with Cassandra Cluster and OpenSearch, it is currently not yet possible to export SLAs.

#### Problem when generating a default MessageBrokerConfig.json file [ID 44155]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When neither an *SLCloud.xml* file nor a *MessageBrokerConfig.json* file could not be found on a DataMiner Agent, up to now, any process using MessageBroker would fail to generate a default *MessageBrokerConfig.json* file. As a result, it would not be possible to connect to NATS.

From now on, when neither a *SLCloud.xml* file nor a *MessageBrokerConfig.json* file can be found, a default *MessageBrokerConfig.json* file will be generated.

#### Elements hosted on another DMA and under the root view would not be visible if you did not have full access to the root view [ID 44170]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

In client applications like DataMiner Cube, up to now, elements hosted on a DMA other than the one you were connected to would incorrectly not be visible in the Surveyor if they were directly under the root view and if you did not have full access to that root view.

#### Uploading certain protocol versions would cause elements to no longer be able to execute QActions [ID 44172]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

After you had uploaded a protocol with a version that was identical to the prefix of the version of a protocol that was already in use (e.g. a new protocol with version 1.0.0.1 versus an existing protocol with version 1.0.0.1_DEV), up to now, elements using the existing protocol (e.g. with version 1.0.0.1_DEV) would incorrectly no longer be able to execute QActions.

#### Problem with SLElement when loading elements that included matrix parameters [ID 44188]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

In some cases, SLElement could stop working when loading elements that included matrix parameters.

#### BrokerGateway: Issues related to certificates [ID 44195]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

Up to now, in some cases, issues related to certificates could cause `TLS handshake error: remote error: tls: bad certificate` errors to be added to the NATS log file and `Could not connect to the local NATS endpoint on '<IP>'. Please make sure that the nats service is running without issues.` notice alarms to be generated.

From now on, in order to prevent any issues related to certificates, in the following cases, the certificate authority will be either added or updated in the certificate store:

- When adding an agent to the cluster.
- When removing an agent from the cluster.
- When calling NATSRepair.
- When migrating to BrokerGateway.
- When no certificate authorities can be found during BrokerGateway startup.

#### STaaS: Problem when migrating or importing elements with logger tables [ID 44196]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

On systems using STaaS, when an element with logger tables had been migrated from one DMA to another, up to now, that element would no longer start up after it was migrated back to its original DMA.

Also, on system using STaaS, up to now, when importing a DELT package containing elements with logger tables, the logger table data would not be imported correctly.

#### RAD parameter groups would no longer get monitored when a parameter had not had a value for more than 5 days [ID 44204]

<!-- MR 10.6.0 - FR 10.6.2 -->
<!-- Not added to MR 10.6.0 -->

When a parameter within a RAD parameter group had not had a value for more than 5 days, up to now, SLAnalytics would incorrectly lose track of the entire parameter group. As a result, no anomalies would get detected for that group, and create, update and delete actions performed on that group would fail.

#### Problem when retrieving historic alarms with a filter on the value of a discrete parameter [ID 44221]

<!-- MR 10.7.0 - FR 10.6.2 -->

When historic alarms were retrieved with a filter on the value of a discrete parameter, up to now, no alarms would be returned.

This was due to the parameter value being incorrectly translated to a numeric value.

#### No retries would incorrectly be attempted when retrieving DMS configuration info failed [ID 44240]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When a client application connects to a DataMiner System, it retrieves the configuration info of that DataMiner System.

Up to now, when retrieving that info failed, no retries would incorrectly be attempted. From now on, a retry will be attempted every 10 seconds.
