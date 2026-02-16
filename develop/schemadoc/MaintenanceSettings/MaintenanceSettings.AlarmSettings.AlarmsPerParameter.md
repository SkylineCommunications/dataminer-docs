---
uid: MaintenanceSettings.AlarmSettings.AlarmsPerParameter
---

# AlarmsPerParameter element

Specifies the maximum number of alarms that can be included in an alarm tree.

## Type

integer

## Content Type

integer

## Parents

[AlarmSettings](xref:MaintenanceSettings.AlarmSettings)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [client](xref:MaintenanceSettings.AlarmSettings.AlarmsPerParameter-client) | integer |  | Specifies how many alarms in an alarm tree are saved in the Cube cache. This determines how many alarms are shown in Cube when you view the alarm tree in a new tab, when you reconnect to Cube, or when you restart the element. |
| [recurring](xref:MaintenanceSettings.AlarmSettings.AlarmsPerParameter-recurring) | string |  | Obsolete. No longer used as of DataMiner 10.5.0 [CU13]/10.6.0 [CU1]/10.6.4.<!-- 44565 --> In earlier DataMiner versions, this determines whether and when a notice will be generated if the number of alarms in an alarm tree exceeds the AlarmsPerParameter setting. From DataMiner 10.5.0 [CU13]/10.6.0 [CU1]/10.6.4 onwards, these notices are longer generated. |

## Remarks

If there are more alarms in an alarm tree, by default a notice will be displayed in the Alarm Console.

> [!NOTE]
>
> - SLNet limits the alarm trees in the cache and in history queries based on this tag. If no value is specified in this tag, SLNet uses a default of 20. In addition, because in old DataMiner versions the default was 100, if the value in this tag is 100, SLNet will read it as 20 instead.
> - SLDataMiner is responsible for generating notices if there are too many alarms in an alarm tree. If no value is specified in this tag, SLDataMiner uses a default of 100.

## Example

```xml
<AlarmsPerParameter recurring="TRUE" client="30">60</AlarmsPerParameter>
```
