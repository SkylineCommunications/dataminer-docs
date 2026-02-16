---
uid: Migrating_the_general_database_to_a_DMS_Cassandra_cluster
keywords: local database
---

# Migrating the general database to a DMS Cassandra cluster

If you choose not to use the recommended [Storage as a Service (STaaS)](xref:STaaS) setup but instead have a self-managed storage setup with **SQL databases or Cassandra databases per DMA** and want to switch to a Cassandra cluster setup, you can use the **Cassandra Cluster Migrator** for this. In DataMiner versions prior to 10.2.0/10.2.2, a Cassandra to Cassandra Cluster Migrator tool was available; however, we highly recommend that you upgrade to DataMiner 10.3.0 [CU11]/10.4.2 or higher and use the Cassandra Cluster Migrator instead.

The migration can be done while the DMAs are active; however, a **DataMiner restart** will be required after all data has been migrated.

The Cassandra Cluster Migrator tool (called *SLCCMigrator.exe*) is available on every DMA running DataMiner version 10.2.0/10.2.2 or higher. You can find it in the folder `C:\Skyline DataMiner\Tools\`. However, we highly recommend that you upgrade to DataMiner 10.3.0 [CU11]/10.4.2 or higher to use the tool, as this version includes an improved version of the tool that will prevent possible issues.

> [!NOTE]
> From DataMiner 10.3.7/10.3.0 [CU4] onwards, the Cassandra Cluster Migrator tool is able to establish TLS connections towards the databases. To enable this functionality, configure TLS encryption on your [OpenSearch database](xref:Installing_OpenSearch_database#tls-and-user-configuration) or [Elasticsearch database](xref:Security_Elasticsearch#client-server-tls-encryption) and your [Cassandra database](xref:Security_Cassandra_TLS), and enable the *Cassandra TLS* and *Elastic TLS* options when configuring the [Cassandra and OpenSearch/Elasticsearch settings](#running-the-migration) in the migration tool.<!-- RN 34852 --> For OpenSearch, configuring TLS is highly recommended.

## Prerequisites

- All DMAs must run DataMiner 10.3.0 [CU11]/10.4.2 or higher.

- A Cassandra cluster must be available using version 4.0 or higher. For information on how to install Cassandra, see [Installing Cassandra on a Linux machine](xref:Installing_Cassandra).

  > [!NOTE]
  > Previously Cassandra 3.11.8 was also supported. This will remain supported for existing installations; however, because of its increased performance, **Cassandra 4.0 is required for new Cassandra installations** if a database per cluster is used. If you have a Cassandra 3.11.8 database and you have not yet migrated your DataMiner data, we recommend upgrading to Cassandra 4.0 first.

- Either an OpenSearch cluster should be available (recommended), or an Elasticsearch cluster using version 6.8.0 or higher, but lower than 7.0.

  > [!TIP]
  >
  > - For information on how to set up an OpenSearch cluster, see [Setting up an OpenSearch database](xref:Installing_OpenSearch_database#setting-up-the-opensearch-cluster).
  > - For information on how to configure an Elasticsearch cluster, see [Configuring the Elasticsearch database](xref:Configuring_Elasticsearch_Database).

> [!NOTE]
>
> - The **migration will not clear any existing data from the given Cassandra cluster**. This means that any data that might conflict with the migrated data should first be deleted manually. We recommend that you make sure the target Cassandra cluster is clean before you proceed with the migration.
> - If there is an **existing OpenSearch/Elasticsearch cluster** connected to the DMS, this cluster will be reused and any given input regarding this cluster will be disregarded. In the existing cluster, alarms will be deleted and migrated again from the DMS. If your system contains SRM information or legacy [Jobs](xref:jobs) or [Ticketing](xref:ticketing) information, this will not be migrated, as this is expected to already be present in the OpenSearch/Elasticsearch cluster. If this is not the case, migrate this data first through DataMiner Cube (see [Configuring indexing settings in System Center](xref:Configuring_DataMiner_Indexing)).

## Stages of the migration

During the migration, each DMA will go through the following stages:

| State | Description |
|--|--|
| Not initialized | The default state of a DMA. It has not been initialized for migration to a Cassandra and OpenSearch/Elasticsearch cluster. |
| Initialized | The DMA has connected with the given Cassandra and OpenSearch/Elasticsearch clusters and is ready to start data migration. |
| Migrating | The DMA is busy migrating data. Progress can be tracked using the migrator tool. |
| Finished migrating | The DMA has finished migrating and is ready for migration finalization, i.e., ready to switch to the Cassandra and OpenSearch/Elasticsearch cluster configuration. |
| Finalized | The DMA has been restarted and switched to the Cassandra and OpenSearch/Elasticsearch cluster configuration. |

> [!NOTE]
> Once the migration is started, all new data will be sent to both the new and the old database. Writing to both databases will continue until the migration has been finalized. Even in case of a long-running migration, there will not be any gaps in the history data between the start and the end of the migration process.

## Running the migration

### [Running a regular migration](#tab/tabid-1)

If your system does not use an indexing database yet or if it already uses an OpenSearch or Elasticsearch cluster connected to the DMS, you can run a regular migration as described below. However, if your system uses an Elasticsearch database installed on a DMA, follow the procedure in the next tab, "Running a migration with bespoke Elasticsearch data".

1. If there are Failover pairs in the DataMiner System, make sure the currently active Agent in each pair is the top Agent in the Failover configuration screen.

   > [!TIP]
   > See also: [Failover configuration in Cube](xref:Failover_configuration_in_Cube).

1. On one of the DMAs in your cluster, go to `C:\Skyline DataMiner\Tools\`, and run *SLCCMigrator.exe*.

1. Initialize all the DMAs in the list using the *Initialize all agents* button.

   > [!NOTE]
   > If one or more DMAs fail to be initialized, please contact your Skyline Technical Account Manager to resolve this issue, or refer to the [Troubleshooting](#troubleshooting) section below for the solution.

1. In the pop-up window, enter the Cassandra and OpenSearch/Elasticsearch settings, and click *Confirm*. The following settings are required:

   - Cassandra settings:

     - *Cassandra IP(s)*: The IPs of the Cassandra cluster nodes. For example: `10.11.1.70,10.11.2.70,10.11.3.70` or `10.11.1.70:9042` or `CC-NODE-01,CC-NODE-02`.

     - *Keyspace prefix*: The prefix for the Cassandra keyspaces. (At most 10 characters.) For example: `dms01`.

     - *Cassandra user*: The Cassandra username.

     - *Cassandra password*: The password for the specified username.

     - *Cassandra consistency*: The consistency level. For more information, see [How is the consistency level configured?](https://docs.datastax.com/en/cassandra-oss/3.0/cassandra/dml/dmlConfigConsistency.html)

     - *Cassandra TLS*: Available from DataMiner 10.3.7/10.3.0 [CU4] onwards. Allows you to establish TLS connections towards the databases. <!-- RN 34852 -->

   - OpenSearch/Elasticsearch settings: These are not used in case there already is an OpenSearch/Elasticsearch cluster connected to your DMS. In that case, you can just fill in dummy data.

     - *Elastic IP(s)*: The IPs of the OpenSearch/Elasticsearch cluster. For example: `10.11.1.70,10.11.2.70,10.11.3.70` or `10.11.1.70:9042` or `https://10.11.1.70:9042` or `ES-NODE-01,ES-NODE-02`.

     - *Database prefix*: The prefix for the OpenSearch/Elasticsearch indices and aliases. For example: `dms`.

     - *Elastic user*: The OpenSearch/Elasticsearch username.

     - *Elastic password*: The password for the specified username.

     - *Elastic TLS*: Available from DataMiner 10.3.7/10.3.0 [CU4] onwards. Allows you to establish TLS connections towards the databases. For OpenSearch, configuring this is highly recommended.<!-- RN 34852 -->

