---
uid: GetInformationEvents
---

# GetInformationEvents

Use this method to retrieve the information events for a specified timespan.

## Input

| Item         | Format       | Description                                                              |
|--------------|--------------|--------------------------------------------------------------------------|
| connection   | String       | The connection ID. See [ConnectApp](xref:ConnectApp).                     |
| utcStartTime | Long integer | The start time of the period for which information events are retrieved. |
| utcEndTime   | Long integer | The end time of the period for which information events are retrieved.   |

## Output

| Item | Format | Description |
|--|--|--|
| GetInformationEventsResult | Array of [DMAAlarm](xref:DMAAlarm) | The information events for the indicated period. |
