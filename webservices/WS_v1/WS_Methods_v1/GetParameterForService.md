---
uid: GetParameterForService
---

# GetParameterForService

Use this method to retrieve a specific parameter for a service.

## Input

| Item        | Format  | Description                                                                      |
|-------------|---------|----------------------------------------------------------------------------------|
| Connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID       | Integer | The DataMiner Agent ID.                                                          |
| ServiceID   | Integer | The service ID.                                                                  |
| ParameterID | Integer | The parameter ID.                                                                |
| TableIndex  | String  | The table index (in case the parameter is a table parameter).                    |

## Output

| Item                          | Format                                                   | Description                                                    |
|-------------------------------|----------------------------------------------------------|----------------------------------------------------------------|
| GetParameterForSer­viceResult | [DMAParameter](xref:DMAParameter) | The data of the specified parameters of the specified service. |

