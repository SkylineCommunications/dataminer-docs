---
uid: GetServicesAlarmStateByName
---

# GetServicesAlarmStateByName

Use this method to request the current alarm state of a specific service (referenced by name).

## Input

| Item        | Format | Description                                   |
|-------------|--------|-----------------------------------------------|
| connection  | String | The connection ID. See [Connect](xref:Connect). |
| ServiceName | String | The service name.                             |

## Output

| Item                               | Format | Description                                       |
|------------------------------------|--------|---------------------------------------------------|
| GetServicesAlarmStateByNameResult | String | The current alarm state of the specified service. |
