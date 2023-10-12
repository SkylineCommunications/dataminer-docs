---
uid: Activating_one_file_per_table_for_an_existing_MySQL_database
---

# Activating one file per table for an existing MySQL database

When you set up the general MySQL database of a new DMA, you have to activate the *One file per table* option so that each database table is stored into a separate data file. If you notice that the *One file per table* option of an existing DMA database has not been activated, you cannot simply activate it. In short, you should export the data, then activate the *One file per table* option and import the data back into the altered database.

1. Stop DataMiner.

1. Open a command prompt window, and enter the following commands:

   ```txt
   CD C:\Program Files\Mysql\MySQL Server 5.1\bin Mysqldump –u root sldmadb > c:\temp\sldmadb.sql
   ```

1. Open MySQL Administrator, and do the following:

   1. Go to *Startup Variables*.

   1. In the *InnoDB Parameters* tab, go to the *Datafiles* section.

   1. Select the option *One File per Table*.

   1. Click *Apply* changes.

1. Stop the MySQL service.

1. Go to the MySQL data directory, and remove the following files and directories:

   - ibdata1

   - ib_logfile0

   - ib_logfile1

   - all files with extension ”.err”

   - all files with extension ”.pid”

   - the sldmadb directory (if it exists)

1. Start the MySQL service.

   > [!NOTE]
   > ibdata and the associated log files will automatically be recreated.

1. Open a command prompt window, and enter the following commands:

   ```txt
   CD C:\Program Files\Mysql\MySQL Server 5.1\bin Mysql -u root -e "create database sldmadb; use sldmadb; source c:/temp/sldmadb.sql;"
   ```

   Data migration will now start.

1. When data migration has finished, start DataMiner, and verify the trending data.
