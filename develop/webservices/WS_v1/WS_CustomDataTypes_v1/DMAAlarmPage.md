---
uid: DMAAlarmPage
---

# DMAAlarmPage

| Item | Format | Description |
|--|--|--|
| Index | Integer | The index of the page. |
| Name | String | User-friendly display title of the page, e.g., "Today", "4 weeks ago" or "Last month" when grouped on Time, or "Critical", "Warning", "Timeout", etc. when grouped on Severity |
| Amount | Integer | The number of alarms matching the input filter. |
| AlarmState | String | The highest alarm level of the alarms matching the input filter. |
| Filter | Array | See [DMAAlarmFilterV2](xref:DMAAlarmFilterV2). |
| AlarmStates | Array of DMAKeyValuePair | DMAKeyValuePair objects, containing the severity as *Key* and the number of alarms with that severity as *Value*. |
