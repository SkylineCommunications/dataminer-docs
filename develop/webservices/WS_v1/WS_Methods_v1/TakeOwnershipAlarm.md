---
uid: TakeOwnershipAlarm
---

# TakeOwnershipAlarm

Use this method to take ownership of an alarm.

> [!NOTE]
> From DataMiner 10.6.0/10.5.1 onwards, when Swarming is enabled, use the [TakeOwnershipAlarmV2](xref:TakeOwnershipAlarmV2) method instead.

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                               |
| alarmID    | Integer | The alarm ID.                                         |
| comment    | String  | Extra information.                                    |

## Output

None.
