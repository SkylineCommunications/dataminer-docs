---
uid: GetAlarmPages
---

# GetAlarmPages

Use this method to retrieve filtered alarms in pages, grouped by time (default) or severity. Available from DataMiner 9.5.6 onwards.

## Input

| Item             | Format | Description                                                                                                  |
|------------------|--------|--------------------------------------------------------------------------------------------------------------|
| Connection       | String | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                         |
| DMAAlarmFilterV2 | Array  | The filter that the alarms must match. See [DMAAlarmFilterV2](xref:DMAAlarmFilterV2). |
| GroupBy          | String | Either “time” (default) or “severity”.                                                                       |

## Output

| Item                | Format                                                                               | Description                                         |
|---------------------|--------------------------------------------------------------------------------------|-----------------------------------------------------|
| GetAlarmPagesResult | Array of DMAAlarmPage (see [DMAAlarmPage](xref:DMAAlarmPage)) | The alarm pages, filtered and grouped as specified. |

