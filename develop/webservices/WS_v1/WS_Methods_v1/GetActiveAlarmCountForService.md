---
uid: GetActiveAlarmCountForService
---

# GetActiveAlarmCountForService

Use this method to retrieve the number of active alarms for a particular service.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                              |
| serviceID  | Integer | The service ID.                                      |

## Output

| Item | Format | Description |
|--|--|--|
| GetActiveAlarmCountForServiceResult | [DMAAlarmCountData](xref:DMAAlarmCountData) | An array listing the alarm count for each severity level. |
