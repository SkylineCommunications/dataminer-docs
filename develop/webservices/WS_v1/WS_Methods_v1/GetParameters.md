---
uid: GetParameters
---

# GetParameters

Use this method to retrieve a number of element parameters by ID and name.

## Input

| Item       | Format          | Description                                           |
|------------|-----------------|-------------------------------------------------------|
| connection | String          | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer         | The DataMiner Agent ID.                               |
| elementID  | Integer         | The element ID.                                       |
| parameters | Array of string | The IDs and names of the parameters to be retrieved.  |

## Output

| Item | Format | Description |
|--|--|--|
| GetParametersResult | Array of [DMAParameter](xref:DMAParameter) | The parameters for the specified element. |
