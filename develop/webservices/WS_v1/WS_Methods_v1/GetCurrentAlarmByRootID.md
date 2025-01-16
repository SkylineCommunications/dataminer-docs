---
uid: GetCurrentAlarmByRootID
---

# GetCurrentAlarmByRootID

Use this method to retrieve the current alarm associated with a particular root alarm ID.

From DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards<!-- RN 40240 -->, use the [GetCurrentAlarmByRootIDV3](xref:GetCurrentAlarmByRootIDV3) method instead.

## Input

| Item        | Format  | Description                                          |
|-------------|---------|------------------------------------------------------|
| connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID       | Integer | The DataMiner Agent ID.                              |
| rootAlarmID | Integer | The root alarm ID.                                   |

## Output

| Item | Format | Description |
|--|--|--|
| GetCurrentAlarmByRootIDResult | [DMAAlarm](xref:DMAAlarm) | The current alarm associated with the specified root alarm ID. |
