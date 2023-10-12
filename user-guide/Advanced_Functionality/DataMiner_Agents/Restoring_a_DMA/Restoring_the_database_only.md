---
uid: Restoring_the_database_only
---

# Restoring the database only

If you do not use the Taskbar Utility to restore a DMA, there are two ways you can restore the DMA database:

- by restoring the MySQL database dump, or

- by manually copying the data files.

## Restoring the database dump

1. If it is not running yet, start the MySQL service.

1. Navigate to the *C:\\Skyline DataMiner\\Backup\\* directory:

   - To perform a full database restore, double-click `{5B8F34AF-1656-4c02-94EE-CF028054602D}.bat`.

   - To restore only the element configuration data (if the backup was saved with the *Configuration backup* setting), double-click `{ELEMENTDATA-1656-4c02-94EE-CF028054602D}.bat`.

The restore operation, displayed in a command window, can take up to several hours depending on the size of the database dump and depending on the performance of the hard disks. Unfortunately, there is no progress indication, but it is possible to watch the growth rate of the *SLDMADB* directory. The ultimate size of that directory will be about the same as the size of the dump file located next to the batch file you double-clicked.

> [!NOTE]
> If the restore operation does not start, then open the batch file in Microsoft Notepad, and check the location of MySQL. Depending on the MySQL version, the location should be either *C:\\MySQL\\bin\\* or *C:\\Program Files\\MySQL\\MySQL Server 5.0\\bin\\*.

## Copying the data files manually

When both the original and the destination server run the exact same version of MySQL, you can restore the database simply by copying the data files.

1. Make sure that both the original and the destination server run the exact same version of MySQL.

2. Make sure that the MySQL service is stopped.

3. Copy all files from the *SLDMADB* directory of the original server to that same directory of the destination server.

    Depending on the MySQL version, this directory will be located in *C:\\MySQL\\Data\\* or in *C:\\Program Files\\MySQL\\MySQL Server X.X\\data*.

4. Start the MySQL service.
