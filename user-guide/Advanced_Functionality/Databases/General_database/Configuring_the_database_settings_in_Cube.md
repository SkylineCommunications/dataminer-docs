---
uid: Configuring_the_database_settings_in_Cube
---

# Configuring the database settings in Cube

To configure the general database, go to *Apps* > *System Center* > *Database*.

## [Cassandra cluster database](#tab/tabid-1)

For a Cassandra cluster database (i.e. one Cassandra cluster that is used as the general database for the entire DMS, rather than one Cassandra cluster per DMA), configure the settings as follows:

1. Specify the following database settings:

   - **Type**: *Database per cluster*.

   - **Database**: The type of database, i.e. *CassandraCluster*.

   - **Name**: The prefix that the DataMiner System will use to create the keyspaces.

   - **DB server**: The IP addresses of the nodes, separated by commas.

   - **User**: Username with which the DMA has to log on to Cassandra.

   - **Password**: Password with which the DMA has to log on to Cassandra.

1. Click *Save*.

## [Cassandra database per DMA](#tab/tabid-2)

In case a separate Cassandra cluster is used per DMA, configure the settings as follows:

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

## [Legacy MySQL or SQL database](#tab/tabid-3)

For a legacy MySQL or SQL database, configure the settings as follows:

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

***
