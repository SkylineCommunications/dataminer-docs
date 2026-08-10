---
uid: Data_synchronization
---

# Data synchronization

Most changes to DataMiner data are instantly automatically synchronized across the cluster. To make sure this also happens in case one or more nodes is not available at the time of the change, a so-called [midnight sync](#midnight-sync) is done at least daily.

In addition to this, you can also trigger a [manual synchronization](#manual-sync).

## Midnight sync

By default, a full cluster synchronization occurs once per day, ensuring all DataMiner Agents are fully aligned. While this typically occurs only once per day at midnight, a different timing and frequency can be configured in MaintenanceSettings.xml if needed (see [MaintenanceSettings.DMSRevision](xref:MaintenanceSettings.DMSRevision)).

> [!IMPORTANT]
> To make sure the synchronization happens correctly, it is of great importance that the time settings of the DMAs are synchronized as well. For more information, see [How do I synchronize time settings within a DMS?](xref:General_configuration#how-do-i-synchronize-time-settings-within-a-dms)

## Files/folders included in the sync

Not all DataMiner files and folders are included in the automatic sync. For details on which files and folders are included, refer to [Overview of the files found in the root folder](xref:Overview_of_the_files_found_in_the_root_folder) and [Overview of the different subfolders](xref:Overview_of_the_different_subfolders), respectively.

## Manually modified files

Manually modifying files on a DMA **does not automatically trigger file synchronization**. DataMiner only synchronizes file changes that are accompanied by a file change notification, for example:

```csharp
SetDataMinerInfoMessage()
{
What = (int)NotifyType.SendDmsFileChange,
IInfo2 = (int)NotifyType.FileChanged,
StrInfo1 = @"C:\Skyline DataMiner\..."
}
```

**Without such a notification**, the modified files are **ignored by both direct synchronization and the midnight sync**. The midnight sync merely acts as a fallback for previously triggered synchronization actions that could not be completed because one or more DMAs were unavailable.

To synchronize a manually modified file, you will need to [trigger a manual sync of the file](xref:Synchronizing_data_between_DataMiner_Agents#forcing-synchronization-of-a-file-with-the-cluster).

## Manual sync

In Cube's System Center, you can manually trigger a sync of a specific node with the cluster, of all nodes within the cluster, of a specific file within the cluster, or of all Visio files in the cluster. For details, refer to [Synchronizing data between nodes](xref:Synchronizing_data_between_DataMiner_Agents).