1. Once the DMAs have been initialized, start the migration. You can do this for all DMAs at once with the *Start Migration* button at the top, or for one DMA at a time by clicking the *Details* button for that DMA and selecting *Migrate all storages*.

1. During the migration, you can monitor the progress in the main window of the tool. You can safely close the tool and open it again later. The migration process will continue even when you close *SLCCMigrator.exe*.

1. When the migration has finished, check the main window of *SLCCMigrator.exe* and make sure there are no errors.

1. When no errors are reported, click *Finalize migration* to restart all DMAs.

> [!NOTE]
>
> - During the migration, you can cancel the migration of one particular data type for one particular DMA. This will not undo any changes made to the Cassandra and OpenSearch/Elasticsearch clusters.
> - If you want to cancel the entire migration process for all DMAs, click *Abort migration*. This will undo all changes made to the DMAs.
> - When you migrate a DataMiner Failover setup, only the data of the active DMA will be migrated. Once the migration has finished, both DMAs will be restarted.

### [Running a migration with bespoke Elasticsearch data](#tab/tabid-2)

> [!NOTE]
> To migrate to a DMS with Cassandra cluster and OpenSearch cluster, it is not possible to use this procedure. An alternative procedure will become available for this in the future.

In case your DataMiner System contains bespoke Elasticsearch data or SRM data, use the procedure below.

