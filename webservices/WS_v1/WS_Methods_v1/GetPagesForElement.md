---
uid: GetPagesForElement
---

# GetPagesForElement

Use this method to retrieve all the Data Display pages of a particular element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ElementID  | Integer | The element ID.                                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetPagesForElement­Result | Array of [DMAElementPage](xref:DMAElementPage) | All the Data Display pages of the specified element. |
