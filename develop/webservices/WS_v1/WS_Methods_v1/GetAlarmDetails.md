---
uid: GetAlarmDetails
---

# GetAlarmDetails

Use this method to retrieve the alarm details for a specified alarm.

> [!NOTE]
> Use the [GetAlarmHistory method](xref:GetAlarmHistory) to get the alarm details of a cleared non-root alarm.

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
