---
uid: GetMaskedAlarmsForElementV2
---

# GetMaskedAlarmsForElementV2

Use this method to retrieve the list of all the masked alarms of a particular element, as well as the alarm cache status.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| elementID  | Integer | The element ID.                                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetMaskedAlarmsForElementV2Result | Array of [DMAAlarm](xref:DMAAlarm) | The list of all the masked alarms of the specified element, as well as the alarm cache status. |
