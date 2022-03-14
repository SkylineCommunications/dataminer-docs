---
uid: GetCurrentAlarmByRootID
---

# GetCurrentAlarmByRootID

Use this method to retrieve the current alarm associated with a particular root alarm ID.

## Input

| Item        | Format  | Description                                          |
|-------------|---------|------------------------------------------------------|
| Connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID       | Integer | The DataMiner Agent ID.                              |
| RootAlarmID | Integer | The root alarm ID.                                   |

## Output

| Item | Format | Description |
|--|--|--|
| GetCurrentAlarmBy­RootIDResult | [DMAAlarm](xref:DMAAlarm) | The current alarm associated with the specified root alarm ID. |
