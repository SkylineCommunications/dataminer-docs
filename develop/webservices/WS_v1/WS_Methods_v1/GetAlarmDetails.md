---
uid: GetAlarmDetails
---

# GetAlarmDetails

Use this method to retrieve the alarm details for a specified alarm.

> [!NOTE]
> From DataMiner 10.6.0/10.5.1 onwards, when Swarming is enabled, use the [GetAlarmDetailsV2](xref:GetAlarmDetailsV2) method instead.

> [!NOTE]
> Use the [GetAlarmHistory](xref:GetAlarmHistory) or [GetAlarmHistoryV2](xref:GetAlarmHistoryV2) method to get the alarm details of a cleared non-root alarm.

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
