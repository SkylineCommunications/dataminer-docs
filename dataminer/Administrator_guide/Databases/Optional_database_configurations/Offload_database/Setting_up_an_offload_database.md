---
uid: Setting_up_an_offload_database
keywords: central database
---

# Setting up an offload database

> [!NOTE]
> This feature is not available if [Swarming](xref:Swarming) is enabled.

## Server configuration

The first step in setting up an offload or "central" database is the configuration of the server that will host the offload database.

Depending on the type of database, the procedure is slightly different.

### [For MySQL](#tab/tabid-1)

1. Install the MySQL Server database software.

   - MySQL versions up to 8.0 are supported (using connector version 6.9.12). However, to use MySQL 8.0, an additional change is needed within the database. You need to set the *local_infile* variable to 1. In previous versions, this was not a default version, but this has changed. To do this in the database, you can use the command `SET GLOBAL local_infile=1;`.
   - Do not activate strict mode (STRICT_TRANS_TABLES) during installation. If you do so, the database offloads will fail.

1. Create and configure the MySQL remote user account that will be used by the different DMAs to connect to the offload database:

   1. Open the user account manager.

   1. Click *Add* and configure the remote user.

   1. Click *Save*.

   > [!NOTE]
   >
   > - The user account should at least be granted the following rights:
   >   - SELECT
   >   - INSERT
   > - Make sure the user account has access to the database server from the DMA, so that it can reach the offload database.

