---
uid: GetMaskedAlarmsSortedV2
---

# GetMaskedAlarmsSortedV2

Use this method to retrieve a specific number of masked alarms with a particular alarm severity, as well as the alarm cache status.

Available from DataMiner 10.0.7 onwards.

> [!NOTE]
> Using this method, you can e.g. request masked alarms in batches in order to minimize loading time.

## Input

| Item           | Format  | Description                                                                         |
|----------------|---------|-------------------------------------------------------------------------------------|
| connection     | String  | The connection ID. See [ConnectApp](xref:ConnectApp).    |
| withAlarmState | String  | The alarm severity.                                                                 |
| index          | Integer | The point from which to start returning alarms.                                     |
| count          | Integer | The number of alarms to be returned.                                                |
| orderBy        | String  | The Alarm Console column(s) by which to order the alarms (separated by semicolons). |

## Output

| Item | Format | Description |
|--|--|--|
| GetMaskedAlarmsSortedV2Result | Array of [DMAAlarm](xref:DMAAlarm) | The requested number of masked alarms, sorted as specified, as well as the alarm cache status. |
