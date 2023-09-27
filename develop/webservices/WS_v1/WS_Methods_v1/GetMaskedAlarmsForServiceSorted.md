---
uid: GetMaskedAlarmsForServiceSorted
---

# GetMaskedAlarmsForServiceSorted

Use this method to retrieve a specific number of masked service alarms.

> [!NOTE]
> Using this method, you can e.g. request alarms in batches in order to minimize loading time.

## Input

| Item       | Format  | Description                                                                         |
|------------|---------|-------------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp).    |
| dmaID      | Integer | The DMA ID.                                                                         |
| serviceID  | Integer | The service ID.                                                                     |
| index      | Integer | The point from which to start returning alarms.                                     |
| count      | Integer | The number of alarms to be returned.                                                |
| orderBy    | String  | The Alarm Console column(s) by which to order the alarms (separated by semicolons). |

## Output

| Item | Format | Description |
|--|--|--|
| GetMaskedAlarmsForServiceSortedResult | Array of [DMAAlarm](xref:DMAAlarm) | The requested number of masked service alarms, sorted as specified. |
