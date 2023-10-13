---
uid: Backing_up_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility
---

# Backing up a DataMiner Agent using DataMiner Taskbar Utility

1. In the Windows taskbar, right-click the DataMiner Taskbar Utility icon and click *Maintenance \> Backup*.

1. In the *Backup* dialog box, select the type of backup you want to take.

   - **Full Backup**: Backup containing all data necessary to restore the entire DataMiner Agent (default).
   - **Full Backup without Database**: Similar to the full backup, but does not include the database. If you are using [STaaS](xref:STaaS), you can choose this option, as you do not have a self-hosted database in that case.
   - **Configuration Backup**: Backup containing all data necessary to restore the configuration of the DataMiner Agent. This also contains parameter values saved in the database, but not alarm or trending data. This backup option does not include DataMiner Files and Logging.
   - **Configuration Backup without Database**: Similar to the configuration backup, but does not include any information from the database. If you are using [STaaS](xref:STaaS), you can choose this option, as you do not have a self-hosted database in that case.
   - **Visual Configuration Backup**: Backup containing all protocols (including Visio files, WFMs, and the production protocol), all Visio files linked to views, and the contents of the folder *C:\\Skyline DataMiner\\Webpages*.

1. Click *Create*.

> [!NOTE]
> By default, backup files are placed in *C:\\Skyline DataMiner Backups\\*. If you want to specify another backup folder, right-click the DataMiner Taskbar Utility icon, click *Options* and specify a different folder in the *General* tab. From DataMiner 10.3.11/10.3.0 [CU8]/10.2.0 [CU20] onwards<!-- RN 37143 -->, the backups for each DataMiner Agent in the DMS will be stored in a dedicated subfolder of this folder. The subfolder will have the DMA ID as its name.

> [!TIP]
> See also:
> [DataMiner Taskbar Utility](xref:DataMiner_Taskbar_Utility)
