---
uid: MaintenanceSettings.WatchDog.ProcessMonitor.HighDumps
---

# HighDumps element

Configures how long high memory dumps will be kept.

## Parents

[ProcessMonitor](xref:MaintenanceSettings.WatchDog.ProcessMonitor)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [maxDaysToKeep](xref:MaintenanceSettings.WatchDog.ProcessMonitor.HighDumps-maxDaysToKeep) | anySimpleType |  | Specifies the maximum number of days a high memory dump will be kept. Default: 30. |
| [maxToKeep](xref:MaintenanceSettings.WatchDog.ProcessMonitor.HighDumps-maxToKeep) | anySimpleType |  | Specifies the maximum number of high memory dumps kept. Default: 10. |
| [minToKeep](xref:MaintenanceSettings.WatchDog.ProcessMonitor.HighDumps-minToKeep) | anySimpleType |  | Specifies the minimum number of high memory dumps kept. Default: 0. |
