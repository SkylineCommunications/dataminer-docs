---
uid: GetMaskedAlarmsForViewSorted
---

# GetMaskedAlarmsForViewSorted

Use this method to retrieve a specific number of masked view alarms.

> [!NOTE]
> Using this method, you can e.g. request masked view alarms in batches in order to minimize loading time.

## Input

| Item       | Format  | Description                                                                         |
|------------|---------|-------------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp).    |
| viewID     | Integer | The view ID.                                                                        |
| index      | Integer | The point from which to start returning alarms.                                     |
| count      | Integer | The number of alarms to be returned.                                                |
| orderBy    | String  | The Alarm Console column(s) by which to order the alarms (separated by semicolons). |

## Output

| Item | Format | Description |
|--|--|--|
| GetMaskedAlarmsForViewSortedResult | Array of [DMAAlarm](xref:DMAAlarm) | The masked alarms for the specified view, sorted as requested. |
