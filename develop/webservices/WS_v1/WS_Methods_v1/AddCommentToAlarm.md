---
uid: AddCommentToAlarm
---

# AddCommentToAlarm

Use this method to add a comment to an alarm.

> [!NOTE]
> From DataMiner 10.6.0/10.5.1 onwards, when Swarming is enabled, use the [AddCommentToAlarmV2](xref:AddCommentToAlarmV2) method instead.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                              |
| alarmID    | Integer | The alarm ID.                                        |
| comment    | String  | The comment to be added to the alarm.                |

## Output

None.
