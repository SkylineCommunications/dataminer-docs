---
uid: TakeOwnershipAlarm
---

# TakeOwnershipAlarm

Use this method to take ownership of an alarm.

Deprecated since DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11.<!-- RN 40240 -->. From DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards, use the [TakeOwnershipAlarmV2](xref:TakeOwnershipAlarmV2) method instead.

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                               |
| alarmID    | Integer | The alarm ID.                                         |
| comment    | String  | Extra information.                                    |

## Output

None.
