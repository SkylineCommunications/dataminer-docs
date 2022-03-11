---
uid: GetHistoryAlarmsForParameter
---

# GetHistoryAlarmsForParameter

Use this method in order to retrieve the history alarms for a particular parameter.

Available from DataMiner version 9.5.1 onwards.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID | Integer | The DataMiner Agent ID. |
| ElementID | Integer | The element ID. |
| ParameterID | Integer | The parameter ID. |
| TableIndex | String | The table index. This field must be specified for table column parameters; otherwise it must be left empty. |
| UtcStartTime | Long integer | The start time of the timespan for which alarms should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| UtcEndTime | Long integer | The end time of the timespan for which alarms should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| Filter | Array | Array of filters limiting which alarms will be retrieved. |
| Filter.IncludeInforma­tionEvents | Boolean | When true, information events will also be included. |
| Filter.IncludeEntire­AlarmTree | Boolean | When true, all alarms are included. Otherwise, only the top alarms of every alarm tree are returned. |
| Filter.AlarmTypes | Array of string | Only alarms with an alarm type specified in this array will be returned (default: null). |
| Filter.Severities | Array of string | Only alarms with a severity specified in this array will be returned (default: null). |

## Output

| Item | Format | Description |
|--|--|--|
| GetHistoryAlarmsFor­ParameterResult | Array of [DMAAlarm](xref:DMAAlarm) | The alarms for the specified parameter and period, limited by the specified filters. |
