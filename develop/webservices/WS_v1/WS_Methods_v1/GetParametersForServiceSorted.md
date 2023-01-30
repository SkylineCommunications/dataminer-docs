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
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| serviceID  | Integer | The service ID.                                                                  |
| index      | Integer | The point from which to start returning parameters.                              |
| count      | Integer | The number of parameters to be returned.                                         |
| orderBy    | String  | The field(s) by which to order the parameters (separated by semicolons).         |

## Output

| Item | Format | Description |
|--|--|--|
| GetParametersForServiceSortedResult | Array of [DMAParameter](xref:DMAParameter) | The parameters for the specified service, sorted as requested. |
