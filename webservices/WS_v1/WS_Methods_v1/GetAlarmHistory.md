---
uid: GetAlarmHistory
---

# GetAlarmHistory

Use this method to retrieve:

- one specific alarm, or

- all alarms in the alarm tree of a specific alarm.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID | Integer | The DMA ID. |
| AlarmID | Integer | The ID of the specified alarm. This must be the ID of a root alarm of an alarm available in the cache. If you do not specify the root alarm ID and the alarm is not available in the cache, no results will be returned. |
| RequestFullTree | Boolean | Whether the method has to return only the specified alarm (FALSE) or all alarms in the alarm tree of the specified alarm (TRUE). |

## Output

| Item                  | Format                                                                   | Description                                |
|-----------------------|--------------------------------------------------------------------------|--------------------------------------------|
| GetAlarmHistoryResult | Array of [DMAAlarm](xref:DMAAlarm) | The alarm history for the specified alarm. |
