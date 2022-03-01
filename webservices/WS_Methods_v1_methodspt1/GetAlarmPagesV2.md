---
uid: GetAlarmPagesV2
---

# GetAlarmPagesV2

Use this method to retrieve a number of filtered alarms in pages, grouped by time (default) or severity, as well as the alarm cache status.

Available from DataMiner 10.0.7 onwards.

## Input

| Item             | Format | Description                                                                                                  |
|------------------|--------|--------------------------------------------------------------------------------------------------------------|
| Connection       | String | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                         |
| DMAAlarmFilterV2 | Array  | The filter that the alarms must match. See [DMAAlarmFilterV2](xref:DMAAlarmFilterV2). |
| GroupBy          | String | Either “time” (default) or “severity”.                                                                       |

## Output

| Item                  | Format                                                                               | Description                                                                            |
|-----------------------|--------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------|
| GetAlarmPagesV2Result | Array of DMAAlarmPage (see [DMAAlarmPage](xref:DMAAlarmPage)) | The alarm pages, filtered and grouped as specified, as well as the alarm cache status. |

