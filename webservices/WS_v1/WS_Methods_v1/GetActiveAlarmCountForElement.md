---
uid: GetActiveAlarmCountForElement
---

# GetActiveAlarmCountForElement

Use this method to retrieve the number of active alarms for a particular element.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                              |
| ElementID  | Integer | The element ID.                                      |

## Output

| Item                                 | Format            | Description                                               |
|--------------------------------------|-------------------|-----------------------------------------------------------|
| GetActiveAlarmCount­ForElementResult | DMAAlarmCountData | An array listing the alarm count for each severity level. |
