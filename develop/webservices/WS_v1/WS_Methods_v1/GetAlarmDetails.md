---
uid: GetAlarmDetails
---

# GetAlarmDetails

Use this method to retrieve the alarm details for a specified alarm.

> [!NOTE]
> From DataMiner 10.2.0 [CU13]/10.3.0 [CU1]/10.3.4 onwards, use the [GetAlarmHistory method](xref:GetAlarmHistory) to get the alarm details for a non-root alarm.

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
