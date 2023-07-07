---
uid: DB_xml
---

# DB.xml

In the file *DB.xml*, you can specify the configuration data for several databases used by the DataMiner System:

- [General database settings](#general-database-settings)

- [Offload database settings](#offload-database-settings)

- [Indexing database settings](#indexing-database-settings)

- [CMDB settings](#cmdb-settings)

  > [!TIP]
  > See also: [Inventory & Asset Management](xref:AssetManagement)

This file is located in the folder *C:\\Skyline DataMiner\\*.

Before you make changes to this file, always **stop DataMiner**. Restart DataMiner when your changes have been saved.

## General database settings

The configuration data for the general or “local” database has to be specified in a *\<Database>* tag of which the *local* attribute is set to “true”.

> [!NOTE]
>
> - The *type* attribute of the *\<Database>* tag indicates whether a MySQL, MSSQL, or Cassandra (cluster) database is used. If no *type* attribute is specified, MySQL is used as type.
> - If a separate Cassandra cluster (consisting of one or more nodes) is used for each DMA, the *type* attribute for the database is set to *Cassandra*. If an entire DMS uses the same Cassandra cluster, the *type* attribute for the database is set to *CassandraCluster*.
> - If the *CassandraCluster* type is used, *DB.xml* is synced completely throughout the cluster. With other types, the general database settings are not synced.

> [!IMPORTANT]
> MSSQL is no longer supported as the general database as from DataMiner 10.3.0.

The following configuration is possible for the general database:

- [Keeping a database table from being checked during an upgrade](#keeping-a-database-table-from-being-checked-during-an-upgrade)

- [Configuring how long parameter data are kept in the database for DMS Reporter](#configuring-how-long-parameter-data-are-kept-in-the-database-for-dms-reporter)

- [Keeping a separate log for slow database queries](#keeping-a-separate-log-for-slow-database-queries)

- [Configuring how alarm history slider data are kept in a Cassandra database](#configuring-how-alarm-history-slider-data-are-kept-in-a-cassandra-database)

- [Skipping commit log writing of a Cassandra database](#skipping-commit-log-writing-of-a-cassandra-database)

- [Setting the number of retries to connect to the Cassandra database](#setting-the-number-of-retries-to-connect-to-the-cassandra-database)

- [Enabling TLS on the Cassandra database connection](#enabling-tls-on-the-cassandra-database-connection)

- [Configuring the consistency level of Cassandra in a Cassandra cluster database](#configuring-the-consistency-level-of-cassandra-in-a-cassandra-cluster-database)

- [Example of a general database configuration](#example-of-a-general-database-configuration)

### Keeping a database table from being checked during an upgrade

When you perform an upgrade of the DataMiner Agent software, by default, all database tables are automatically checked and if necessary optimized and/or repaired.

To keep a particular database table from being checked, you can add a *\<SkipTableUpdate>* instruction to *DB.xml*.

In the example below, two tables will be kept from being checked:

```xml
<DataBases>
  <DataBase active="true" local="true" type="MySQL">
    ...
    <Maintenance monthsToKeep="12">
      <SkipTableUpdates>
        <SkipTableUpdate table="data_3012"/>
        <SkipTableUpdate table="dataavg_3012"/>
      </SkipTableUpdates>
    </Maintenance>
    ...
  </DataBase>
</DataBases>
```

> [!NOTE]
> Instead of adding a *\<SkipTableUpdate>* instruction to the file *DB.xml*, you can also add a comment to a database table in order to keep that table from being checked during a DataMiner software upgrade. For example, to add a 'DataMiner Customized' comment to a MySQL table, run the following SQL command (in which you replace “xxx” by the actual table name): `ALTER TABLE xxx COMMENT = 'DataMiner Customized'`
>
> However, note that this causes that that entire table to be copied to a temporary table, which has a negative impact on query duration, so this is not recommended.

### Configuring how long parameter data are kept in the database for DMS Reporter

In order to make sure that parameter data is not removed from the database too early, two additional attributes are available in the *Maintenance* tag:

- **initialLoadDays**: The number of days that parameter data will be kept in the rep_pd_info database table on first request. Default: 62.

- **paramMaxUnusedDays** The maximum number of days between each request for the parameter data to be kept in the rep_pd_info database.

This configuration can for instance be of use to ensure that a report with data for the past month will contain all parameter information for the entire month, as otherwise data might already have been removed during database maintenance.

Example:

```xml
<Maintenance monthsToKeep="12" initialLoadDays="30" paramMaxUnusedDays="15"> </Maintenance>
```

In the example above, the parameter data will be kept in the rep_pd_info table for 30 days. If the parameter data is not requested for 15 consecutive days, all data older than 30 days will be removed.

### Keeping a separate log for slow database queries

In the *Database* tag, you can use the **slowquery** attribute to configure slow query log settings for the database in question. A separate log will then be kept with all database queries that take longer than the configured number of seconds:

- The log file is kept in the following location: *C:\\Skyline DataMiner\\Logging\\SLDatabase_SlowQuery\[ProcessName\].txt*

- Each log entry has the following syntax: *Date Time \| ThreadId \| DatabaseName \| QueryTime \| Query*

- The default value of the slowquery attribute is 600 (i.e. 10 minutes).

Example:

```xml
<DataBase active="TRUE" local="true" slowquery="5"> ... </DataBase>
```

In the above example, the slowquery attribute is set to “5”, so all database queries that take 5 seconds or longer to finish will be logged in the slow query log.

### Configuring how alarm history slider data are kept in a Cassandra database

In a Cassandra general database, the timetrace table among others contains “snapshots”, which are used to visualize history alarm information in the DataMiner Cube history slider.

- By default, timetrace snapshots are saved every 100 rows. To change this setting, set a different value in the *\<SnapshotInterval>* tag for the Cassandra database.

    > [!NOTE]
    >
    > - In some cases, e.g. when DataMiner or Cassandra restarts, snapshots can be saved outside the default interval specified in the \<SnapshotInterval> setting.
    > - This can only be configured for a regular Cassandra database, not for a Cassandra cluster used by the entire DMS (type=CassandraCluster).

### Skipping commit log writing of a Cassandra database

In order to optimize the writing speed to a Cassandra database, an option can be specified that will skip the writing of the commit log.

> [!CAUTION]
> This option should only be used if performance of disk writes is an issue. It should never be used when two disks are in use or in a Failover setup. In general, we advise not to use this option. We are not responsible for any data loss caused if you do.

To add this option, In *DB.xml*, add a *\<SkipCommitLog>* tag to the currently active Cassandra database. For example:

```xml
<DataBases xmlns="http://www.skyline.be/config/db">
  ...
  <DataBase active="true" type="Cassandra" local="true">
    <DBServer>localhost</DBServer>
    ...
    <SkipCommitLog>True</SkipCommitLog>
  </DataBase>
  ...
</DataBases>
```

### Setting the number of retries to connect to the Cassandra database

You can specify how many times the *SLDataGateway* process should try to connect to the Cassandra database at startup.

To do so, specify the number of retries in the *\<ConnectionRetries>* tag. For example:

```txt
...
<DataBase active="true" local="true" type="Cassandra">
    <ConnectionRetries>80</ConnectionRetries>
</DataBase>
...
```

Between each retry, there will be a 30-second interval. By default, there are 60 retries, which equals a 30-minute period.

If Cassandra still cannot be reached after SLDataGateway has tried to connect for the maximum number of times specified in this setting, there will be no connection. To try to connect after this, a restart of the SLDataGateway process is required.

### Enabling TLS on the Cassandra database connection

From DataMiner 10.2.0/10.1.3 onwards, it is possible to enable TLS on a Cassandra database connection.

To do so

1. Enable TLS in the settings of the Cassandra database itself.

1. Enable TLS in the settings of the relevant database in DB.xml. For example:

    ```xml
    <DataBase active="true" local="true" type="Cassandra">
     <DBServer>10.10.10.10</DBServer>
     <UID>myUserId</UID>
     <PWD>myPassword</PWD>
     <DB>SLDMADB</DB>
     <TLSEnabled>true</TLSEnabled>
    </DataBase>
    ```

> [!NOTE]
>
> - This procedure only enables TLS on the database connection. It does not enable client authentication.
> - From DataMiner 10.1.3 onwards TLS 1.0 is supported. From DataMiner 10.2.4/10.2.0-CU1 onwards, TLS 1.0, 1.1 and 1.2 are supported.
> - When Cassandra is hosted on the local DataMiner server, and DataMiner Failover is active, Cassandra will use TCP port 7001 for TLS encrypted inter-node communication (instead of port 7000). Make sure this port is allowed through the firewall of both Failover agents.
> - This setting is also needed to use an [Azure Managed Instance for Apache Cassandra](xref:Azure_Managed_Instance_for_Apache_Cassandra).

### Configuring the consistency level of Cassandra in a Cassandra Cluster database

If your DMS uses the Cassandra Cluster database type (i.e. one Cassandra cluster for the entire DMS) , you can configure the **consistency level** of the Cassandra database. This is done by means of the **consistencyLevel** attribute. For detailed information, see [Consistency level](xref:replication_and_consistency_configuration#consistency-level).

### Example of a general database configuration

The following example illustrates the configuration of a general database of type Cassandra cluster (i.e. one Cassandra cluster for the entire DMS, also known as the “Cassandra cluster” feature, available from DataMiner 10.1.0/10.1.2 onwards). As this also requires an Elasticsearch database (see [Indexing database settings](#indexing-database-settings)), the configuration for this database is included in the example:

```xml
<DataBases xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/config/db">
 <DataBase active="true" local="true" type="CassandraCluster" consistencyLevel="Quorum">
 <DBServer>localhost,10.3.1.100</DBServer>
 <DB>sldmadb</DB>
 <UID>root</UID>
 <PWD>root</PWD>
 </DataBase>
 <DataBase active="true" search="true" type="Elasticsearch">
 <DBServer>localhost:9200,10.3.1.100</DBServer>
 <UID>root</UID>
 <PWD/>
 </DataBase>
</DataBases>
```

## Offload database settings

The configuration data for the offload or “central” database has to be specified in a *\<Database>* tag of which the *local* attribute is set to “false”.

> [!NOTE]
> The *type* attribute of the *\<Database>* tag indicates whether a MySQL, MSSQL or Oracle database is used. If no *type* attribute is specified, MySQL is used as type.

The following configuration is possible for the offload database:

- [Keeping a separate log for slow database queries](#keeping-a-separate-log-for-slow-database-queries)

- [Specifying the tables to be offloaded](#specifying-the-tables-to-be-offloaded)

- [Specifying which type of average trend data records to offload](#specifying-which-type-of-average-trend-data-records-to-offload)

- [Specifying the offload rate of real-time trend data records](#specifying-the-offload-rate-of-real-time-trend-data-records)

- [Configuring the collation for an MSSQL database](#configuring-the-collation-for-an-mssql-database)

- [Configuring data offloads to an MSSQL database in another domain](#configuring-data-offloads-to-an-mssql-database-in-another-domain)

- [Configuring data offloads to an Oracle database](#configuring-data-offloads-to-an-oracle-database)

- [Offloading trend data even if no parameter values change](#offloading-trend-data-even-if-no-parameter-values-change)

- [Offloading files to a file cache](#offloading-files-to-a-file-cache)

For a configuration example, refer to:

- [Example of an offload database configuration](#example-of-an-offload-database-configuration)

### Keeping a separate log for slow offload database queries

Like for the general database, for the offload database you can keep a separate log for slow database queries.

See [Keeping a separate log for slow database queries](#keeping-a-separate-log-for-slow-database-queries).

### Specifying the tables to be offloaded

In the *DataBases.Database.Offloads* tag, add an *\<Offload>* tag for every table of the general database that has to be offloaded. Do not forget to specify a *state="active"* attribute.

> [!NOTE]
> If no tables are specified in the *\<Offloads>* tag, the alarm table will be the only table that will be offloaded.

### Specifying which type of average trend data records to offload

In the *DataBases.Database.Offloads.Offload* tag, you can use the *record* attribute to specify the type of average trend data records that should be offloaded.

- If the record attribute is set to 5, the 5-minute trend data records will be offloaded.
- If the record attribute is set to 60, the 60-minute trend data records will be offloaded.

Example:

```xml
<DataBases>
  <DataBase>
    <Offloads>
      ...
      <Offload state="active" local="dataavg" record="60" />
      ...
    </Offloads>
  </DataBase>
</DataBases>
```

### Specifying the offload rate of real-time trend data records

In the DataBases.Database.Offloads.Offload tag, you can use the *rate* attribute to specify two settings (separated by a semicolon):

- How frequently the system has to offload the real-time trend data records to the offload database (in minutes). Range: 1 to 1440.

- Whether the system has to offload only the values that have changed since the last offload (TRUE) or all values (FALSE). This is an optional setting. Default: FALSE.

In the following example, “1;TRUE” means that the real-time trend data records will be offloaded every minute and that only the changed values will be offloaded:

```xml
<DataBases>
  <DataBase>
    <Offloads>
      ...
      <Offload state="active" local="data" rate="5;FALSE" />
      ...
    </Offloads>
  </DataBase>
</DataBases>
```

> [!NOTE]
>
> - If you specify an offload rate, then the real-time trend data records with a negative iStatus value other than -9, -10, -15 and -16 will not be offloaded. Also, since the periodic offloads are not triggered by a user, the *chOwner* field of the offloaded records will be empty.
> - If you specify an offload interval larger than 24 hours, DataMiner will set the offload interval to the maximum value, i.e. 24 hours.

### Configuring the collation for an MSSQL database

In the Database.Collation tag, you can specify the collation for an offload database of type Microsoft SQL Server. The default collation is “SQL_Latin1_General_CP1_CI_AS”.

Example:

```xml
<DataBase active="true" local="false" type="MSSQL">
  <DBServer>SERVER</DBServer>
  <DB>SLDMSDB</DB>
  <UID>root</UID>
  <PWD>...</PWD>
  <Collation>Polish_100_CI_AI</Collation>
  <Offloads>
    ...
  </Offloads>
</DataBase>
```

### Configuring data offloads to an MSSQL database in another domain

If the offload database is situated in another domain, you can override the machine name with the IP address. That way, the offload database will be able to access the offload files on the other domain.

1. Go to the \<DataBase> section containing the configuration of the offload database.

1. Specify the IP address of the DMA in the *dmaIp* attribute of the *RemoteFileShare* tag.

Example:

```xml
<DataBase active="true" local="false" type="MSSQL">
  ...
  <RemoteFileShare dmaIp="10.10.10.100" />
  ...
</DataBase>
```

### Configuring data offloads to an Oracle database

If the offload database is an Oracle Database, then add a *RemoteFileShare* tag with the following attributes:

- **path**: The UNC path to the shared folder (located on the database server) in which the DMAs will place the “offload” files.

- **uid**: The username with which to connect to the shared folder on the database server.

- **pwd**: The password with which to connect to the shared folder on the database server.

- **localPath** The local path to the shared folder on the database server.

### Offloading trend data even if no parameter values change

From DataMiner 8.0.5 onwards, average trend information is only saved to the offload database when a parameter value changes. However, from DataMiner 9.0.0 CU10 onwards, you can add an option to the offload database configuration to revert to the behavior of older DataMiner versions, so that average trend information is offloaded regardless of whether parameter values have changed.

To do so:

1. Stop the DMA.

1. Open the file *DB.xml* (in the folder *C:\\Skyline DataMiner\\*).

1. In the offload database's *\<offload>* tag containing *local="dataavg"*, add the option *oldstyle="true"*.

    Example:

    ```xml
    <DataBase active="true" local="false" type="MSSQL">
      ...
      <Offloads>
        ...
        <Offload state="active" local="dataavg" remote="DataAvg" oldstyle="true" />
      </Offloads>
    </DataBase>
    ```

1. Save and close *DB.xml*, and restart the DMA.

### Offloading files to a file cache

To support the offload of files to a file cache instead of to a MySQL, MSSQL or Oracle offload database, a *FileCache* tag is supported in the DB.xml from DataMiner 10.0.11 onwards.

To configure this:

1. Stop the DMA.

1. Open the file *DB.xml* (in the folder *C:\\Skyline DataMiner\\*).

1. If it is not yet present, add the *\<FileCache>* tag under the *\<Database>* tag for the offload database.

1. Set the *enabled* attribute of the tag to *true* and specify the maximum size of the cache in the *\<MaxSizeKB>* subtag (default = 10 GB).

    For example:

    ```xml
    <DataBase active="true" local = "false">
     <FileCache enabled="true">
     <MaxSizeKB>10000</MaxSizeKB>
     </FileCache>
    </DataBase>
    ```

1. Save and close *DB.xml*, and restart the DMA.

> [!NOTE]
> In DataMiner 10.0.11, this can only be configured in *DB.xml*. However, from DataMiner 10.2.0/10.1.1 onwards, you can configure this directly in DataMiner Cube. See [Offload database](xref:Offload_database).

### Example of an offload database configuration

```xml
<DataBases xmlns="http://www.skyline.be/config/db">
  ...
  <DataBase active="true" local="false" type="MSSQL">
    <ConnectString></ConnectString>
    <Server></Server>
    <DBServer></DBServer>
    <DSN></DSN>
    <DB>SLDMSDB</DB>
    <UID>root</UID>
    <PWD></PWD>
    <RemoteFileShare path="\\MyDbServer\DataMinerOffload\" uid="MyFolderLogonName" pwd="MyFolderLogonPwd"  localPath="C:\Documents and Settings\All Users\Documents\DataminerOffload\" />
    <Offloads>
      <Offload state="active" local="data"/>
      <Offload state="active" local="dataavg"/>
      <Offload state="active" local="alarm"/>
      <Offload state="active" local="info"/>
      <Offload state="active" local="alarm_property"/>
      <Offload state="active" local="brainlink"/>
      <Offload state="active" local="service_alarm"/>
    </Offloads>
  </DataBase>
  ...
  <DataBase active="TRUE" local="false" type="oracle">
    <ConnectString>
      Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=myServer)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=myOracleDb)));
      User Id=myUsername;
      Password=myPassword;
    </ConnectString>
    <RemoteFileShare
      path="\\myServer\DataMinerOffload\"
      uid="myServer\myOffloadUser"
      pwd="myOffloadPassword"
      localPath="C:\DataminerOffload\"/>
    <Offloads>
    <Offload state="active" local="data"/>
    <Offload state="active" local="dataavg"/>
    <Offload state="active" local="alarm"/>
    <Offload state="active" local="info"/>
    <Offload state="active" local="alarm_property"/>
    <Offload state="active" local="brainlink"/>
    <Offload state="active" local="service_alarm"/>
    </Offloads>
  </DataBase>
  ...
</DataBases>
```

## Indexing database settings

Elasticsearch can be installed on DMAs with a Cassandra database as an additional indexing database. In that case, an additional database will be added to *DB.xml*.

The *\<Database>* tag for an Elasticsearch database has the following attributes:

- **active**: If set to true, the database is active.

- **search**: If set to true, indicates that the database is an indexing database.

- **type**: Currently only “Elasticsearch” is supported. This same value is used For OpenSearch and Amazon OpenSearch Service databases.

> [!NOTE]
>
> - There can only be one active indexing database on a DMA. However, that database can consist of multiple nodes. In that case, the IP addresses for these nodes are all added in the DBServer tag, separated by commas. For example: `<DBServer>10.10.10.1,10.10.10.2,10.10.10.3</DBServer>`
> - From DataMiner 10.2.0/10.1.1 until DataMiner 10.3.0/10.3.3, Elastic Amazon AWS can be used. In that case, the URL should be specified in the DBServer element. For example: *\<DBServer>mycompany-elastic.amazonaws.com\</DBServer>*.
> - From DataMiner 10.3.0/10.3.3 onwards, OpenSearch and Amazon OpenSearch Services can be used.
> - From DataMiner 10.2.0/10.1.3 onwards, a *DBConfiguration.xml* file can be configured, which overrides the settings in this section of *DB.xml*. See [Configuring multiple Elasticsearch clusters](xref:Configuring_multiple_Elasticsearch_clusters).

### Defining a custom port for an Elasticsearch database

From DataMiner 10.0.7 onwards, you can define a custom port for an Elasticsearch database. By default, port 9200 is used.

To define a different port:

1. Stop the DMA.

1. Open the file *DB.xml* (in the folder *C:\\Skyline DataMiner\\*).

1. In the \<DBServer> element for the Indexing database, add a colon after the hostname or IP and specify the port.

    For example:

    ```xml
    <DBServer>10.11.3.57:9201</DBServer>
    ```

    > [!NOTE]
    > The port specified in *DB.xml* must always be the same as the port defined in the Elasticsearch configuration. By default, this configuration is located in the folder *C:\\Program Files\\Elasticsearch\\config\\elasticsearch.yml*.

1. Save the file and restart the DMA.

### Specifying a custom prefix for the Elasticsearch indexes

To support the possibility to have two independent DataMiner Systems using the same Elasticsearch cluster, from DataMiner 10.0.11 onwards, you can specify a custom prefix for the Elasticsearch indices, instead of the default "dms" prefix.

To do so:

1. Stop the DMA.

1. Open the file *DB.xml* (in the folder *C:\\Skyline DataMiner\\*).

1. In the *DB* element for the indexing database, specify the custom prefix. Keep in mind that only regular alphanumeric characters are supported for the prefix, not symbols.

1. Save the file and restart the DMA.

### Specifying custom credentials for Elasticsearch

From DataMiner 10.0.11 onwards, it is possible to configure a custom username and password for Elasticsearch in *DB.xml*.

To do so:

1. Stop the DMA.

1. Open the file *DB.xml* (in the folder *C:\\Skyline DataMiner\\*).

1. In the *UID* and *PWD* elements below the Elasticsearch *Database* tag, specify the username and password, respectively.

    For example:

    ```xml
    <DataBase active="true" search="true" type="Elasticsearch">
     <DBServer>10.11.51.58</DBServer>
     <UID>elastic</UID>
     <PWD>password123</PWD>
    </DataBase>
    ```

1. Save the file and restart the DMA.

> [!NOTE]
> For more information on how to configure TLS and security in Elasticsearch, see [Securing the Elasticsearch database](xref:Security_Elasticsearch).

## CMDB settings

If you have a CMDB (Configuration Management Database) that you want to manage by means of the DataMiner Inventory & Asset Management module, then you can specify the configuration data for that CMDB in an additional *\<Database>* tag.

> [!NOTE]
> The *\<Database>* tag containing the configuration data for the CMDB must not have a *local* attribute. However, it must have a *name* attribute of which the value (i.e. the name of the database configuration) must be identical to the value specified in the *\<DatabaseConfig>* tag of the Inventory & Asset Management configuration file.

> [!TIP]
> See also: [Configuring DataMiner Inventory and Asset Management](xref:Configuring_DMS_Inventory_and_Asset_Management)

Example 1:

```xml
<DataBases xmlns="http://www.skyline.be/config/db"> ... <DataBase active="true" name="MyOracleCmdb" type="oracle"> <ConnectString> SERVER=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=MyServer)(PORT=1512)) (CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE))); uid=myusername;pwd=mypassword </ConnectString> </DataBase> ... </DataBases>
```

Example 2:

```xml
<DataBases xmlns="http://www.skyline.be/config/db"> ... <DataBase active="true" name="MySqlSvrCmdb" type="mssql"> <ConnectString></ConnectString> <Server>10.10.51.1</Server> <DBServer>10.10.51.1</DBServer> <DSN></DSN> <DB>DMSConfiguration</DB> <UID>MyUserName</UID> <PWD>MyPassword</PWD> </DataBase> ... </DataBases>
```
