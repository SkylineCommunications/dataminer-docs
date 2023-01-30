---
uid: GetViewsTreeForElement
---

# GetViewsTreeForElement

Use this method to retrieve the view hierarchy of a particular element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| elementID  | Integer | The element ID.                                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetViewsTreeForElementResult | Array of [DMAView](xref:DMAView) | The view hierarchy of the specified element. |
