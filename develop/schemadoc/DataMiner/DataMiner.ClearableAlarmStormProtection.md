---
uid: DataMiner.ClearableAlarmStormProtection
---

# ClearableAlarmStormProtection element

Configures alarm storm protection for clearable alarms.

## Parents

[DataMiner](xref:DataMiner)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [max](xref:DataMiner.ClearableAlarmStormProtection-max) | int |  | Specifies the maximum threshold for the alarm storm mode. If this threshold is crossed, newly generated clearable alarms will be closed instead of clearable.<br>Default: 1000 |
| [min](xref:DataMiner.ClearableAlarmStormProtection-min) | int |  | Specifies the minimum threshold for the alarm storm mode. If the number of clearable alarm trees drops below this number, the alarm storm protection is lifted and newly generated alarms are clearable again.<br>Default: 100 |

> [!NOTE]
> If you change this configuration, you must do so on every DMA in a cluster, as this setting is not automatically synchronized.

> [!TIP]
> See also: [Clearing alarms](xref:Clearing_alarms).
