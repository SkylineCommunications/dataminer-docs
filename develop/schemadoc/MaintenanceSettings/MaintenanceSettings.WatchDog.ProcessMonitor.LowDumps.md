---
uid: MaintenanceSettings.WatchDog.ProcessMonitor.LowDumps
---

# LowDumps element

Configures how long low memory dumps will be kept.

## Parents

[ProcessMonitor](xref:MaintenanceSettings.WatchDog.ProcessMonitor)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [maxDaysToKeep](xref:MaintenanceSettings.WatchDog.ProcessMonitor.LowDumps-maxDaysToKeep) | anySimpleType |  | Specifies the maximum number of days a low memory dump will be kept. Default: 60. |
| [maxToKeep](xref:MaintenanceSettings.WatchDog.ProcessMonitor.LowDumps-maxToKeep) | anySimpleType |  | Specifies the maximum number of low memory dumps kept. Default: 100. |
| [minToKeep](xref:MaintenanceSettings.WatchDog.ProcessMonitor.LowDumps-minToKeep) | anySimpleType |  | Specifies the minimum number of low memory dumps kept. Default: 0.|
