---
uid: GetInformationEventsV2
---

# GetInformationEventsV2

Use this method to retrieve the information events for a specified timespan, as well as the alarm cache status.

Available from DataMiner 10.0.7 onwards.

## Input

| Item         | Format       | Description                                                              |
|--------------|--------------|--------------------------------------------------------------------------|
| connection   | String       | The connection ID. See [ConnectApp](xref:ConnectApp).                     |
| utcStartTime | Long integer | The start time of the period for which information events are retrieved. |
| utcEndTime   | Long integer | The end time of the period for which information events are retrieved.   |

## Output

| Item | Format | Description |
|--|--|--|
| GetInformationEventsV2Result | Array of [DMAAlarm](xref:DMAAlarm) | The information events for the indicated period, as well as the alarm cache status. |
