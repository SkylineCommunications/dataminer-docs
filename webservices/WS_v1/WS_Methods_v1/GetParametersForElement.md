---
uid: GetParametersForElement
---

# GetParametersForElement

Use this method to retrieve the data of all the parameters of a particular element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ElementID  | Integer | The element ID.                                                                  |

## Output

| Item                           | Format                                                                               | Description                                              |
|--------------------------------|--------------------------------------------------------------------------------------|----------------------------------------------------------|
| GetParametersFor­ElementResult | Array of [DMAParameter](xref:DMAParameter) | The data of all the parameters of the specified element. |
