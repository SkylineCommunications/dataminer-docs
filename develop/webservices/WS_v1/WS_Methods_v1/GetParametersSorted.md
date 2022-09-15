---
uid: GetParametersSorted
---

# GetParametersSorted

Use this method to retrieve a specific number of element parameters by ID and name.

> [!NOTE]
> Using this method, you can e.g. request parameters in batches in order to minimize loading time.

## Input

| Item       | Format          | Description                                                                      |
|------------|-----------------|----------------------------------------------------------------------------------|
| connection | String          | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer         | The DataMiner Agent ID.                                                          |
| elementID  | Integer         | The element ID.                                                                  |
| parameters | Array of string | The IDs and names of the parameters to be retrieved.                             |
| index      | Integer         | The point from which to start returning parameters.                              |
| count      | Integer         | The number of parameters to be returned.                                         |
| orderBy    | String          | The field(s) by which to order the parameters (separated by semicolons).         |

## Output

| Item | Format | Description |
|--|--|--|
| GetParametersSortedResult | Array of [DMAParameter](xref:DMAParameter) | The parameters for the specified element, sorted as requested. |
