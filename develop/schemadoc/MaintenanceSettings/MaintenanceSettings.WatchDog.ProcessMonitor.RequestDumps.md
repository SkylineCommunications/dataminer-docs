---
uid: MaintenanceSettings.WatchDog.ProcessMonitor.RequestDumps
---

# RequestDumps element

Configures how long manually requested memory dumps will be kept.

## Parents

[ProcessMonitor](xref:MaintenanceSettings.WatchDog.ProcessMonitor)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [maxDaysToKeep](xref:MaintenanceSettings.WatchDog.ProcessMonitor.RequestDumps-maxDaysToKeep) | anySimpleType |  | Specifies the maximum number of days a manual memory dump will be kept. Default: 7. |
| [maxToKeep](xref:MaintenanceSettings.WatchDog.ProcessMonitor.RequestDumps-maxToKeep) | anySimpleType |  | Specifies the maximum number of manual memory dumps kept. Default: 10. |
| [minToKeep](xref:MaintenanceSettings.WatchDog.ProcessMonitor.RequestDumps-minToKeep) | anySimpleType |  | Specifies the minimum number of manual memory dumps kept. Default: 0. |
