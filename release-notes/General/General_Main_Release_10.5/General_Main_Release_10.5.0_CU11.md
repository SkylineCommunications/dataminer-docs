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

#### Security enhancements [ID 43789]

<!-- 43789: MR 10.5.0 [CU11] - FR 10.6.2 -->

A number of security enhancements have been made.

#### OpenSearch: Enhanced health monitoring [ID 43951]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

A number of enhancements have been made with regard to health monitoring of OpenSearch databases.

Also, all logging with regard to OpenSearch health monitoring can now be found in *SLSearchHealth.txt*. Up to now, that logging was added to *SLCassandraHealth.txt*.

Note that, from now on, if not all nodes of the OpenSearch cluster are listed in the *Db.xml* file, a notice will be generated to warn operators.

#### Enhanced performance when upgrading DxMs [ID 44210] [ID 44211]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

Because of a number of enhancements, overall performance has increased when upgrading the following DxMs in e.g. `https://admin.dataminer.services/`:

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
