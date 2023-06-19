---
uid: MOP_Restoring_a_single_table_in_a_MySQL_database
---

# Restoring a single table in a MySQL database

The procedure below details how you can restore a single table in a MySQL database used by DataMiner.

## Requirements

- Access to the servers with administrator rights. This requires a connection dedicated completely or partially to this procedure, via VPN or local network.
- In case of data modelling needs, access to a spreadsheet application.
- Access to [MySQL Workbench](xref:MySQL_Workbench).

## Procedure

### Check the requirements

#### Prerequisites

- Remote access to the system.
- Credentials with administrator rights.

#### Steps

1. Connect to the system using the designated VPN or host PC.
1. Make sure you have access to MySQL Workbench.

### Restore the table in MySQL

#### Prerequisites

The previous requirements are met.

#### Steps

1. Check the log information.

   - You can find the MySQL error log in a file with the name of the DMA and the extension *.err* in the MySQL installation folder, e.g. `C:\ProgramData\MySQL\MySQL Server 5.5`.
   - DataMiner logging can be found in the *SLDatagateway*, *SLDBconnection* and *SLDatabase* log files in the folder `C:\Skyline DataMiner\Logging`.

1. Open MySQL Workbench to verify the integrity of the SLDMADB tables. If you need to provide credentials, use `-user root -password (empty)`.
1. Check if the MySQL service is running. If it is not, enforce forced recovery mode by configuring the MySQL configuration file as follows:

   1. Make sure you have a backup copy of your database in case it needs to be recreated.
   1. Go to the MySQL installation folder, e.g. `C:\ProgramData\MySQL\MySQL Server 5.5`.
   1. Open the file *my.ini*, using an application like Notepad, and add the following recovery options:

      ```txt
      [mysqld]
      innodb_force_recovery = 1
      ```

      > [!NOTE]
      > You should only ever set `innodb_force_recovery` to a value greater than 0 in an emergency situation, so that you can start InnoDB and dump your tables. When forcing InnoDB recovery, you should always start with `innodb_force_recovery=1` and only increase the value incrementally, as necessary. For most situations, `innodb_force_recovery = 3` will work. Values of 4 or greater can permanently corrupt data files. Only use an `innodb_force_recovery` setting of 4 or greater on a production server instance after you have successfully tested the setting on a separate physical copy of your database.

1. Once the MySQL service is running, go to *System Center* in DataMiner Cube and check if the missing table is mentioned in the sync status.
1. Log back into the workbench, navigate to SLDMADB and check the table structure and content. If possible, compare with the DMA for an accurate view. For example, in the image below, selecting the *SLEnumvalues* table reveals that the table structure is missing. To confirm this, try querying the data and check if the query fails.

    ![MySQL Workbench example](~/user-guide/images/MOPMySQLRestore1.png)

1. Recreate the missing table.

   - For example, for the *SLEnumvalues* table, you can do so with the following query:

     ```sql
     Drop table if EXISTS `sldmadb`.`slenumvalues`;
     CREATE TABLE `sldmadb`.`slenumvalues` (
       `Id` smallint(6) NOT NULL,
       `Value` varchar(200) NOT NULL,
       PRIMARY KEY (`Id`)
     ) ENGINE=InnoDB DEFAULT CHARSET=latin1$$
     ```

     Consult the structure of the table in the workbench to structure your query correctly.

     ![Table structure example](~/user-guide/images/MOPMySQLRestore2.png)

   - Alternatively, you can use the workbench to create the table:

     ![Create Table option in MySQL Workbench](~/user-guide/images/MOPMySQLRestore3.png)

     ![Table context menu in MySQL Workbench](~/user-guide/images/MOPMySQLRestore4.png)

   - In a Failover setup, another possible alternative is to dump the table and export it from the other Agent. Make sure the corrupt table is deleted (i.e. dropped). Then use MySQL tools to export the table, copy the export file to the other DMA and import it via MySQL workbench). Finally, load the imported table and compare the location in the workbench with the actual location of the database in the file system.

## Time estimate

For most single tables, this procedure should take no more than 30 minutes.
