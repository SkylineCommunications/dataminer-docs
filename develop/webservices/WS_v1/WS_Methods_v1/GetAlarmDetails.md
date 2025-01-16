---
uid: GetAlarmDetails
---

# GetAlarmDetails

Use this method to retrieve the alarm details for a specified alarm.

Deprecated since DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11.<!-- RN 40240 -->. From DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards, use the [GetAlarmDetailsV2](xref:GetAlarmDetailsV2) method instead.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                              |
| alarmID    | Integer | The alarm ID.                                        |

## Output

| Item                  | Format    | Description                                    |
|-----------------------|-----------|------------------------------------------------|
| GetAlarmDetailsResult | [DMAAlarmDetails](xref:DMAAlarmDetails) | The alarm information for the specified alarm. |
