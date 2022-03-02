---
uid: GetAlarmCountForElement
---

# GetAlarmCountForElement

Use this method to retrieve the number of alarms for every alarm severity for the specified element during the specified timespan. Available from DataMiner 9.5.8 onwards.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID | Integer | The DataMiner Agent ID. |
| ElementID | Integer | The element ID. |
| UtcStartTime | Long integer | The start time of the timespan for which the alarm count should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| UtcEndTime | Long integer | The end time of the timespan for which the alarm count should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |

## Output

| Item                           | Format            | Description                                               |
|--------------------------------|-------------------|-----------------------------------------------------------|
| GetAlarmCountFor­ElementResult | DMAAlarmCountData | An array listing the alarm count for each severity level. |
