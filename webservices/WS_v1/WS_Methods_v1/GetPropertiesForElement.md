---
uid: GetPropertiesForElement
---

# GetPropertiesForElement

Use this method to retrieve all the properties for a particular element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ElementID  | Integer | The element ID.                                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetPropertiesFor­ElementResult | Array of [DMAProperty](xref:DMAProperty) | All the properties for the specified element. |
