---
uid: MaintenanceSettings.RecycleBinSize
---

# RecycleBinSize element

Specifies the maximum size (in MB) of the DataMiner recycle bin.

## Content Type

integer

## Parents

[MaintenanceSettings](xref:MaintenanceSettings)

## Remarks

From DataMiner 10.5.5/10.6.0 onwards<!--RN 40565-->, the system checks every 7 minutes whether storage limits have been exceeded. If the system detects a breach, it performs a cleanup on the recycle bin to restore the storage within acceptable limits. The cleanup continues until both of the following conditions are met:

- The folder size is below the set limit (default: 100 MB).
- The number of files is below the set limit (default: 1000).

If either of these conditions is breached, the system will continue to clean up until the folder size is within the configured limit and the number of files is reduced to 80% of whichever number is lower: the maximum allowed number of files or the current number of files at the time of cleanup.

Examples:

- In a system with a limit of maximum 1000 files, there are 1010 files, so the file limit is exceeded, but the folder size is still within the limit. In this case, The system will clean up until only 80% of the maximum allowed number of files remain (i.e. 80% of 1000 = 800 files). Since 210 files are deleted, the folder size will automatically decrease as well.

- In a system with a limit of maximum 1000 files, there are 600 files, but a large file has caused the folder size to exceed the limit (i.e. 105 MB while the limit is 100 MB). In this case, the system will clean up until only 80% of the current number of files remain (i.e. 80% of 600 = 480 files). If necessary, the system will continue the cleanup process until the folder size is within the configured size limit of 100 MB.

This cleanup occurs for the first time two minutes after DataMiner startup. Prior to DataMiner 10.5.5/10.6.0, the recycle bin is cleaned to the maximum size and number of files every hour.

> [!NOTE]
>
> - Whatever the maximum size specified in this tag, the maximum number of files in the recycle bin is limited to 5000.
> - The default recycle bin size is 100 MB.
> - From DataMiner 10.5.5/10.6.0 onwards<!--RN 40565-->, if the recycle bin size is set to 0 MB or an invalid size, it will revert to the default value of 100 MB.
