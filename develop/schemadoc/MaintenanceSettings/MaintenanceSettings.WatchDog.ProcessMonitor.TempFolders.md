---
uid: MaintenanceSettings.WatchDog.ProcessMonitor.TempFolders
---

# TempFolders element

Configures how long a temporary folder (incomplete dump) will be kept.

## Parents

[ProcessMonitor](xref:MaintenanceSettings.WatchDog.ProcessMonitor)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [maxDaysToKeep](xref:MaintenanceSettings.WatchDog.ProcessMonitor.TempFolders-maxDaysToKeep) | anySimpleType |  | Specifies the maximum number of days a temporary folder (incomplete dump) will be kept. Default: 7. |
| [maxToKeep](xref:MaintenanceSettings.WatchDog.ProcessMonitor.TempFolders-maxToKeep) | anySimpleType |  | Specifies the maximum number of temporary folders (incomplete dumps) kept. Default: 5. |
| [minToKeep](xref:MaintenanceSettings.WatchDog.ProcessMonitor.TempFolders-minToKeep) | anySimpleType |  | Specifies the minimum number of temporary folders (incomplete dumps) kept. Default: 0. |
