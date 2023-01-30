---
uid: GetMaskedAlarmsForElementSortedV2
---

# GetMaskedAlarmsForElementSortedV2

Use this method to retrieve a specific number of masked element alarms, as well as the alarm cache status.

Available from DataMiner 10.0.7 onwards.

> [!NOTE]
> Using this method, you can e.g. request alarms in batches in order to minimize loading time.

## Input

| Item       | Format  | Description                                                                         |
|------------|---------|-------------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp).    |
| dmaID      | Integer | The DMA ID.                                                                         |
| elementID  | Integer | The element ID.                                                                     |
| index      | Integer | The point from which to start returning alarms.                                     |
| count      | Integer | The number of alarms to be returned.                                                |
| orderBy    | String  | The Alarm Console column(s) by which to order the alarms (separated by semicolons). |

## Output

| Item | Format | Description |
|--|--|--|
| GetMaskedAlarmsForElementSortedV2Result | Array of [DMAAlarm](xref:DMAAlarm) | The requested number of masked element alarms, sorted as specified, as well as the alarm cache status. |