1. If there are Failover pairs in the DataMiner System, make sure the currently active Agent in each pair is the top Agent in the Failover configuration screen.

   > [!TIP]
   > See also: [Failover configuration in Cube](xref:Failover_configuration_in_Cube).

1. Follow the step-by-step guide on [taking and restoring snapshots](xref:Configuring_Elasticsearch_backups_Windows_Linux).

   Make sure the snapshot has been [restored](xref:Configuring_Elasticsearch_backups_Windows_Linux#taking-the-snapshot) on the target Elasticsearch cluster.

1. Enter `http://[IP address]:9200/_cat/indices` in your browser's address bar. Replace "[IP address]" with your IP address.

   Take note of the prefixes used in the indices. You will need this information later. The default prefix is "dms".

   ![Prefix snapshot](~/dataminer/images/Prefix_Snapshot.png)

1. Stop your DataMiner System.

1. Open the `C:\Skyline DataMiner\db.xml` file and check if `<DataBase type="Elasticsearch">` exists.

   Example:

   ```xml
   <DataBases xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.skyline.be/config/db">
      ...
      <DataBase active="true" search="true" type="Elasticsearch">
         <DBServer>10.2.1.5</DBServer>
         <UID/>
         <PWD/>
      </DataBase>
      ...
   </DataBases>
   ```

   If you find `<DataBase type="Elasticsearch">`, replace the entries in the `<DBServer>` tag with a list of all the nodes in the target Elasticsearch cluster, separated by commas.

   > [!NOTE]
   > If you do not find `<Database type="Elasticsearch">` in the `C:\Skyline DataMiner\db.xml` file, switch to the tab on [running a regular migration](#running-the-migration).

1. Restart your DataMiner System.

1. Verify whether the snapshot restore worked by confirming that [bookings](xref:The_Bookings_module), [jobs](xref:jobs), and other custom data in Cube are still functional.

1. Navigate to `C:\Skyline DataMiner\Tools\\`, and run *SLCCMigrator.exe*.

1. Initialize all the DMAs in the list using the *Initialize all agents* button.

   > [!NOTE]
   > If one or more DMAs fail to be initialized, contact your Skyline Technical Account Manager to resolve this issue, or refer to the [Troubleshooting](#troubleshooting) section below for the solution.

1. In the pop-up window, enter the Cassandra and Elasticsearch settings, and click *Confirm*.

   The following settings are required:

   - Cassandra settings:

     - *Cassandra IP(s)*: The IPs of the Cassandra cluster nodes. For example: `10.11.1.70,10.11.2.70,10.11.3.70` or `10.11.1.70:9042` or `CC-NODE-01,CC-NODE-02`.

     - *Keyspace prefix*: The prefix for the Cassandra keyspaces. Enter `cassandra_prefix_here`.

     - *Cassandra user*: The Cassandra username.

     - *Cassandra password*: The password for the specified username.

     - *Cassandra consistency*: The consistency level. For more information, see [How is the consistency level configured?](https://docs.datastax.com/en/cassandra-oss/3.0/cassandra/dml/dmlConfigConsistency.html)

       > [!NOTE]
       >
       > - If there are less than 4 nodes, we recommend setting this to *One*.
       > - If there are more than 4 nodes, we recommend setting this to [Quorum](xref:replication_and_consistency_configuration#examples).

     - *Cassandra TLS*: Available from DataMiner 10.3.7/10.3.0 [CU4] onwards. Allows you to establish TLS connections towards the databases. <!-- RN 34852 -->

   - Elasticsearch settings: These are not used in case there already is an Elasticsearch cluster connected to your DMS. In that case, you can just fill in dummy data.

     - *Elastic IP(s)*: The IPs of the Elasticsearch cluster. For example: `10.11.1.70,10.11.2.70,10.11.3.70` or `10.11.1.70:9042` or `https://10.11.1.70:9042` or `ES-NODE-01,ES-NODE-02`.

     - *Database prefix*: The prefix for the Elasticsearch indices and aliases. Enter `elastic_prefix_here`.

       > [!NOTE]
       > When you enter "elastic_prefix_here", DataMiner will use the same prefix as mentioned in step 2 to identify the data it owns. If a different prefix is entered, it will be impossible to use the migrated data.

     - *Elastic user*: The Elasticsearch username.

     - *Elastic password*: The password for the specified username. This is not mandatory, unless manually specified.

     - *Elastic TLS*: Available from DataMiner 10.3.7/10.3.0 [CU4] onwards. Allows you to establish TLS connections towards the databases. <!-- RN 34852 -->

1. Once the DMAs have been initialized, start the migration. You can do this for all DMAs at once with the *Start Migration* button at the top, or for one DMA at a time by clicking the *Details* button for that DMA and selecting *Migrate all storages*.

   > [!IMPORTANT]
   > Make sure no data is overwritten or removed during the migration.

1. During the migration, you can monitor the progress in the main window of the tool. You can safely close the tool and open it again later. The migration process will continue even when you close *SLCCMigrator.exe*.

1. When the migration has finished, check the main window of *SLCCMigrator.exe* and make sure there are no errors.

1. When no errors are reported, click *Finalize migration* to restart all DMAs.

1. Verify whether all data in Cube is still present and functional.

> [!NOTE]
>
> - During the migration, you can cancel the migration of one particular data type for one particular DMA. This will not undo any changes made to the Cassandra and Elasticsearch clusters.
> - If you want to cancel the entire migration process for all DMAs, click *Abort migration*. This will undo all changes made to the DMAs.
> - When you migrate a DataMiner Failover setup, only the data of the active DMA will be migrated. Once the migration has finished, both DMAs will be restarted.

***

## Troubleshooting

Any errors that occur during a migration process will be displayed in a pop-up window and stored in a log file.

- To open the log file of the *SLCCMigrator.exe* tool, at the top of the main window, click *Open log file*.

- To check the migration server logging, go to `C:\Skyline DataMiner\Logging` and open *SLDBConnection.txt*.

- If you encounter **issues when you start a migration** (e.g., "No connection with DataMiner"), check if there are any [NATS issues](xref:Investigating_NATS_Issues).

- If **TLS** is enabled on the Elasticsearch or OpenSearch nodes and **some Agents do not initialize**, you can check the connection to the Elasticsearch/OpenSearch nodes as follows:

  1. Open a browser on the DataMiner servers that you want to migrate from

  1. Enter `https://[IP address]:9200/` in the browser's address bar, replacing "[IP address]" with your IP address of the nodes.

  If this fails, check if TLS was configured correctly and if the root certificate was correctly installed on the DataMiner server. See [TLS configuration for the OpenSearch database](xref:Installing_OpenSearch_database#tls-and-user-configuration) or [TLS configuration for the Elasticsearch database](xref:Security_Elasticsearch#client-server-tls-encryption).
