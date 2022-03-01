---
uid: GetActiveAlarmsForElement
---

# GetActiveAlarmsForElement

Use this method to retrieve all the active alarms of a particular element.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                              |
| ElementID  | Integer | The element ID.                                      |

## Output

| Item                             | Format                                                                   | Description                                 |
|----------------------------------|--------------------------------------------------------------------------|---------------------------------------------|
| GetActiveAlarmsFor­ElementResult | Array of DMAAlarm (see [DMAAlarm](xref:DMAAlarm)) | The active alarms of the specified element. |

