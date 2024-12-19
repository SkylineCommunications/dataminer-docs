---
uid: GetCurrentAlarmByRootIDV3
---

# GetCurrentAlarmByRootIDV3

Use this method to retrieve the current alarm associated with a particular root alarm ID, as well as the alarm cache status.

Available from DataMiner 10.4.11 onwards.

## Input

| Item        | Format  | Description                                           |
|-------------|---------|-------------------------------------------------------|
| connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID       | Integer | The DataMiner Agent ID.                               |
| elementID   | Integer | The element ID.                                       |
| rootAlarmID | Integer | The root alarm ID.                                    |

## Output

| Item | Format | Description |
|--|--|--|
| GetCurrentAlarmByRootIDV3Result | [DMAAlarm](xref:DMAAlarm) | The current alarm associated with the specified root alarm ID, as well as the alarm cache status. |
