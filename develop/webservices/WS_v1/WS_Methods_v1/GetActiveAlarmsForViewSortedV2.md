---
uid: GetActiveAlarmsForViewSortedV2
---

# GetActiveAlarmsForViewSortedV2

Use this method to retrieve a specific number of active view alarms along with the alarm cache status.

Available from DataMiner 10.0.7 onwards.

> [!NOTE]
> Using this method, you can e.g. request alarms in batches in order to minimize loading time.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID | Integer | The view ID. |
| groupOn | String | The field by which to group the alarms. This can be a severity (e.g. “critical”, “major”, etc.) or a relative time string (e.g. “yesterday”, “last week”, etc.) |
| index | Integer | The point from which to start returning alarms. |
| count | Integer | The number of alarms to be returned. |
| orderBy | String | The Alarm Console column(s) by which to order the alarms (separated by semicolons). |

> [!NOTE]
> The possible groupOn values for this method are usually first retrieved by the [GetActiveAlarmPagesForView](xref:GetActiveAlarmPagesForView) method.

## Output

| Item | Format | Description |
|--|--|--|
| GetActiveAlarmsForViewSortedV2Result | Array of [DMAAlarm](xref:DMAAlarm) | The requested number of active view alarms, sorted as specified, as well as the alarm cache status. |
