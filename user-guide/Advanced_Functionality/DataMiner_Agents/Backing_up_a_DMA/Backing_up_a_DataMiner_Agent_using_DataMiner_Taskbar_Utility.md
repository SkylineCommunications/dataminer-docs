---
uid: Backing_up_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility
---

# Backing up a DataMiner Agent using DataMiner Taskbar Utility

1. In the Windows taskbar, right-click the DataMiner Taskbar Utility icon and click *Maintenance \> Backup*.

1. In the *Backup* dialog box, select the type of backup you want to take.

    | Backup type                         | Description                                                                                                                                                                                                                                 |
    |---------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Full Backup                           | Backup containing all data necessary to restore the entire DataMiner Agent (default).                                                                                                                                                       |
    | Full Backup without Database          | Similar to the full backup, but does not include the database.                                                                                                                                                                              |
    | Configuration Backup                  | Backup containing all data necessary to restore the configuration of the DataMiner Agent. This also contains parameter values saved in the database, but not alarm or trending data.<br> Note: Does not include DataMiner Files and Logging |
    | Configuration Backup without Database | Similar to the configuration backup, but does not include any information from the database.                                                                                                                                                |
    | Visual Configuration Backup           | Backup containing all protocols (including Visio files, WFMs, and the production protocol), all Visio files linked to views, and the contents of the folder *C:\\Skyline DataMiner\\Webpages*.                   |

1. Click *Create*.

> [!NOTE]
> By default, backup files are placed in *C:\\Skyline DataMiner Backups\\*. If you want to specify another backup folder, right-click the DataMiner Taskbar Utility icon, click *Options* and specify a different folder in the *General* tab.

> [!TIP]
> See also:
> [DataMiner Taskbar Utility](xref:DataMiner_Taskbar_Utility)
