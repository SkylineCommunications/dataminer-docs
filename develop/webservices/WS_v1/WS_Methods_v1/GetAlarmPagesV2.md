---
uid: GetAlarmPagesV2
---

# GetAlarmPagesV2

Use this method to retrieve a number of filtered alarms in pages, grouped by time (default) or severity, as well as the alarm cache status.

<!-- Available from DataMiner 10.0.7 onwards. -->

## Input

| Item             | Format | Description                                                               |
|------------------|--------|---------------------------------------------------------------------------|
| connection       | String | The connection ID. See [ConnectApp](xref:ConnectApp).                     |
| filter           | [DMAAlarmFilterV2](xref:DMAAlarmFilterV2) | The filter that the alarms must match. |
| groupBy          | String | Either “time” (default) or “severity”.                                    |

## Output

| Item | Format | Description |
|--|--|--|
| GetAlarmPagesV2Result | Array of [DMAAlarmPage](xref:DMAAlarmPage) | The alarm pages, filtered and grouped as specified, as well as the alarm cache status. |
