---
uid: GetMaskedAlarmsForElementv1
---

# GetMaskedAlarmsForElement

Use this method to retrieve the list of all the masked alarms of a particular element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| elementID  | Integer | The element ID.                                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetMaskedAlarmsForElementResult | Array of [DMAAlarm](xref:DMAAlarm) | The list of all the masked alarms of the specified element. |
