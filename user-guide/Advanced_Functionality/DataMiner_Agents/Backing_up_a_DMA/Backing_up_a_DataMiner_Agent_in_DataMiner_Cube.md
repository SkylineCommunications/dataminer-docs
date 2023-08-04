---
uid: Backing_up_a_DataMiner_Agent_in_DataMiner_Cube
---

# Backing up a DataMiner Agent in DataMiner Cube

In the *System Center* module, you can configure automatic backups that will run at regular intervals, and execute an immediate backup when necessary.

## Configuring the DataMiner backups

The following steps can be taken to configure the backups for a DMA:

1. Go to *Apps* > *System Center*.

1. In System Center, select the *Backup* tab.

1. In the *General* tab, under *Location*, optionally configure local or network path(s) where the backups should also be stored.

   - If you select the *Local paths* option, all Agents in the *Local paths* list will automatically be selected, but you can clear the selection for some Agents if necessary. For the selected Agents, the backup package will be placed both in the default local folder *C:\\Skyline DataMiner\\Backup* and in the folder specified in the *Local path* box (on the same Agent).

   - If you select the *Store the backups on a network path* option, you can either use one network path for all DMAs, or a different network path for each DMA.

     If *Use a different network path for each Agent* is selected, you can select for which Agents this applies. For the selected Agents, the backup package will be placed both in the default local folder *C:\\Skyline DataMiner\\Backup* and in the folder specified in the *Network path* box.
     
     > [!NOTE]
     > Only SMB file shares are supported for network backups. It is not possible to back up to e.g. (S)FTP shares.

1. In the *General* tab, under *Policy*, enter the number of backups that should be kept.

1. In case the system uses an indexing (i.e. Elastic) database, in the *Indexing Engine Location* section of the *General* tab, the backup path can be modified if necessary.

   > [!NOTE]
   > For more information on Elasticsearch backups, see [Configuring Elasticsearch backups](xref:Configuring_Elasticsearch_backups).

1. In the *Schedule* tab, select when the backup should be executed: monthly, weekly, daily, or only when it is manually initiated.

1. In the *Content* tab, determine the backup type:

   - If you select *Use predefined backup*, indicate the type of backup in the drop-down list.

     - *Full Backup*: Backup containing all data necessary to restore the entire DataMiner Agent (default).

     - *Full Backup without Database*: Similar to the full backup, but does not include the database.

     - *Configuration Backup*: Backup containing all data necessary to restore the configuration of the DataMiner Agent. This also contains parameter values saved in the database, but not alarm or trending data.

       > [!NOTE]
       > The configuration backup does not include DataMiner Files and Logging.

     - *Configuration Backup without Database*: Similar to the configuration backup, but does not include any information from the database.

     - *Visual Configuration Backup*: Backup containing all protocols (including Visio files, WFMs, and the production protocol), all Visio files linked to views, and the contents of the folder *C:\\Skyline DataMiner\\Webpages*.

   - If you select *Use custom backup*, in the table below, select what is to be included in the backup.

     > [!NOTE]
     >
     > - In case an MSSQL general database is used, in the *Options* section, an extra option is available that allows you to back up the transaction log as well. This option can be of use in order to allow MSSQL to shrink the log file. However, note that MSSQL is no longer supported as the general database as from DataMiner 10.3.0.
     > - While changes are being made to a backup configuration, no backup can be taken.

1. Click the *Save* button to save the settings.

> [!NOTE]
> If during a backup operation DataMiner fails to take a backup of the general database, an information event will be generated.

## Taking an instant backup

To take an immediate backup of a DMA:

1. Go to *Apps* > *System Center*.

1. In System Center, select the *Backup* tab.

1. Check whether the backup configuration is correct, and adjust it if necessary. (See above.)

1. Click the *Execute backup* button.

1. Select the DMAs to back up, and click *Start backup*.
