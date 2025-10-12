---
uid: MaintenanceSettings.WatchDog.ProcessMonitor
---

# ProcessMonitor element

Configures settings related to the process monitor.

## Parents

[WatchDog](xref:MaintenanceSettings.WatchDog)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [maxAttachmentSize](xref:MaintenanceSettings.WatchDog.ProcessMonitor-maxAttachmentSize) | integer |  | Specifies the maximum size of the attachments in MB. |
| [maxInHour](xref:MaintenanceSettings.WatchDog.ProcessMonitor-maxInHour) | integer |  | Specifies the maximum number of allowed automatic restarts per hour. |
| [maxProcess](xref:MaintenanceSettings.WatchDog.ProcessMonitor-maxProcess) | integer |  | Defines the expected minimum number of monitored processes. If the number of terminated processes exceeds this value, the system interprets it as a critical failure and may initiate a full restart or halt further automatic restarts to prevent unstable operation. |
| [maxTimeout](xref:MaintenanceSettings.WatchDog.ProcessMonitor-maxTimeout) | string |  | When a full DataMiner restart is required because of the disappearance of a critical process, this setting specifies the number of minutes to wait before performing a full DataMiner restart. |
| [passwordOnAttachment](xref:MaintenanceSettings.WatchDog.ProcessMonitor-passwordOnAttachment) | boolean |  | Specifies whether a password is applied on the attachments. |

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| All |  |  |
| &#160;&#160;[HighDumps](xref:MaintenanceSettings.WatchDog.ProcessMonitor.HighDumps) | [0, 1] | Configures how long high memory dumps will be kept. |
| &#160;&#160;[LowDumps](xref:MaintenanceSettings.WatchDog.ProcessMonitor.LowDumps) | [0, 1] | Configures how long low memory dumps will be kept. |
| &#160;&#160;[MaxTotalCrashDumpFolderSizeGb](xref:MaintenanceSettings.WatchDog.ProcessMonitor.MaxTotalCrashDumpFolderSizeGb) | [0, 1] | Specifies the maximum size of the Logging/CrashDump folder. Default: 5. |
| &#160;&#160;[RequestDumps](xref:MaintenanceSettings.WatchDog.ProcessMonitor.RequestDumps) | [0, 1] | Configures how long manually requested memory dumps will be kept. |
| &#160;&#160;[TempFolders](xref:MaintenanceSettings.WatchDog.ProcessMonitor.TempFolders) | [0, 1] | Configures how long a temporary folder (incomplete dump) will be kept. |

## Remarks

> [!NOTE]
>
> - If these tags are not specified, the default values will be used.
> - Customizing how long crashdump packages are kept does not require a DataMiner restart. However, these settings will only be applied once a crash dump package is created.

> [!TIP]
> See also: [SLWatchdog](xref:Configuration_of_DataMiner_processes#slwatchdog)