1. Create a database (e.g., named "sldmsdb") and tables:

   1. Open MySQL and right-click the MySQL server to create a database

   1. In the right-click menu, select *Make new \> Database*.

   1. Fill in "sldmsdb" as the database name, make sure *Collation* is set to *utf8 - default collation* and click *OK*.

   1. From the `C:\Skyline DataMiner\Tools` directory, run the following script to create the tables: *CentralTabledef.txt*.

   > [!NOTE]
   >
   > - Note that the script in *CentralTabledef.txt* will drop any tables in the selected database (causing these to be permanently deleted) and recreate the schema, so it must be used with caution.
   > - Alternatively, you can also use the program SLOffload.exe from the `C:\Skyline DataMiner\Tools` directory to do an offload to your new database. However, note that running this program involves a restart of the DMA.

   > [!TIP]
   > See also: [Automatic creation and verification of the offload database](#automatic-creation-and-verification-of-the-offload-database)

### [For MSSQL](#tab/tabid-2)

1. Install the MSSQL Server database software.

   - While setting up the installation, choose the authentication mode *Mixed Mode*.
   - To run Microsoft SQL Server 2019, Windows Server 2016 or higher is required.

1. Create and configure the MSSQL remote user account that will be used by the different DMAs to connect to the offload database:

   1. Open the Microsoft SQL Server Management Studio and connect to the server.

   1. In the *Object Explorer*, right-click the *Login* folder and select *New Login*.

   1. Configure the user in the *Login - New* window and click *OK*.

   > [!NOTE]
   >
   > - The user account should at least be granted the following rights:
   >   - SELECT
   >   - INSERT
   > - Make sure the user account has access to the database server from the DMA, so that it can reach the offload database.

1. Create a database (e.g., named "sldmsdb") and tables:

   1. Open Microsoft SQL Server Management Studio, and connect to the SQL server with the user account you created earlier.

   1. Right-click *Databases* and select *New Database*.

   1. Fill in "SLDMSDB" as *Database name*, and click *OK*.

   1. From the `C:\Skyline DataMiner\Tools` directory, run the following script to create the tables: *CentralTableDefSQLServer.sql*.

   > [!TIP]
   > See also: [Automatic creation and verification of the offload database](#automatic-creation-and-verification-of-the-offload-database)

### [For Oracle](#tab/tabid-3)

1. Install the Oracle database software.

1. Use the Oracle Apex web interface or [Oracle SQL Developer](https://www.oracle.com/europe/database/sqldeveloper/) to create the user account that will be used by the different DMAs to connect to the offload database (e.g., `DATAMINER`) and set up a workspace.

     Make sure the Oracle user has the following permissions:

     ```sql
     -- Allow the user to connect
     GRANT CREATE SESSION TO DATAMINER;
     
     -- Allow the user to create the tables
     GRANT CREATE TABLE TO DATAMINER;
     GRANT CREATE SEQUENCE TO DATAMINER;
     GRANT CREATE TRIGGER TO DATAMINER;
     
     -- Allow the user to access the shares
     GRANT CREATE ANY DIRECTORY TO DATAMINER;
     ```

   > [!NOTE]
   >
   > - The user account should at least be granted the following rights:
   >   - SELECT
   >   - INSERT
   > - Make sure the user account has access to the database server from the DMA, so that it can reach the offload database.

1. To create the tables, log in as the database user and run the following table creation script found in the `C:\Skyline DataMiner\Tools` directory: *CentralTabledefOracle.sql*.

1. On the database server, create a new local user to use when uploading offload files (e.g., "DataMinerOffload").

   This can be done from *Computer Management \> Local Users and Groups \> Users*.

1. On the database server, create a shared folder and give it an appropriate name (e.g., "DataMinerOffload").

1. Grant the local user you have just created (e.g., "DataMinerOffload") read/write access to the shared folder and make sure that the Oracle service also has read access to this folder.

   To know which user Oracle runs under, check the *Log On As* column in the Windows Services application for the Oracle service. This is typically a user named *OracleServiceXE* or similar.

***

## Allowing ports on Windows Firewall

Once the server has been configured, the next step in setting up the offload database is allowing ports on Windows Firewall. This must be done on every DMA in the DMS, as well as on the server the database is located on.

1. Create an inbound rule:

   1. In the Windows Firewall, open the advanced security settings.

   1. In the *Inbound rules* section, click *New rule*.

   1. Select the rule type *Port* and click *Next*.

   1. Select *TCP*.

   1. Select *Specific local ports*, specify the port, and then click *Next*:

      - For MySQL: 3306

      - For MSSQL: 1433

      - For Oracle: 1521

   1. Select *Allow the connection* and click *Next*.

   1. In response to *When does this rule apply*, select all the options and click *Next*.

   1. Give the rule a name and description and click *Finish*.

1. Create an outbound rule:

   1. In the advanced security settings, open the Windows Firewall.

   1. In the *Outbound rules* section, click *New rule*.

   1. Proceed in the same way as to create an inbound rule (see above).

## DMA configuration

The final step is the configuration of the DMS.

### [For MySQL](#tab/tabid-1)

In Cube, configure the offload or "central" database settings for each DMA in the DMS:

1. Go to *System Center \>* *Database \> Offload*.

1. In the *Type* dropdown box, select *Database*.

1. Set the type of database to *MySQL*.

1. Fill in the following fields:

   - **DB**: The name of the database you created, i.e., SLDMSDB.

   - **DB server**: The IP address of the offload database.

   - **DSN**: "SkySQL"

   - **Connection string**: If a port needs to be specified, specify it here (e.g., *PORT=3306*).

   - **User**: The user account you created to connect to the database.

   - **Password**: The password corresponding with the user account.

1. In the *Offloads* section, select the tables you want to offload, and specify the remote table name.

1. Optionally, if you have selected *Trend data*, specify further details for the offload. For more information, see [Configuring data offloads](xref:Configuring_data_offloads).

### [For MSSQL](#tab/tabid-2)

1. On every DMA in the DMS, share the `C:\Skyline DataMiner\System Cache\Offload` folder:

   1. Go the folder `C:\Skyline DataMiner\System Cache` folder and open the properties of the *Offload* folder.

   1. In the *Sharing* tab, click *Share*.

   1. In the dropdown list, select *Everyone*. If this option is not listed, click *Find people* to add it.

      This is necessary because the folder has to be freely accessible, as no user credentials are passed in the query that retrieves the data.

   1. Click the *Share* button.

   > [!NOTE]
   > It is important that "Everyone" has read/write permissions. Otherwise, the DMA will not be able to store data in the CSV files.

1. Activate TCP/IP:

   1. Open the SQL Server Configuration Manager and go to the SQL Server Network Configuration.

   1. Click *Protocols for MSSQLSERVER*.

   1. In the panel on the right, right-click *TCP/IP* and select *Enable*.

   1. Double-click *TCP/IP* to open its properties, and select *IP Addresses* at the top.

   1. Scroll down, remove the value for *TCP Dynamic Ports*, and fill in *1433* for *TCP Port*.

   1. Click *OK* to save and close the properties.

   1. In the panel on the left, go to the SQL Server Services, right-click SQL Server (MSSQLSERVER) and select *Restart*.

   1. Close the SQL Server Configuration Manager.

1. In Cube, configure the offload or "central" database settings for each DMA in the DMS.

   1. Go to *System Center \>* *Database \> Offload*.

   1. In the *Type* dropdown box, select *Database*.

   1. Set the type of database to *MSSQL*.

   1. Fill in the following fields:

      - **DB**: The name of the database you created, i.e., SLDMSDB.

      - **DB server**: The network location of the offload database. This can be an IP address and a port, separated by a comma, e.g., "10.10.18.1,1433".

      - **DSN**: "SkySQL"

      - **User**: The user account you created to connect to the database.

      - **Password**: The password corresponding with the user account.

   1. In the *Offloads* section, select the tables you want to offload, and specify the remote table name.

   1. Optionally, if you have selected *Trend data*, specify further details for the offload. For more information, see [Configuring data offloads](xref:Configuring_data_offloads).

### [For Oracle](#tab/tabid-3)

1. Check the file *tnsnames.ora* on the database server to see the configuration of XE.

   You can locate the file by searching for it using `dir tnsnames.ora /s` from the root folder. Ignore sample files.

1. In Cube, go to *System Center \>* *Database \> Offload*.

1. In the *Type* dropdown box, select *Database*.

1. Set the type of database to *Oracle*.

1. Fill in the information from the ora file, e.g., `(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = XX.XX.XX.X)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = XE)))`.

1. Fill in the *User* and *Password* fields with the Oracle database username and password.

   > [!NOTE]
   > Alternatively, you can also use a connection string, e.g., `Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=hostaddress)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=XE)));User Id=user;Password= password`.

1. In the *Offloads* section, select the tables you want to offload, and specify the remote table name.

1. Optionally, if you have selected *Trend data*, specify further details for the offload. For more information, see [Configuring data offloads](xref:Configuring_data_offloads).

1. Stop DataMiner.

1. Update **DB.xml** to specify the `RemoteFileShare` tag with the information on how to reach the file share on the server. See [Configuring data offloads to an Oracle database](xref:DB_xml#configuring-data-offloads-to-an-oracle-database).

1. Restart DataMiner.

***

> [!NOTE]
>
> - If an offload to the offload database fails, an alarm will be generated in DataMiner. As soon as offloading works again, the alarm is cleared.
> - If the offload fails for a specific offload file, this file is moved to a failure folder and an error is logged.
> - The offload database settings can also be found in the file *DB.xml*. For more information, see [DB.xml](xref:DB_xml#dbxml).

## Automatic creation and verification of the offload database

When you install or upgrade a DataMiner Agent using an upgrade package, the offload database is created automatically.

Also, when you upgrade a DataMiner Agent using an upgrade package, the offload database is automatically verified (and altered if necessary).

> [!NOTE]
> This only applies to databases of type "MySQL" and "Microsoft SQL Server". Oracle databases have to be created manually.
