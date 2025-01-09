---
uid: MaskAlarm
---

# MaskAlarm

Use this method to mask an alarm for a certain period of time.

> [!NOTE]
> From DataMiner 10.6.0/10.5.1 onwards, when Swarming is enabled, use the [MaskAlarmV2](xref:MaskAlarmV2) method instead.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| alarmID | Integer | The alarm ID. |
| clearInterval | Integer | The period of time (in seconds) during which the alarm will be masked.<br>Set to -1 if the alarm has to be masked until clearance. |
| comment | String | Extra information. |

## Output

None.
