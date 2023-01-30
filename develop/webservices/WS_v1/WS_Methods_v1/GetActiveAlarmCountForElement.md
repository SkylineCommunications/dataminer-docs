---
uid: GetActiveAlarmCountForElement
---

# GetActiveAlarmCountForElement

Use this method to retrieve the number of active alarms for a particular element.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                              |
| elementID  | Integer | The element ID.                                      |

## Output

| Item                                 | Format            | Description                                               |
|--------------------------------------|-------------------|-----------------------------------------------------------|
| GetActiveAlarmCountForElementResult | [DMAAlarmCountData](xref:DMAAlarmCountData) | An array listing the alarm count for each severity level. |
