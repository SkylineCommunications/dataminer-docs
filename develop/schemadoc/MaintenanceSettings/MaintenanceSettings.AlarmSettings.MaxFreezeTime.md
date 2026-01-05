---
uid: MaintenanceSettings.AlarmSettings.MaxFreezeTime
---

# MaxFreezeTime element

Specifies the maximum period of time the Alarm Console can stay frozen (in milliseconds). Default: 60000000 milliseconds (i.e. 1000 minutes)

## Content Type

string

## Parents

[AlarmSettings](xref:MaintenanceSettings.AlarmSettings)

## Remarks

As soon as either MaxFreezeTime or [MaxFreezeAlarms](xref:MaintenanceSettings.AlarmSettings.MaxFreezeAlarms) is reached, the Alarm Console will automatically be unfrozen.
