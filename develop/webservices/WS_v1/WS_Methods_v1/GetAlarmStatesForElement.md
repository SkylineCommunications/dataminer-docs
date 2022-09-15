---
uid: GetAlarmStatesForElement
---

# GetAlarmStatesForElement

Use this method to retrieve the relative duration (in percent) of every alarm severity for the specified element during the specified timespan (available from DataMiner 9.5.8 onwards).

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| utcStartTime | Long integer | The start time of the timespan for which the alarm states should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| utcEndTime | Long integer | The end time of the timespan for which the alarm states should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |

## Output

| Item                            | Format            | Description                                                 |
|---------------------------------|-------------------|-------------------------------------------------------------|
| GetAlarmStatesForElementResult | [DMAAlarmStateData](xref:DMAAlarmStateData) | An array listing the relative duration of each alarm state. |
