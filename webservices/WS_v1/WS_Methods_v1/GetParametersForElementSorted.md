---
uid: GetParametersForElementSorted
---

# GetParametersForElementSorted

Use this method to retrieve a specific number of element parameters.

> [!NOTE]
> Using this method, you can e.g. request element parameters in batches in order to minimize loading time.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ElementID  | Integer | The element ID.                                                                  |
| Index      | Integer | The point from which to start returning parameters.                              |
| Count      | Integer | The number of parameters to be returned.                                         |
| OrderBy    | String  | The field(s) by which to order the parameters (separated by semicolons).         |

## Output

| Item | Format | Description |
|--|--|--|
| GetParametersFor­ElementSortedResult | Array of [DMAParameter](xref:DMAParameter) | The parameters for the specified element, sorted as requested. |
