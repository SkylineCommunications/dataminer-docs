---
uid: MaskAlarm
---

# MaskAlarm

Use this method to mask an alarm for a certain period of time.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID | Integer | The DataMiner Agent ID. |
| AlarmID | Integer | The alarm ID. |
| ClearInterval | Integer | The period of time (in seconds) during which the alarm will be masked. Set to -1 if the alarm has to be masked until clearance. |
| Comment | String | Extra information. |

## Output

None.
