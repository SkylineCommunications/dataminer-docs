---
uid: GetActiveAlarmsSorted
---

# GetActiveAlarmsSorted

Use this method to retrieve a specific number of active alarms with a particular alarm severity.

> [!NOTE]
> Using this method, you can e.g. request alarms in batches in order to minimize loading time.

## Input

| Item           | Format  | Description                                                                         |
|----------------|---------|-------------------------------------------------------------------------------------|
| connection     | String  | The connection ID. See [ConnectApp](xref:ConnectApp).                                |
| withAlarmState | String  | The alarm severity.                                                                 |
| index          | Integer | The point from which to start returning alarms.                                     |
| count          | Integer | The number of alarms to be returned.                                                |
| orderBy        | String  | The Alarm Console column(s) by which to order the alarms (separated by semicolons). |

## Output

| Item | Format | Description |
|--|--|--|
| GetActiveAlarmsSortedResult | Array of [DMAAlarm](xref:DMAAlarm) | The requested number of active alarms, sorted as specified. |
