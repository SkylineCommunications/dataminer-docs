---
uid: GetViewsTreeForElement
---

# GetViewsTreeForElement

Use this method to retrieve the view hierarchy of a particular element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ElementID  | Integer | The element ID.                                                                  |

## Output

| Item                          | Format                                                                | Description                                  |
|-------------------------------|-----------------------------------------------------------------------|----------------------------------------------|
| GetViewsTreeFor­ElementResult | Array of [DMAView](xref:DMAView) | The view hierarchy of the specified element. |
