---
uid: UnmaskAlarm
---

# UnmaskAlarm

Use this method to unmask an alarm.

> [!NOTE]
> From DataMiner 10.6.0/10.5.1 onwards, when Swarming is enabled, use the [UnmaskAlarmV2](xref:UnmaskAlarmV2) method instead.

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                               |
| alarmID    | Integer | The alarm ID.                                         |
| comment    | String  | Extra information.                                    |

## Output

None.
