---
uid: GetMaskedAlarmsForView
---

# GetMaskedAlarmsForView

Use this method to retrieve the list of all the masked alarms of a particular view.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| ViewID     | Integer | The view ID.                                                                     |

## Output

| Item                          | Format                                                                   | Description                                              |
|-------------------------------|--------------------------------------------------------------------------|----------------------------------------------------------|
| GetMaskedAlarmsFor­ViewResult | Array of DMAAlarm (see [DMAAlarm](xref:DMAAlarm)) | The list of all the masked alarms of the specified view. |

