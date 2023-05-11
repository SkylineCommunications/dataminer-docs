---
uid: Configuring_MySQL_database_in_Cube
---

# Configuring the SQL database settings

> [!IMPORTANT]
> If a DataMiner Agent in a cluster is offline, database configuration changes will not be applied to that DataMiner Agent. From DataMiner 10.3.6/10.4.0 onwards, you will get a warning on the *Database* page in System Center to make you aware of this. However, this warning will not be triggered for the offline Agent in a Failover setup. <!-- RN 36184 -->

For a legacy MySQL or MSSQL database, configure the settings as follows:

1. Go to *Apps* > *System Center* > *Database*.

1. In the column on the left, select the Agent of which you want to configure the general database.

1. Specify the following database settings, depending on your DataMiner version:

   From DataMiner 10.0.13/10.1.0 onwards:

   - **Type**: *Database per Agent*.

   - **Database**: The type of database: *MySQL* or *MSSQL*.

     > [!NOTE]
     > MSSQL is no longer supported as the general database as from DataMiner 10.3.0.

   - **Name**: The name of the database.

   - **DB Server**: The name or IP address of the server that hosts the database.

   - **Connection string**: Can be filled in instead of the other fields, in which case this string will be used to connect to the database.

   - **User**: The username with which the DMA has to log on to Cassandra.

   - **Password**: The password with which the DMA has to log on to Cassandra.

   - **Limit alarms by maximum number**: Select this option to limit the total alarm records in the database by number.

   - **Maximum alarms**: The maximum number of alarms that can be stored in the general database.

   - **Fallback minimum**: If the maximum alarms setting has been reached, the oldest alarms will automatically be deleted until the database contains exactly the number of alarms specified in the *Fallback minimum* box.

   Earlier DataMiner versions:

   - **Type**: The type of database: *MySQL* or *MSSQL*.

   - **DB**: The name of the database.

   - **DB Server**: The name or IP address of the server that hosts the database.

   - **DSN**: This setting is no longer used.

   - **Server**: This setting is no longer used. Use the *DB Server* setting instead.

   - **Connection string**: Can be filled in instead of the other fields, in which case this string will be used to connect to the database.

   - **User**: The username with which the DMA has to log on to the general database.

   - **Password**: The password with which the DMA has to log on to the general database.

   - **Limit alarms by maximum number**: Select this option to limit the total alarm records in the database by number.

   - **Maximum alarms**: The maximum number of alarms that can be stored in the general database.

   - **Fallback minimum**: If the *Maximum alarms* setting has been reached, the oldest alarms will automatically be deleted until the database contains exactly the number of alarms specified in the *Fallback minimum* box.

1. Click *Save*.

   > [!NOTE]
   > Database configuration changes will not take effect until the Agent is restarted.

> [!NOTE]
>
> - If you use a MSSQL database, a Microsoft SQL Server Enterprise Edition license is required if partitioned data tables are used. Otherwise, the Express edition is sufficient. To run Microsoft SQL Server 2019, Windows Server 2016 or higher is required.
> - If you use an MSSQL database, prior to DataMiner v8.5.8, only user accounts of type NT AUTHORITY\\SYSTEM are supported. In more recent DataMiner versions, you can use other domain accounts, either by using a connection string containing “*Integrated Security=true;user id:Domain\\User Name;Password:PWD*”, or by setting the tag *\<IntegratedSecurity>* to true in *DB.xml*.
