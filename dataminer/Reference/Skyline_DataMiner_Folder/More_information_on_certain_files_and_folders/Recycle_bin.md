---
uid: Recycle_bin
---

# Recycle bin

The *Recycle Bin* folder contains backup copies of modified configuration files and folders, stored as zip files. Each zip file includes the modified file or folder along with a *Cause.txt* file, which details the reason for the change and its timestamp. These backup copies help you [restore previous configurations](#restoring-a-previous-configuration) if needed.

- From DataMiner 10.5.5/10.6.0 onwards, the contents of `C:\Skyline DataMiner\System Cache\Recyclable` are zipped and moved to `C:\Skyline DataMiner\Recycle Bin` **every 11 minutes**. This process first occurs 3 minutes after DataMiner startup.

  When a configuration change occurs, two scenarios are possible:

  - If the file or folder has not been modified after the most recent move to the *Recycle Bin* folder (which happens every 11 minutes), a new entry is created in `C:\Skyline DataMiner\System Cache\Recyclable` with the name of the changed file or folder.

  - If the file or folder has been modified after the most recent move to the *Recycle Bin* folder, the existing entry in `C:\Skyline DataMiner\System Cache\Recyclable` is not replaced. Instead, the *Cause.txt* file is updated with the new change description and corresponding timestamp.

- Prior to DataMiner 10.5.5/10.6.0, a separate zip file is created **for each configuration change** that is implemented in the system.

The total number of stored zip files is limited by the [*RecycleBinSize* setting](xref:MaintenanceSettings.RecycleBinSize) in *MaintenanceSettings.xml*. From DataMiner 10.5.5/10.6.0 onwards<!--RN 40565-->, if no value is provided, the default limit is 100 MB.

## Restoring a previous configuration

If an incorrect configuration change is implemented in the system, in some cases, it is possible to use the recycle bin to restore the original configuration.

For example, if a view is renamed or moved in the Surveyor, a zip file will be created containing the *Views.xml* file and a cause file, which details why the change occurred. It is then possible to restore the *Views.xml* file as follows:

1. Copy the file from the *Recycle Bin* folder back to its original location.

   > [!NOTE]
   > From DataMiner 10.5.5/10.6.0 onwards<!--RN 40565-->, the files in the *Recycle Bin* folder are only updated every 11 minutes. This means that when you restore the files, they may not contain recent changes.

1. Restart the DMA.

1. Force a synchronization of the file in the DMS. See [Forcing synchronization of a file with the DMS](xref:Synchronizing_data_between_DataMiner_Agents#forcing-synchronization-of-a-file-with-the-dms).

> [!CAUTION]
> Always be extremely careful when using this functionality, as it can have far-reaching consequences on your DataMiner System.
