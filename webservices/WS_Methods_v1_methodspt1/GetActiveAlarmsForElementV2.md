---
uid: GetActiveAlarmsForElementV2
---

# GetActiveAlarmsForElementV2

Use this method to retrieve all the active alarms of a particular element along with the alarm cache status.

Available from DataMiner 10.0.7 onwards.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                              |
| ElementID  | Integer | The element ID.                                      |

## Output

| Item                               | Format                                                                   | Description                                                                    |
|------------------------------------|--------------------------------------------------------------------------|--------------------------------------------------------------------------------|
| GetActiveAlarmsFor­ElementV2Result | Array of DMAAlarm (see [DMAAlarm](xref:DMAAlarm)) | The active alarms of the specified element, as well as the alarm cache status. |

