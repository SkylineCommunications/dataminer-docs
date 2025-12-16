---
uid: General_Main_Release_10.5.0_CU11
---

# General Main Release 10.5.0 CU11 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU11](xref:Cube_Main_Release_10.5.0_CU11).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU11](xref:Web_apps_Main_Release_10.5.0_CU11).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

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

#### Elasticsearch/OpenSearch: Enhanced history alarm filtering on service ID or service name [ID 44192]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When, on a system with a Cassandra Cluster database, history alarms are filtered on service ID or service name, up to now, that filter would not be translated correctly to Elasticsearch or OpenSearch. From now on, that filter will be translated correctly. As a result, overall performance will increase when applying the filter in question to large data sets.

Also, filtering on alarm properties or interfaces using wildcards or regular expression has now been made case insensitive.

#### Enhanced performance when upgrading DxMs [ID 44210] [ID 44211]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

Because of a number of enhancements, overall performance has increased when the following DxMs are upgraded during a DataMiner upgrade:

- BrokerGateway
- StorageModule

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

#### Problem when retrieving historic alarms with a filter on the value of a discrete parameter [ID 44221]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When historic alarms were retrieved with a filter on the value of a discrete parameter, up to now, no alarms would be returned.

This was due to the parameter value being incorrectly translated to a numeric value.

#### No retries would incorrectly be attempted when retrieving DMS configuration info failed [ID 44240]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When a client application connects to a DataMiner System, it retrieves the configuration info of that DataMiner System.

Up to now, when retrieving that info failed, no retries would incorrectly be attempted. From now on, a retry will be attempted every 10 seconds.

#### Problem when trying to create, update, or delete users or user groups [ID 44245]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

Because of file locking issues, in some cases, errors could occur when trying to create, update, or delete users or user groups.

#### Crowd: HTTP response codes would incorrectly be ignored [ID 44254]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When DataMiner was configured to import users and groups from a Crowd server, SLDataMiner would incorrectly disregard HTTP result codes while parsing a response during the hourly LDAP synchronization. This could lead to users being removed from their groups until the next successful synchronization, causing them to be unable to log in to DataMiner.
