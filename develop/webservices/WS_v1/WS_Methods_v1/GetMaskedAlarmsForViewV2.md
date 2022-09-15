---
uid: GetMaskedAlarmsForViewV2
---

# GetMaskedAlarmsForViewV2

Use this method to retrieve the list of all the masked alarms of a particular view, as well as the alarm cache status.

Available from DataMiner 10.0.7 onwards.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID     | Integer | The view ID.                                                                     |

## Output

| Item | Format | Description |
|--|--|--|
| GetMaskedAlarmsForViewV2Result | Array of [DMAAlarm](xref:DMAAlarm) | The list of all the masked alarms of the specified view, as well as the alarm cache status. |
