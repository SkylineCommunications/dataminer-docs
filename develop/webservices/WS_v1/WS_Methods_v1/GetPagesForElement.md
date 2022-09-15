---
uid: GetPagesForElement
---

# GetPagesForElement

Use this method to retrieve all the Data Display pages of a particular element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| elementID  | Integer | The element ID.                                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetPagesForElementResult | Array of [DMAElementPage](xref:DMAElementPage) | All the Data Display pages of the specified element. |
