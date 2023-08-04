---
uid: Setting_up_an_offload_database
---

# Setting up an offload database

## Server configuration

The first step in setting up an offload or “central” database is the configuration of the server that will host the offload database.

Depending on the type of database, the procedure is slightly different.

1. Install the database software, which can be:

   - MySQL Server

     > [!NOTE]
     >
     > - For DataMiner versions up to DataMiner 9.6.5, MySQL versions 4.1.1 to 5.7 are supported (using connector version 5.2.7). From DataMiner 9.6.5 onwards, versions up to 8.0 are supported (using connector version 6.9.12).
     > - To use MySQL 8.0, an additional change is needed within the database. You need to set the *local_infile* variable to 1. In previous versions, this was not a default version, but this has changed. To do this in the database, you can use the command `SET GLOBAL local_infile=1;`.
     > - For MySQL, do not activate strict mode (STRICT_TRANS_TABLES) during installation. If you do so, the database offloads will fail.

   - MSSQL Server

     > [!NOTE]
     >
     > - While setting up the installation of MSSQL Server, choose the authentication mode *Mixed Mode*.
     > - To run Microsoft SQL Server 2019, Windows Server 2016 or higher is required.

   - Oracle Database.

1. Create and configure the user account that will be used by the different DMAs to connect to the offload database:

   - MySQL remote user:

     1. Open the user account manager.

     1. Click *Add* and configure the remote user.

     1. Click *Save*.

   - MSSQL remote user:

     1. Open the Microsoft SQL Server Management Studio and connect to the server.

     1. In the *Object Explorer*, right-click the *Login* folder and select *New Login*.

     1. Configure the user in the *Login - New* window and click *OK*.

   - Oracle: use the Oracle Apex web interface to create a user and set up a workspace.

   > [!NOTE]
   >
   > - The user accounts should at least be granted the following rights:
   >     - SELECT
   >     - INSERT
   > - Make sure the user account has access to the database server from the DMA, so that it can reach the offload database.

