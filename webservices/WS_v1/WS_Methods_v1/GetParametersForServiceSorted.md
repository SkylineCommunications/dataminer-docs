---
uid: GetParametersForServiceSorted
---

# GetParametersForServiceSorted

Use this method to retrieve a specific number of service parameters.

> [!NOTE]
> Using this method, you can e.g. request service parameters in batches in order to minimize loading time.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ServiceID  | Integer | The service ID.                                                                  |
| Index      | Integer | The point from which to start returning parameters.                              |
| Count      | Integer | The number of parameters to be returned.                                         |
| OrderBy    | String  | The field(s) by which to order the parameters (separated by semicolons).         |

## Output

| Item | Format | Description |
|--|--|--|
| GetParametersForSer­viceSortedResult | Array of [DMAParameter](xref:DMAParameter) | The parameters for the specified service, sorted as requested. |
