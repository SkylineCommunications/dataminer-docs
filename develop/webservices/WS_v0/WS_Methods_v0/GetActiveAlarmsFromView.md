---
uid: GetActiveAlarmsFromView
---

# GetActiveAlarmsFromView

Use this method to request a list of all the alarms of a specific view (referenced by name).

## Input

| Item       | Format | Description                                   |
|------------|--------|-----------------------------------------------|
| connection | String | The connection ID. See [Connect](xref:Connect). |
| viewName   | String | The view name.                                |

## Output

| Item | Format | Description |
|--|--|--|
| GetActiveAlarmsFromViewResult | Array of [AlarmEventMessage](xref:AlarmEventMessage) | All the alarms of the specified view. |
