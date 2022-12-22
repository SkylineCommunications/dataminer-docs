---
uid: Configuring_the_database_settings_in_Cube
---

# Configuring the general database settings in Cube

The general database is the main database used by a DataMiner Agent to store its data. By default, this is a Cassandra database. In legacy setups, a MySQL or MS SQL database can be used.

In older DataMiner systems, this database was also known as the "local database", as the MySQL or MSSQL database was typically hosted locally on the same machine as DataMiner.

> [!NOTE]
>
> - Settings related to the Elasticsearch database are configured separately. See [Elasticsearch database](xref:Elasticsearch_database).
> - If you want to have an external program do queries on a DataMiner database, you will need to use an offload database for this. For information on offload database settings, see [Offload database](xref:Offload_database).

## Cassandra database

### [Cassandra cluster database](#tab/tabid-1)

For a Cassandra cluster database (i.e. one Cassandra cluster that is used as the general database for the entire DMS, rather than one Cassandra cluster per DMA), configure the settings as follows:

1. Go to *Apps* > *System Center* > *Database*.

1. Specify the following database settings:

   - **Type**: *Database per cluster*.

   - **Database**: The type of database, i.e. *CassandraCluster*.

   - **Keyspace prefix** or **Name**: The prefix that the DataMiner System will use to create the keyspaces.

   - **DB server**: The IP addresses of the nodes, separated by commas.

   - **User**: Username with which the DMA has to log on to Cassandra.

   - **Password**: Password with which the DMA has to log on to Cassandra.

1. Click *Save*.

### [Cassandra database per DMA](#tab/tabid-2)

In case a separate Cassandra cluster is used per DMA, configure the settings as follows:

1. Go to *Apps* > *System Center* > *Database*.

1. In the column on the left, select the Agent of which you want to configure the general database.

1. Specify the following database settings, depending on your DataMiner version:

   From DataMiner 10.0.13/10.1.0 onwards:

   - **Type**: *Database per Agent*.

   - **Database**: The type of database, i.e. *Cassandra*.

   - **Name**: The name of the database.

   - **DB Server**: Name or IP address of the server that hosts the database.

   - **Connection string**: Can be filled in instead of the other fields, in which case this string will be used to connect to the database.

   - **User**: Username with which the DMA has to log on to Cassandra.

   - **Password**: Password with which the DMA has to log on to Cassandra.

   Earlier DataMiner versions:

   - **Type**: The type of database, i.e. *Cassandra*.

   - **DB**: The name of the database.

   - **DB Server**: Name or IP address of the server that hosts the database.

   - **Connection string**: Can be filled in instead of the other fields, in which case this string will be used to connect to the database.

   - **User**: Username with which the DMA has to log on to the general database.

   - **Password**: Password with which the DMA has to log on to the general database.

   - **Limit alarms by months to keep**: Deprecated from DataMiner 9.6.0/9.6.3 onwards. Use the TTL settings instead. See [Specifying TTL overrides](xref:Specifying_TTL_overrides). In legacy systems, this option limits the total alarm records in the database by date.

   - **Months to keep**: Deprecated from DataMiner 9.6.0/9.6.3 onwards. Use the TTL settings instead. See [Specifying TTL overrides](xref:Specifying_TTL_overrides). In legacy systems, this option indicates the number of months that the alarms will be kept in the general database. Note that in a Cassandra database, the maximum duration that a record can continue to exist is twenty years.

1. Click *Save*.

***

## Amazon Keyspaces database

> [!IMPORTANT]
> An Amazon Keyspaces database requires a separate indexing database.
>
> For information on how to configure an indexing database, see [ElasticSearch database](xref:Elasticsearch_database).

To configure the connection to an [Amazon Keyspaces database](xref:Amazon_Keyspaces_Service), configure the settings as follows:

1. In DataMiner Cube, go to *System Center* > *Database*.

