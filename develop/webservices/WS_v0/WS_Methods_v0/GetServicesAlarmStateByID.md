---
uid: GetServicesAlarmStateByID
---

# GetServicesAlarmStateByID

Use this method to request the current alarm state of a specific service (referenced by ID).

## Input

| Item       | Format  | Description                                   |
|------------|---------|-----------------------------------------------|
| connection | String  | The connection ID. See [Connect](xref:Connect). |
| DMAID      | Integer | The DataMiner Agent ID.                       |
| ServiceID  | Integer | The service ID.                               |

## Output

| Item                             | Format | Description                                       |
|----------------------------------|--------|---------------------------------------------------|
| GetServicesAlarmStateByIDResult | String | The current alarm state of the specified service. |
