---
uid: GetMaskedAlarmsForElementv1
---

# GetMaskedAlarmsForElement

Use this method to retrieve the list of all the masked alarms of a particular element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ElementID  | Integer | The element ID.                                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetMaskedAlarms­ForElementResult | Array of [DMAAlarm](xref:DMAAlarm) | The list of all the masked alarms of the specified element. |
