---
uid: GetAlarmDetailsV2
---

# GetAlarmDetailsV2

Use this method to retrieve the alarm details for a specified alarm.

> [!NOTE]
> Use the [GetAlarmHistory method](xref:GetAlarmHistory) to get the alarm details of a cleared non-root alarm.

Available from DataMiner 10.4.11 onwards.

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                               |
| elementID  | Integer | The element ID.                                       |
| alarmID    | Integer | The alarm ID.                                         |

## Output

| Item                    | Format    | Description                                    |
|-------------------------|-----------|------------------------------------------------|
| GetAlarmDetailsV2Result | [DMAAlarmDetails](xref:DMAAlarmDetails) | The alarm information for the specified alarm. |
