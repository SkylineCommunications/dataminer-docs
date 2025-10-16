---
uid: Changing_the_maximum_size_of_DataMiner_log_files
---

# Changing the maximum size of DataMiner log files

In System Center, you can change the maximum total size of the log files in your DMS:

1. In DataMiner Cube, go to System Center \> *System Settings \> Logging*.

1. In the box under *Log file size*, specify a different number.

1. Click the *Apply limit* button in the lower-right corner.

> [!NOTE]
>
> - The total size of SLNet log files is not controlled by this setting. See [SLNet.exe.config](xref:SLNet_exe_config).
> - This setting determines the size of the log files for the entire DataMiner System, even though prior to DataMiner 10.2.0 [CU22], 10.3.0 [CU11], 10.4.0 [CU0], and 10.4.2, the description of the setting suggests that only the size of the log files on the current DMA is affected.
> - In *DataMiner.xml*, you can also modify how long log files are stored. See [DayToKeep](xref:DataMiner.Logging.DaysToKeep).
