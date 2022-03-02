---
uid: GetAlarmPageUpdatesV2
---

# GetAlarmPageUpdatesV2

Use this method to retrieve alarm page information for a custom selection of alarms that match the given filters, as well as the alarm cache status.

Available from DataMiner 10.0.7 onwards.

## Input

| Item       | Format                             | Description                                                                                                   |
|------------|------------------------------------|---------------------------------------------------------------------------------------------------------------|
| Connection | String                             | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                          |
| Filters    | Array of DMA­AlarmFilterV2 filters | The filters that the alarms must match. See [DMAAlarmFilterV2](xref:DMAAlarmFilterV2). |

## Output

| Item                         | Format                                                                                                  | Description                                                                                                  |
|------------------------------|---------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------|
| GetAlarmPageUpdates­V2Result | Array of DMA­AlarmPageUpdate (see [DMAAlarmPageUpdate](xref:DMAAlarmPageUpdate)) | The alarm page information for the alarms matching the specified filters, as well as the alarm cache status. |

