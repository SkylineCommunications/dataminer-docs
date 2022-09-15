---
uid: GetPropertiesForElement
---

# GetPropertiesForElement

Use this method to retrieve all the properties for a particular element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| elementID  | Integer | The element ID.                                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetPropertiesForElementResult | Array of [DMAProperty](xref:DMAProperty) | All the properties for the specified element. |
