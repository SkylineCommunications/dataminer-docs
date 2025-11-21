---
uid: GetAlarmPages
---

# GetAlarmPages

Use this method to retrieve filtered alarms in pages, grouped by time (default) or severity.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| filter | [DMAAlarmFilterV2](xref:DMAAlarmFilterV2) | The filter that the alarms must match. |
| groupBy | String | Either "time" (default) or "severity". |

## Output

| Item | Format | Description |
|--|--|--|
| GetAlarmPagesResult | Array of [DMAAlarmPage](xref:DMAAlarmPage) | The alarm pages, filtered and grouped as specified. |
