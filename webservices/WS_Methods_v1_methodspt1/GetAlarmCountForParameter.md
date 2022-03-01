---
uid: GetAlarmCountForParameter
---

# GetAlarmCountForParameter

Use this method to retrieve the number of alarms for every alarm severity for the specified parameter during the specified timespan.

## Input

| Item         | Format       | Description                                                                                                                                    |
|--------------|--------------|------------------------------------------------------------------------------------------------------------------------------------------------|
| Connection   | String       | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                                                           |
| DmaID        | Integer      | The DataMiner Agent ID.                                                                                                                        |
| ElementID    | Integer      | The element ID.                                                                                                                                |
| ParameterID  | Integer      | The parameter ID.                                                                                                                              |
| TableIndex   | String       | The table index. This field must be specified for table column parameters; otherwise it must be left empty.                                    |
| UtcStartTime | Long integer | The start time of the timespan for which the alarm count should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| UtcEndTime   | Long integer | The end time of the timespan for which the alarm count should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT).   |

## Output

| Item                             | Format            | Description                                               |
|----------------------------------|-------------------|-----------------------------------------------------------|
| GetAlarmCountForPa­rameterResult | DMAAlarmCountData | An array listing the alarm count for each severity level. |

