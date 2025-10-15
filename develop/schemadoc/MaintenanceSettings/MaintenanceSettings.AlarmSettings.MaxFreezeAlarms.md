---
uid: MaintenanceSettings.AlarmSettings.MaxFreezeAlarms
---

# MaxFreezeAlarms element

Specifies the maximum number of alarms that will be kept in the alarm buffer when the Alarm Console is frozen. Default: 1000 alarms

## Content Type

integer

## Parents

[AlarmSettings](xref:MaintenanceSettings.AlarmSettings)

## Remarks

As soon as either [MaxFreezeTime](xref:MaintenanceSettings.AlarmSettings.MaxFreezeTime) or MaxFreezeAlarms is reached, the Alarm Console will automatically be unfrozen.
