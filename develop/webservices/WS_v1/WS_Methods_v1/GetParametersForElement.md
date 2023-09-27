---
uid: GetParametersForElement
---

# GetParametersForElement

Use this method to retrieve the data of all the parameters of a particular element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| elementID  | Integer | The element ID.                                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetParametersForElementResult | Array of [DMAParameter](xref:DMAParameter) | The data of all the parameters of the specified element. |
