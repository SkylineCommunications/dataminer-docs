---
uid: GetParametersForService
---

# GetParametersForService

Use this method to retrieve the data of all the parameters of a particular service.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| serviceID  | Integer | The service ID.                                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetParametersForServiceResult | Array of [DMAParameter](xref:DMAParameter) | The data of all the parameters of the specified service. |
