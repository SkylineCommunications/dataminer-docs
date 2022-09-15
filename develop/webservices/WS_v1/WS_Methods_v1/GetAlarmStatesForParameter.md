---
uid: GetAlarmStatesForParameter
---

# GetAlarmStatesForParameter

Use this method to retrieve the relative duration (in percent) of every alarm severity for the specified parameter during the specified timespan.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| parameterID | Integer | The parameter ID. |
| tableIndex | String | The table index. This field must be specified for table column parameters; otherwise it must be left empty. |
| utcStartTime | Long integer | The start time of the timespan for which the alarm states should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| utcEndTime | Long integer | The end time of the timespan for which the alarm states should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |

## Output

| Item                              | Format            | Description                                                 |
|-----------------------------------|-------------------|-------------------------------------------------------------|
| GetAlarmStatesForParameterResult | [DMAAlarmStateData](xref:DMAAlarmStateData) | An array listing the relative duration of each alarm state. |
