---
uid: GetActiveAlarmsForElement
---

# GetActiveAlarmsForElement

Use this method to retrieve all the active alarms of a particular element.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                              |
| elementID  | Integer | The element ID.                                      |

## Output

| Item | Format | Description |
|--|--|--|
| GetActiveAlarmsForElementResult | Array of [DMAAlarm](xref:DMAAlarm) | The active alarms of the specified element. |
