---
uid: GetActiveAlarmCountForService
---

# GetActiveAlarmCountForService

Use this method to retrieve the number of active alarms for a particular service.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                              |
| ServiceID  | Integer | The service ID.                                      |

## Output

| Item                                 | Format            | Description                                               |
|--------------------------------------|-------------------|-----------------------------------------------------------|
| GetActiveAlarmCount­ForServiceResult | [DMAAlarmCountData](xref:DMAAlarmCountData) | An array listing the alarm count for each severity level. |
