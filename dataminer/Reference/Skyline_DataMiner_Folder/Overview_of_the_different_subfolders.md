---
uid: Overview_of_the_different_subfolders
---

# Overview of the different subfolders

| Subdirectory | Contents | Synchronized? |
|--|--|--|
| Backup | Backup settings, backup DLLs, backed-up data. | Partially |
| Database | Database-related configuration files. See [Database](xref:Database). | Partially |
| Documents | Documents added to the DataMiner Agent. | Yes |
| Elements | Element data (one subdirectory per element). See [Elements](xref:Elements1#elements). | No |
| Files | EXEs, DLLs, configuration files, etc. | No |
| Filters | Filters. | Yes |
| Icons | Custom icons. See [Icons](xref:Icons). | No |
| Logging | Log files. | No |
| MIBs | DataMiner MIBs. | No |
| Mobile Gateway | Configuration files for the Mobile Gateway. | No |
| ProtocolFunctionManager | Advanced SRM configuration. See [Advanced SRM settings](xref:Function_resource_settings) | Yes |
| Protocols | A subdirectory for every protocol installed on the DMA.<br> Each of these protocol subdirectories contain a subdirectory for every version of that protocol. | Yes |
| ProtocolScripts | External scripts, DLLs, and compiled QActions. | No |
| Recycle Bin | Backup of changed data. See [Recycle bin](xref:Recycle_bin). | No |
| Redundancy | Redundancy group configuration. | No |
| Scripts | Automation scripts. | Yes |
| Services | Services. | See note below. |
| Simulations | Simulation files. | No |
| Sounds | Custom alert sounds. See [Configuring a custom alert sound for an alarm tab](xref:ConfiguringACustomAlertSoundForAnAlarmTab). | Yes |
| Spectrum Alarm Recordings | Alarm records of spectrum elements. | No |
| System Cache | See [System Cache](xref:System_Cache). | No |
| Tools | Tools (StandaloneUpgrade, .etc.). | No |
| Upgrades | Information concerning the last upgrade. | No |
| Users | Stored user information. See [ClientSettings.json](xref:ClientSettings_json#clientsettingsjson). | Yes |
| Webpages | All webpages of the DataMiner client applications. | Only the *Public* subfolder (as from DataMiner 10.5.10/10.6.0<!-- RN 43458 -->) |

> [!NOTE]
>
> - Files marked as "synchronized" in the rightmost column are synchronized among all DMAs in the cluster every day at midnight (00:00). Therefore, it is of great importance that the time settings of all DMAs in the cluster are synchronized as well. For more information, see [How do I synchronize time settings within a DMS?](xref:General_configuration#how-do-i-synchronize-time-settings-within-a-dms)
> - The *Services* folder contains the services hosted on the DataMiner Agent. Services hosted on other DMAs are synchronized with subfolders of the folder `C:\Skyline DataMiner\RemoteServices`. Each of these subfolders has the DMA ID of the DMA it is synchronized with.