1. Create a database (e.g. named “sldmsdb”) and tables:

   - In MySQL:

     1. Open MySQL and right-click the MySQL server to create a database

     1. In the right-click menu, select *Make new \> Database*.

     1. Fill in “sldmsdb” as the database name, make sure *Collation* is set to *utf8 - default collation* and click *OK*.

     1. From the *C:\\Skyline DataMiner\\Tools* directory, run the following script to create the tables: *CentralTabledef.txt*.

   > [!NOTE]
   >
   > - Note that the script in *CentralTabledef.txt* will drop any tables in the selected database (causing these to be permanently deleted) and recreate the schema, so it must be used with caution.
   > - Alternatively, you can also use the program SLOffload.exe from the *C:\\Skyline DataMiner\\Tools* directory to do an offload to your new database. However, note that running this program involves a restart of the DMA.

   - In MSSQL:

     1. Open Microsoft SQL Server Management Studio, and connect to the SQL server with the user account you created earlier.

     1. Right-click *Databases* and select *New Database*.

     1. Fill in “SLDMSDB” as *Database name*, and click *OK*.

     1. From the *C:\\Skyline DataMiner\\Tools* directory, run the following script to create the tables: *CentralTableDefSQLServer.sql*.

   - For an Oracle database, run the following table creation script found in the *C:\\Skyline DataMiner\\Tools* directory: *CentralTabledefOracle.sql*.

   > [!TIP]
   > See also: [Automatic creation and verification of the offload database](#automatic-creation-and-verification-of-the-offload-database)

1. For an Oracle Database, create a shared folder on the database server and give it an appropriate name (e.g. “DataMinerOffload”).

   Also grant the following permission to the database user:

   ```txt
   GRANT CREATE ANY DIRECTORY TO [user]
   ```

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

1. For a MSSQL database only, on every DMA in the DMS, share the *C:\\Skyline DataMiner\\System Cache\\Offload* folder:

   1. Go the folder *C:\\Skyline DataMiner\\System Cache* *folder* and open the properties of the *Offload* folder.

   1. In the *Sharing* tab, click *Share*.

   1. In the drop-down list, select *Everyone*. If this option is not listed, click *Find people* to add it.

      This is necessary because the folder has to be freely accessible, as no user credentials are passed in the query that retrieves the data.

   1. Click the *Share* button.

   > [!NOTE]
   > It is important that “Everyone” has read/write permissions. Otherwise, the DMA will not be able to store data in the CSV files.

1. For DMAs using a legacy DataMiner version prior to 9.0.0, if the offload database is an Oracle database, install the Oracle Data Access Component (ODAC). The Oracle Client must be at least version 12.

   Download: [http://www.oracle.com/tecbhnetwork/topics/dotnet/utilsoft-086879.html](http://www.oracle.com/technetwork/topics/dotnet/utilsoft-086879.html)

   > [!NOTE]
   > From DataMiner 9.0.0 onwards, the SLDatabase process uses the managed Oracle Database accessor to connect to an Oracle database, so that additional tools like Oracle Client are no longer needed.

1. For MSSQL only, activate TCP/IP:

   1. Open the SQL Server Configuration Manager and go to the SQL Server Network Configuration.

   1. Click *Protocols for MSSQLSERVER*.

   1. In the panel on the right, right-click *TCP/IP* and select *Enable*.

   1. In the panel on the left, go to the SQL Server Services, right-click SQL Server (MSSQLSERVER) and select *Restart*.

   1. Close the SQL Server Configuration Manager.

1. In Cube, configure the offload or “central” database settings for each DMA in the DMS.

   1. Go to *System Center \>* *Database \> Offload* (from DataMiner 10.0.13 onwards) or *System Center \>* *Database \> Central* (prior to DataMiner 10.0.13).

   1. Prior to DataMiner 10.0.13 only: In the column on the left, select any of the Agents in the DMS. The offload database will always be synced with the entire DMS, so it is irrelevant which Agent is selected.

   1. Prior to DataMiner 10.1.1/10.2.0 only: Select the *Activate this database* checkbox to activate the offload database.

   1. From DataMiner 10.1.1/10.2.0 onwards, in the *Type* drop-down box, select *Database*.

   1. Select the type of database: MySQL, MSSQL or Oracle.

   1. Fill in the following fields:

      - **DB**: The name of the database you created, i.e. SLDMSDB.

      - **DB server**: The network location of the offload database.

        - For an MSSQL database, this can be an IP address and a port, separated by a comma, e.g. “10.10.18.1,1433”.

        - For a MySQL database, only fill in the IP address. If a port needs to be specified, do so in the *Connection string* field (e.g. *PORT=3306*).

      - **DSN**: “SkySQL”

      - **Connection string**: Depending on the type of database, you can fill in this field to connect through a connection string instead. If this field is filled in, it will always take precedence over all other fields.

      - **User**: The user account you created to connect to the database.

      - **Password**: The password corresponding with the user account.

      > [!NOTE]
      > For Oracle, check the file *tnsnames.ora* to see the configuration of XE. If the file has an XE description, in the *DB Server* field, fill in *XE*, otherwise fill in the information from the ora file, e.g. *(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = XX.XX.XX.X)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = XE)))*. Aside from that, you only need to fill in the *User* and *Password* fields with the Oracle database username and password. Alternatively, you can also use a connection string, e.g. *Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=hostaddress)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=XE)));User Id=user;Password= password*.

   1. In the *Offloads* section, select the tables you want to offload, and specify the remote table name.

   1. Optionally, if you have selected *Trend data*, specify further details for the offload. For more information, see [Configuring data offloads](xref:Configuring_data_offloads).

> [!NOTE]
>
> - If an offload to the offload database fails, an alarm will be generated in DataMiner. As soon as offloading works again, the alarm is cleared.
> - If the offload fails for a specific offload file, this file is moved to a failure folder and an error is logged.
> - The offload database settings can also be found in the file *DB.xml*. For more information, see [DB.xml](xref:DB_xml#dbxml).

## Automatic creation and verification of the offload database

When you install or upgrade a DataMiner Agent using an upgrade package, the offload database is created automatically.

Also, when you upgrade a DataMiner Agent using an upgrade package, the offload database is automatically verified (and altered if necessary).

> [!NOTE]
> This only applies to databases of type “MySQL” and “Microsoft SQL Server”. Oracle databases have to be created manually.
