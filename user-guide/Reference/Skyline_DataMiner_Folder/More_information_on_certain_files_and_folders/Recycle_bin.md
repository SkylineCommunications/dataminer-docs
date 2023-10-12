---
uid: Recycle_bin
---

# Recycle bin

> [!TIP]
> See also:
> [Backup – Using the recycle bin of DataMiner](https://community.dataminer.services/video/backup-using-the-recycle-bin-of-dataminer/) ![Video](~/user-guide/images/video_Duo.png)

The *Recycle Bin* folder contains a number of zip files, one for each configuration change that has been implemented in the system.

The total number of files is limited by the *RecycleBinSize* setting in *MaintenanceSettings.xml*. See [Alphabetical overview of settings](xref:MaintenanceSettings_xml#alphabetical-overview-of-settings).

If an incorrect configuration change is implemented in the system, in some cases, it is possible to use the recycle bin to restore the original configuration.

For example, if a view is renamed or moved in the Surveyor, a zip file will be created containing the *Views.xml* file and a system cache folder with a cause file, which details why the change occurred. It is then possible to restore the *Views.xml* file as follows:

1. Copy the file from the *Recycle Bin* folder back to its original location.

2. Restart the DMA.

3. Force a synchronization of the file in the DMS. See [Forcing synchronization of a file with the DMS](xref:Synchronizing_data_between_DataMiner_Agents#forcing-synchronization-of-a-file-with-the-dms).

> [!NOTE]
> Always be extremely careful when using this functionality, as it can have far-reaching consequences on your DataMiner System.
>
