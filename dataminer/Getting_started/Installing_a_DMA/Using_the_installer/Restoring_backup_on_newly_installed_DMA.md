---
uid: Restoring_backup_on_newly_installed_DMA
---

# Restoring a backup onto a newly installed DataMiner Agent

If you are installing DataMiner to restore a backup coming from another machine because of e.g., a hardware migration or during disaster recovery, after the core DataMiner software has been installed (either via the [DataMiner Installer v10.4](xref:Installing_DM_using_the_DM_installer) or by [using a pre-installed VHD](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk)), instead of clicking *Start* to configure the DataMiner Agent automatically, follow the steps below:

1. Restore the backup in the same way as for a regular DataMiner Agent. See [Restoring a DataMiner Agent using the DataMiner Taskbar Utility](xref:Restoring_a_DMA_using_the_DataMiner_Taskbar_Utility).

1. [Stop the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).

1. Open the `C:\Skyline DataMiner\` folder.

1. Remove all *\*.lic* files, if any.

1. [Start the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).

1. After a short while, a *Request.lic* file should appear in the `C:\Skyline DataMiner\` folder.

1. Contact [dataminer.licensing@skyline.be](mailto:dataminer.licensing@skyline.be) and provide them with the *Request.lic* file.

1. Wait until you receive a *dataminer.lic* file from Skyline.

1. When you have the *dataminer.lic* file, copy it to the `C:\Skyline DataMiner\` folder.

1. [Restart the DMA using the DataMiner Taskbar Utility](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).
