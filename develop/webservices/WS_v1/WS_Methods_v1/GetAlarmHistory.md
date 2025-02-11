---
uid: GetAlarmHistory
---

# GetAlarmHistory

Use this method to retrieve:

- one specific alarm,
- all alarms in the alarm tree of a specific alarm, or
- alarm details of a cleared non-root alarm.

Deprecated since DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11.<!-- RN 40240 -->. From DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards, use the [GetAlarmHistoryV2](xref:GetAlarmHistoryV2) method instead.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DMA ID. |
| alarmID | Integer | The ID of the specified alarm. This must be the ID of a root alarm of an alarm available in the cache. If you do not specify the root alarm ID and the alarm is not available in the cache, no results will be returned. |
| requestFullTree | Boolean | Whether the method has to return only the specified alarm (FALSE) or all alarms in the alarm tree of the specified alarm (TRUE). |

## Output

| Item                  | Format                             | Description                                |
|-----------------------|------------------------------------|--------------------------------------------|
| GetAlarmHistoryResult | Array of [DMAAlarm](xref:DMAAlarm) | The alarm history for the specified alarm. |
