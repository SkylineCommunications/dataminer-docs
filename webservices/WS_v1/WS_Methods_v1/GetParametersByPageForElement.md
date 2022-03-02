---
uid: GetParametersByPageForElement
---

# GetParametersByPageForElement

Use this method to retrieve the data of all the parameters on a particular Data Display page of an element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ElementID  | Integer | The element ID.                                                                  |
| PageName   | String  | The name of the element page.                                                    |

## Output

| Item | Format | Description |
|--|--|--|
| GetParametersByPage­ForElementResult | Array of [DMAParameter](xref:DMAParameter) | The data of all the parameters on the specified element page. |
