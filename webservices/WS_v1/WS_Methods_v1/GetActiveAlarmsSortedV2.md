---
uid: GetActiveAlarmsSortedV2
---

# GetActiveAlarmsSortedV2

Use this method to retrieve a specific number of active alarms with a particular alarm severity along with the alarm cache status.

Available from DataMiner 10.0.7 onwards.

> [!NOTE]
> Using this method, you can e.g. request alarms in batches in order to minimize loading time.

## Input

| Item           | Format  | Description                                                                         |
|----------------|---------|-------------------------------------------------------------------------------------|
| Connection     | String  | The connection ID. See [ConnectApp](xref:ConnectApp).                                |
| WithAlarmState | String  | The alarm severity.                                                                 |
| Index          | Integer | The point from which to start returning alarms.                                     |
| Count          | Integer | The number of alarms to be returned.                                                |
| OrderBy        | String  | The Alarm Console column(s) by which to order the alarms (separated by semicolons). |

## Output

| Item | Format | Description |
|--|--|--|
| GetActiveAlarms­SortedV2Result | Array of [DMAAlarm](xref:DMAAlarm) | The requested number of active alarms, sorted as specified, as well as the alarm cache status. |
