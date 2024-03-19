---
uid: General_Main_Release_10.4.0_CU2
---

# General Main Release 10.4.0 CU2 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Breaking changes

#### DOM string fields will now be filtered case-insensitively [ID_38950]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, DOM string fields would be filtered case-sensitively. From now on, those fields will by default be filtered case-insensitively.

> [!NOTE]
> If necessary, this default filter behavior can be overruled in code by using `StringComparison.Ordinal`. See the following snippet.
>
> ```csharp
> var filter = DomInstanceExposers.FieldValues.DomInstanceField(_stringFieldDescriptor.ID).Contains("test", StringComparison.Ordinal)
> ```

### Enhancements

#### Elasticsearch re-indexing tool [ID_37994]

<!-- MR 10.4.0 [CU2] - FR 10.4.4 -->

Migrating data from from Elasticsearch 6.8.22 to OpenSearch 2.11.1 involves the following steps:

1. Taking a snapshot of the Elasticsearch 6.8.22 cluster.
1. Copying the snapshot to an Elasticsearch 7.10.0 cluster, and restoring it.
1. Re-indexing the data and taking another snapshot.
1. Copying the snapshot with the re-indexed data to an OpenSearch 2.11.1 cluster, and restoring it

To perform step 3, a command-line re-indexing tool has been developed: *ReIndexElasticSearchIndexes.exe*.

This tool accepts the following arguments:

| Argument | Description |
|----------|-------------|
| -Node or -N | The name of the node to be used for re-indexing (mandatory).<br>Format: `http(s)://127.0.0.1:9200` or `http(s)://fqdn:9200` |
| -User or -U | The user name, to be provided in case Elasticsearch was hardened.<br>See [Securing the Elasticsearch database](xref:Security_Elasticsearch) |
| -Password or -P | The user password |
| -DBPrefix or -D | The database prefix, to be provided in case a custom database prefix is used instead of the default `dms-` prefix.<br>If you do not provide a prefix, the default `dms-` will be used. |
| -TLSEnabled or -T | Whether or not TLS is enabled for this ElasticSearch database.<br>Values: true or false. Default: false |

If you do not specify a user name and user password, the tool will assume a default ElasticSearch database installation.

#### Service & Resource Management: Enhanced performance of volume license check [ID_38705]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when performing volume license checks.

#### APIGateway now runs on .NET 8 and allows you to enable kernel response buffering [ID_38710]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

APIGateway has been upgraded. It now runs on Microsoft .NET 8.

This service now allows you to enable kernel response buffering, which should improve throughput and responsiveness over high-latency connections. This setting is disabled by default. To enable it, do the following:

1. In the `C:\Program Files\Skyline Communications\DataMiner APIGateway\` folder of the DataMiner Agent, create a JSON file named *appsettings.custom.json*.
1. Open this JSON file, and add the following content:

   ```json
   { "HostingOptions": { "EnableKernelResponseBuffering": true } }
   ```

#### Automation: Cassandra Ready check will now only be performed on DataMiner Systems using a MySQL database [ID_38760]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, Automation scripts would always be checked whether they were Cassandra ready, regardless of the type of database used by the DataMiner System.

From now on, this Cassandra ready check will only be performed on DataMiner Systems using a MySQL database. When the DataMiner System is using a type of database other than MySQL, Automation scripts will always be considered Cassandra ready.

#### Enhanced performance when starting up a DataMiner Agent with a large number of virtual elements [ID_38780]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when starting up a DataMiner Agent with a large number of virtual elements.

#### New SLTimeToLive.txt log file containing all changes made to the TTL settings [ID_38851]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

In the `C:\Skyline DataMiner\Logging\SLTimeToLive` folder, you can now find a new *SLTimeToLive.txt* log file, listing all changes made to the TTL settings in Cube's *System Center > System settings > Time to live* page.

> [!NOTE]
> The contents of this folder will not be deleted during either a DataMiner restart or a DataMiner upgrade. However, in the *SLTimeToLive.txt* file, the oldest entries will be removed when the maximum log file size is exceeded.

#### Security enhancements [ID_38904]

<!-- RN 38904: MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

A number of security enhancements have been made.

#### Protocols: Enhanced performance when filling an array using the QActionTableRow objects in a QAction [ID_39017]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when filling an array using the `QActionTableRow` objects in a QAction.

#### SLAnalytics - Behavioral anomaly detection: Enhancements [ID_39024]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

A number of enhancements have been made with regard to the behavioral anomaly detection feature.

#### STaaS: SLDataGateway will now periodically check the health of the storage service [ID_39068]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

When Storage as a Service (STaaS) is used, SLDataGateway will now periodically check the health of that storage service. If the current status cannot be determined or if the current status is "red", SLDataGateway will switch to file offload mode.

> [!NOTE]
>
> - When the current status is "yellow", SLDataGateway will not switch to file offload mode.
> - Whenever the health of the storage service changes, an alarm mentioning the current health status is generated.

### Fixes

#### Databases: Problem when starting a migration from MySQL to Cassandra [ID_37589]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.1 -->

When you started a migrating from a MySQL database to a Cassandra database, an error could occur when the connection to the MySQL database took a long time to get established.

#### Automatic incident tracking: Incomplete or empty alarm groups after DataMiner startup [ID_38441]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

After a DataMiner startup, in some cases, certain alarm groups would either be incomplete or empty due to missing remote base alarms.

#### STaaS: Problem when going into file offload mode [ID_38648]

<!-- MR 10.4.0 [CU2] - FR 10.4.4 -->

When the system went into file offload mode, in some cases, a serialization issue could occur, causing the file offload mode to get stuck.

#### Problem when migrating SLAnalytics data, DOM data or SRM data to STaaS [ID_38884]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

When being migrated to STaaS, SLAnalytics data, DOM data or SRM data would incorrectly not be replicated. This could cause data created during the migration to be missing after the migration.

#### Not possible to delete a service created via an SRM booking when it had been assigned a name that was already being used [ID_38914]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When a service created via an SRM booking got into an error state because it had been assigned a name that was already being used by another object, it would not be possible to delete it as it would be considered invalid.

#### Service & Resource Management: Problem when the function manager was not able to read the functions.xml file in C:\\Skyline DataMiner\\ServiceManager [ID_38925]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, in some cases, a run-time error could occur when the function manager was not able to read the *functions.xml* file in `C:\Skyline DataMiner\ServiceManager`.

From now on, if an error occurs when the function manager was not able to read that file, an entry will be added to the *SLFunctionManager.txt* log file, and if the error occurred because the file was locked by another process, the log entry will include the name of the process.

#### STaaS: Database queries could time out [ID_39081]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

When a database query was performed against a STaaS database, in some cases, the query could time out, leading to no results being returned.
