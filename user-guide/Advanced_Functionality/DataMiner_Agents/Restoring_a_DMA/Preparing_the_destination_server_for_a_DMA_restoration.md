---
uid: Preparing_the_destination_server_for_a_DMA_restoration
---

# Preparing the destination server for a DMA restoration

Regardless of whether you are restoring the backup to the DMA it was taken from or to a different DMA, you must make sure that the server is clean and ready for the installation.

To prepare the destination server, there are several possibilities:

- Install a blank, fully functional DataMiner Agent, as described in the DataMiner Installation Guide.

- Clear the configuration of an existing DMA using the [Factory reset tool](xref:Factory_reset_tool). This is highly recommended over manually clearing the configuration; however, it is only possible if the DMA is using DataMiner 10.0.12 or higher.

- Manually clear the configuration of an existing DMA:

  1. If necessary, take a backup of the existing configuration.

  1. Go to the folder *C:\\Skyline DataMiner\\Tools* and run the *DataMiner Stop DataMiner And SLNet.bat* file. This will stop the DataMiner software.

  1. From the *C:\\Skyline DataMiner\\Backup* directory, delete all content EXCEPT *TakeBackup.exe*, *BackupSettings.xml* and all *.dll* files. If necessary, copy existing backups to another location before deleting them.

  1. From the *C:\\Skyline DataMiner\\Webpages\\Pictures* directory, delete all content EXCEPT the four files of which the name starts with *DMSPicViewer*.

  1. From the *C:\\Skyline DataMiner\\Webpages\\Reports\\templates* directory, delete all report templates. In other words, delete all content EXCEPT the *Template.inc.asp* file and the *styles* subdirectory.

  1. Delete all content from the following directories:

     - Skyline DataMiner\\Correlation

     - Skyline DataMiner\\Documents

     - Skyline DataMiner\\Elements

     - Skyline DataMiner\\Logging

     - Skyline DataMiner\\Protocols

     - Skyline DataMiner\\Recycle Bin

     - Skyline DataMiner\\Redundancy

     - Skyline DataMiner\\Scripts

     - Skyline DataMiner\\Services

     - Skyline DataMiner\\Spectrum Alarm Recordings

     - Skyline DataMiner\\System Cache

     - Skyline DataMiner\\Users

     - Skyline DataMiner\\Views

     - Skyline DataMiner\\Webpages\\Annotations\\DMS Images

     - Skyline DataMiner\\Webpages\\Annotations\\Elements

     - Skyline DataMiner\\Webpages\\Annotations\\Views

     - Skyline DataMiner\\Webpages\\Dashboards\\db

  1. For a DMA using a MySQL database:

     1. Open the MySQL command prompt, and enter the following SQL statement:

        ```txt
        drop schema SLDMADB;
        ```

     1. Stop the MySQL service.

     1. Delete all content from the SLDMADB directory. Depending on the MySQL version, this will be:

        - *C:\\MySQL\\Data\\SLDMADB*, or

        - *C:\\Program Files\\MySQL\\MySQL Server 5.0\\data\\SLDMADB*

     Alternatively, for a DMA using a Cassandra database:

     1. Open DevCenter, by going to *C:\\Program Files\\Cassandra\\DevCenter\\Run DevCenter.lnk*.

     1. In the *Connections* pane, click the icon to create a new connection.

     1. In the *New Connection* window, insert the Agent IP in the *Contact hosts* box and click *Add*.

     1. Click *Next* to go to the next step of the wizard.

     1. In both the *Login* and the *Password* box, insert *root*, and then click *Finish*.

     1. In the *Schema* pane of DevCenter, right-click *SLDMADB* and select *Drop Keyspace*.

     1. Open Windows Task Manager and stop the Cassandra service.

     1. Delete the content of the folder *D:\\ProgramData\\Cassandra\\SLDMADB*.

  1. Delete the Windows user accounts on the server that have a corresponding DataMiner account.

  1. In the *C:\\Skyline DataMiner* folder, replace the content of the file *Views.xml* with the following content:

     ```xml
     <Views xmlns="http://www.skyline.be/config/views"/>
     ```

  1. In the *C:\\Skyline DataMiner* folder, clear the content of the *Security.xml* file. In addition, we recommend that you also remove the DataMiner users in Windows (by running compmgmt.msc), as DataMiner will not remove them.

  1. Remove the file *C:\\Skyline DataMiner\\files\\SyncInfo\\{DO_NOT_REMOVE_68EE4388-7EF6-4cb4-B38F-5E0045175340}.xml*.

  1. Start DataMiner. During startup, the necessary database tables will be created.

> [!NOTE]
> - The destination DataMiner Agent must run exactly the same DataMiner software version as the original server. If it does not, perform either a software upgrade or a software downgrade to make sure the version is the same.
> - The destination server must have enough resources (CPU, memory, hard disk performance, etc.) to be able to handle the DataMiner configuration that you intend to restore on that server.
> - If you intend to migrate to another server while the original DMA stays online, take care to avoid an IP conflict:
>     - Either keep the destination server offline as long as the original DMA is online, or
>     - Make sure that the destination server has a different IP address and computer name.
>
