---
uid: GetParameterForService
---

# GetParameterForService

Use this method to retrieve a specific parameter for a service.

## Input

| Item        | Format  | Description                                                                      |
|-------------|---------|----------------------------------------------------------------------------------|
| connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID       | Integer | The DataMiner Agent ID.                                                          |
| serviceID   | Integer | The service ID.                                                                  |
| parameterID | Integer | The parameter ID.                                                                |
| tableIndex  | String  | The table index (in case the parameter is a table parameter).                    |

## Output

| Item | Format | Description |
|--|--|--|
| GetParameterForServiceResult | [DMAParameter](xref:DMAParameter) | The data of the specified parameters of the specified service. |
