---
uid: Restoring_the_DMA_configuration_only
---

# Restoring the DMA configuration only

If you do not use the Taskbar Utility to restore the DMA, you can restore the DMA configuration manually by copying the `C:\Skyline DataMiner\` directory from one server to another.

1. Copy the entire `C:\Skyline DataMiner\` directory from the original server to the destination server.

   Make sure that all existing files and directories are overwritten.

1. In the `C:\Skyline DataMiner\` directory, delete *DMS.xml*.

> [!NOTE]
> If you are using [STaaS](xref:STaaS), there is no need to restore the database. If you want to restore your DataMiner Agent on a new (virtual) machine, contact <support@dataminer.services> to make sure your new setup is connected correctly.
