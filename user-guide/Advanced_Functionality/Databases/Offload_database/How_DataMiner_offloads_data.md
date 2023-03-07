---
uid: How_DataMiner_offloads_data
---

# How DataMiner offloads data

As soon as the offload database is activated, data from the DataMiner System will be offloaded to it. Data from before the time of activation will not be offloaded. If the offload database is deactivated for some time and then activated again, there will be a gap in the data stored in the offload database.

If the offload database cannot be reached for some time while it is activated, the offload files will be stored for as long as the database cannot be reached. As soon as the connection has been established again, the offload files will be processed.

## Offload database of type MySQL

1. *SLDatabase.dll* orders *Mysql.data.dll* to load a CSV file into a particular database table by sending it the query to be executed.

   Example:

   ```txt
   LOADDATA LOCAL INFILE ‘C:\SKYLINE DATAMINER\SYSTEM CACHE\OFFLOAD\data.csv’INTO TABLE ALARM
   ```

1. *Mysql.data.dll* reads the CSV file.

1. *Mysql.data.dll* pushes the contents to the MySQL database via IP port 3306.

   ![Offload database of type MySQL](~/user-guide/images/db_offload_mysql.jpg)

## Offload database of type MSSQL

1. *SLDatabase.dll* orders *system.data.dll* to load a CSV file into a particular database table by sending it the query to be executed.

   Example:

   ```txt
   BULK INSERT ALARM FROM‘\\[DMAIP]\Offload’ WITH (DATAFILETYPE=’wildcard’, FIELDTERMINATOR = ‘\t’)
   ```

1. *system.data.dll* forwards the query to the MSSQL database via IP port 1433.

   See also: <https://msdn.microsoft.com/en-us/library/cc646023.aspx>

1. The MSSQL database fetches the CSV file from the shared folder on the DataMiner Agent via IP ports 139 and 445, and inserts the contents of the file into the table in question.

   See also: <https://technet.microsoft.com/en-us/library/cc731402(v=ws.11).aspx>

   ![Offload database of type MSSQL](~/user-guide/images/db_offload_mssql.jpg)

> [!NOTE]
> The folder *C:\\Skyline DataMiner\\System Cache\\Offload* has to be shared as “\\\\\[server\]\\Offload” with anonymous access. See also: [Configuring data offloads to an MSSQL database in another domain](xref:DB_xml#configuring-data-offloads-to-an-mssql-database-in-another-domain).

## Offload database of type Oracle

1. DataMiner copies the CSV file to be offloaded to the shared folder on the Oracle database server via IP ports 139 and 445.

   See also: <https://technet.microsoft.com/en-us/library/cc731402(v=ws.11).aspx>

1. SLDatabase.dll orders Oracle.ManagedDataAccess.dll to load the CSV file into a particular database table by sending it the queries to be executed.

   Example:

   ```txt
   CREATE TABLE ALARM_load + [definition] + LOCATION (‘[localPath in Db.xml]’)MERGE INTO ALARM USING (SELECT x FROM ALARM_load)…DROP TABLE ALARM_load
   ```

1. Oracle.ManagedDataAccess.dll forwards the queries to the Oracle database via IP port 1521.

   See also: [https://docs.oracle.com/cd/B19306_01/install.102/b15660/app_port.htm](https://docs.oracle.com/cd/B19306_01/install.102/b15660/app_port.htm)

1. The Oracle database fetches the CSV file from its (local) shared, and inserts the contents of the file into the table in question.

![Offload database of type Oracle](~/user-guide/images/db_offload_oracle.jpg)

> [!NOTE]
> On the Oracle database server, a shared folder has to be created, the DataMiner Agents have to be granted access to that shared folder, and a *RemoteFileShare* tag has to be configured in the *DB.xml* file of the DataMiner server. See [Configuring data offloads to an Oracle database](xref:DB_xml#configuring-data-offloads-to-an-oracle-database).
