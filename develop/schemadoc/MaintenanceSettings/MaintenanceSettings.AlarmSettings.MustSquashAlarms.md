---
uid: MaintenanceSettings.AlarmSettings.MustSquashAlarms
---

# MustSquashAlarms element

Enables (true) or disables (false) alarm consolidation by default. If this is enabled, consecutive alarm events without a severity change will be combined into a consolidated event in the DataMiner client software. This may be useful to reduce the load on DataMiner Cube and on the SLNet process.

## Content Type

boolean

## Parents

[AlarmSettings](xref:MaintenanceSettings.AlarmSettings)

## Remarks

The following types of alarm events will not be combined in a consolidated alarm event:

- Escalated
- Dropped
- New Alarm
- Cleared
- Dropped From Critical
- Dropped From Major
- Dropped From Minor
- Dropped From Warning
- Escalated From Warning
- Escalated From Minor
- Escalated From Major
- Flipped

> [!TIP]
> See also: [Alarm trees](xref:Alarm_trees)
