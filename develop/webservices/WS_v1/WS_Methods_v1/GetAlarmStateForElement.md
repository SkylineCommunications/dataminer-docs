---
uid: GetAlarmStateForElement
---

# GetAlarmStateForElement

Use this method to retrieve the current alarm state of an element.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                              |
| elementID  | Integer | The element ID.                                      |

## Output

| Item                           | Format | Description                                       |
|--------------------------------|--------|---------------------------------------------------|
| GetAlarmStateForElementResult | String | The current alarm state of the specified element. |
