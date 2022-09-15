---
uid: GetStateForElement
---

# GetStateForElement

Use this method to retrieve the current state of a particular element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| elementID  | Integer | The element ID.                                                                  |

## Output

| Item                      | Format | Description                                 |
|---------------------------|--------|---------------------------------------------|
| GetStateForElementResult | String | The current state of the specified element. |