1. Specify the following database settings:

   - **Type**: *Database per cluster*.

   - **Database**: The type of database, i.e. *Amazon Keyspaces*.

   - **Keyspace prefix**: The name all Amazon Keyspaces will be prefixed with. This will be identical for all DMAs in the same cluster.

   - **DB Server**: The url of the [global endpoint](https://docs.aws.amazon.com/keyspaces/latest/devguide/programmatic.endpoints.html) of the region your Amazon Keyspaces cluster is in. (e.g. `cassandra.eu-north-1.amazonaws.com`).

   - **User**: The username of your AWS user account.

   - **Password**: The password of your AWS user account.

1. Restart the DMS.

   This can take multiple minutes the first time, as the keyspaces and tables will be created. In case of trouble, you can find the relevant logging in the *SLDBConnection.txt* file.

![Cube Database Configuration](~/user-guide/images/aks_cube_config.png)<br>
*DataMiner 10.3.2 example configuration*

## Legacy MySQL or SQL database

For a legacy MySQL or SQL database, configure the settings as follows:

1. Go to *Apps* > *System Center* > *Database*.

1. In the column on the left, select the Agent of which you want to configure the general database.

1. Specify the following database settings, depending on your DataMiner version:

   From DataMiner 10.0.13/10.1.0 onwards:

   - **Type**: *Database per Agent*.

   - **Database**: The type of database: *MySQL* or *MSSQL*.

   - **Name**: The name of the database.

   - **DB Server**: Name or IP address of the server that hosts the database.

   - **Connection string**: Can be filled in instead of the other fields, in which case this string will be used to connect to the database.

   - **User**: Username with which the DMA has to log on to Cassandra.

   - **Password**: Password with which the DMA has to log on to Cassandra.

   - **Limit alarms by maximum number**: Select this option to limit the total alarm records in the database by number.

   - **Maximum alarms**: The maximum number of alarms that can be stored in the general database.

   - **Fallback minimum**: If the maximum alarms setting has been reached, the oldest alarms will automatically be deleted until the database contains exactly the number of alarms specified in the *Fallback minimum* box.

   Earlier DataMiner versions:

   - **Type**: The type of database: *MySQL* or *MSSQL*.

   - **DB**: The name of the database.

   - **DB Server**: Name or IP address of the server that hosts the database.

   - **DSN**: This setting is no longer used.

   - **Server**: This setting is no longer used. Use the *DB Server* setting instead.

   - **Connection string**: Can be filled in instead of the other fields, in which case this string will be used to connect to the database.

   - **User**: Username with which the DMA has to log on to the general database.

   - **Password**: Password with which the DMA has to log on to the general database.

   - **Limit alarms by maximum number**: Select this option to limit the total alarm records in the database by number.

   - **Maximum alarms**: The maximum number of alarms that can be stored in the general database.

   - **Fallback minimum**: If the maximum alarms setting has been reached, the oldest alarms will automatically be deleted until the database contains exactly the number of alarms specified in the *Fallback minimum* box.

   - **Limit alarms by months to keep**: Deprecated from DataMiner 9.6.0/9.6.3 onwards. Use the TTL settings instead. See [Specifying TTL overrides](xref:Specifying_TTL_overrides). In legacy systems, this option limits the total alarm records in the database by date.

   - **Months to keep**: Deprecated from DataMiner 9.6.0/9.6.3 onwards. Use the TTL settings instead. See [Specifying TTL overrides](xref:Specifying_TTL_overrides). In legacy systems, this option indicates the number of months that the alarms will be kept in the general database.

1. Click *Save*.

> [!NOTE]
>
> - If you use a MSSQL database, a Microsoft SQL Server Enterprise Edition license is required if partitioned data tables are used. Otherwise, the Express edition is sufficient. To run Microsoft SQL Server 2019, Windows Server 2016 or higher is required.
> - If you use an MSSQL database, prior to DataMiner v8.5.8, only user accounts of type NT AUTHORITY\\SYSTEM are supported. In more recent DataMiner versions, you can use other domain accounts, either by using a connection string containing “*Integrated Security=true;user id:Domain\\User Name;Password:PWD*”, or by setting the tag *\<IntegratedSecurity>* to true in *DB.xml*.
