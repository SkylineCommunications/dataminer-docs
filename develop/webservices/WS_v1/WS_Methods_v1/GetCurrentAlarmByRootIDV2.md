---
uid: GetCurrentAlarmByRootIDV2
---

# GetCurrentAlarmByRootIDV2

Use this method to retrieve the current alarm associated with a particular root alarm ID, as well as the alarm cache status.

Available from DataMiner 10.0.7 onwards.

> [!NOTE]
> From DataMiner 10.6.0/10.5.1 onwards, when Swarming is enabled, use the [GetCurrentAlarmByRootIDV3](xref:GetCurrentAlarmByRootIDV3) method instead.

## Input

| Item        | Format  | Description                                          |
|-------------|---------|------------------------------------------------------|
| connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID       | Integer | The DataMiner Agent ID.                              |
| rootAlarmID | Integer | The root alarm ID.                                   |

## Output

| Item | Format | Description |
|--|--|--|
| GetCurrentAlarmByRootIDV2Result | [DMAAlarm](xref:DMAAlarm) | The current alarm associated with the specified root alarm ID, as well as the alarm cache status. |
