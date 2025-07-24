---
uid: SNMP.SnmpManagers.SnmpManager.AlarmStorm
---

# AlarmStorm element

Specifies settings related to alarm storm prevention.

## Parents

[SnmpManager](xref:SNMP.SnmpManagers.SnmpManager)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [alarms](xref:SNMP.SnmpManagers.SnmpManager.AlarmStorm-alarms) | integer |  | Specifies the maximum number of (grouped) alarms to lead to an alarm storm. |
| [rangeAfterStorm](xref:SNMP.SnmpManagers.SnmpManager.AlarmStorm-rangeAfterStorm) | integer |  | Specifies the minimum time range (in s) with no alarms to indicate that the alarm storm has stopped. |
| [rangeStorm](xref:SNMP.SnmpManagers.SnmpManager.AlarmStorm-rangeStorm) | integer |  | Specifies the maximum time range (in s) in which these alarms must be generated. |
| [type](xref:SNMP.SnmpManagers.SnmpManager.AlarmStorm-type) | integer |  | Specifies whether alarms with the same parameter name are grouped. |
