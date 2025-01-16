---
uid: AddCommentToAlarm
---

# AddCommentToAlarm

Use this method to add a comment to an alarm.

Deprecated since DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11.<!-- RN 40240 -->. From DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards, use the [AddCommentToAlarmV2](xref:AddCommentToAlarmV2) method instead.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                              |
| alarmID    | Integer | The alarm ID.                                        |
| comment    | String  | The comment to be added to the alarm.                |

## Output

None.
