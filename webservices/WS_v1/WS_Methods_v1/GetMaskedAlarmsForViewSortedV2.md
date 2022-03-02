---
uid: GetMaskedAlarmsForViewSortedV2
---

# GetMaskedAlarmsForViewSortedV2

Use this method to retrieve a specific number of masked view alarms, as well as the alarm cache status.

Available from DataMiner 10.0.7 onwards.

> [!NOTE]
> Using this method, you can e.g. request masked view alarms in batches in order to minimize loading time.

## Input

| Item       | Format  | Description                                                                         |
|------------|---------|-------------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) .    |
| ViewID     | Integer | The view ID.                                                                        |
| Index      | Integer | The point from which to start returning alarms.                                     |
| Count      | Integer | The number of alarms to be returned.                                                |
| OrderBy    | String  | The Alarm Console column(s) by which to order the alarms (separated by semicolons). |

## Output

| Item                                  | Format                                                                   | Description                                                                                       |
|---------------------------------------|--------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------|
| GetMaskedAlarmsFor­ViewSortedV2Result | Array of DMAAlarm (see [DMAAlarm](xref:DMAAlarm)) | The masked alarms for the specified view, sorted as requested, as well as the alarm cache status. |

