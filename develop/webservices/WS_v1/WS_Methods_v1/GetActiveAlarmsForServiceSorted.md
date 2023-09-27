---
uid: GetActiveAlarmsForServiceSorted
---

# GetActiveAlarmsForServiceSorted

Use this method to retrieve a specific number of active service alarms.

> [!NOTE]
> Using this method, you can e.g. request alarms in batches in order to minimize loading time.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID |
| serviceID | Integer | The service ID. |
| groupOn | String | The field by which to group the alarms. This can be a severity (e.g. “critical”, “major”, etc.) or a relative time string (e.g. “yesterday”, “last week”, etc.) |
| index | Integer | The point from which to start returning alarms. |
| count | Integer | The number of alarms to be returned. |
| orderBy | String | The Alarm Console column(s) by which to order the alarms (separated by semicolons). |

> [!NOTE]
> The possible groupOn values for this method are usually first retrieved by the [GetActiveAlarmPagesForService](xref:GetActiveAlarmPagesForService) method.

## Output

| Item | Format | Description |
|--|--|--|
| GetActiveAlarmsForServiceSortedResult | Array of [DMAAlarm](xref:DMAAlarm) | The requested number of active service alarms, sorted as specified. |
