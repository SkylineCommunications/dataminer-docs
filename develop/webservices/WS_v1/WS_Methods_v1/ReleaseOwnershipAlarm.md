---
uid: ReleaseOwnershipAlarm
---

# ReleaseOwnershipAlarm

Use this method to release ownership of an alarm.

Deprecated since DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11.<!-- RN 40240 -->. From DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards, use the [ReleaseOwnershipAlarmV2](xref:ReleaseOwnershipAlarmV2) method instead.

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                               |
| alarmID    | Integer | The alarm ID.                                         |
| comment    | String  | Extra information.                                    |

## Output

None.
