---
uid: GetVisioPagesForElement
---

# GetVisioPagesForElement

Use this method to retrieve a list of the pages of the Visio file linked to a particular element.

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                               |
| elementID  | Integer | The element ID.                                       |

## Output

| Item | Format | Description |
|--|--|--|
| GetVisioPagesForElementResult | Array of [DMAVisioPage](xref:DMAVisioPage) | A list of the pages of the Visio file linked to the element. |
