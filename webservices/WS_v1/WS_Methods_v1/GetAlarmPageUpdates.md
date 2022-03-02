---
uid: GetAlarmPageUpdates
---

# GetAlarmPageUpdates

Use this method to retrieve alarm page information for a custom selection of alarms that match the specified filters. (Available from DataMiner 9.5.6 onwards.)

## Input

| Item       | Format                             | Description                                                                                                   |
|------------|------------------------------------|---------------------------------------------------------------------------------------------------------------|
| Connection | String                             | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                          |
| Filters    | Array of DMA­AlarmFilterV2 filters | The filters that the alarms must match. See [DMAAlarmFilterV2](xref:DMAAlarmFilterV2). |

## Output

| Item                       | Format                                                                                                  | Description                                                               |
|----------------------------|---------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------|
| GetAlarmPageUpdates­Result | Array of DMA­AlarmPageUpdate (see [DMAAlarmPageUpdate](xref:DMAAlarmPageUpdate)) | The alarm page information for the alarms matching the specified filters. |

