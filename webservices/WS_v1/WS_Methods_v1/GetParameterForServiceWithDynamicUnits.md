---
uid: GetParameterForServiceWithDynamicUnits
---

# GetParameterForServiceWithDynamicUnits

Use this method to retrieve a particular parameter for a service, with dynamic units. Available from DataMiner 10.0.11 onwards.

## Input

| Item        | Format  | Description                                                                      |
|-------------|---------|----------------------------------------------------------------------------------|
| Connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID       | Integer | The DataMiner Agent ID.                                                          |
| ServiceID   | Integer | The service ID.                                                                  |
| ParameterID | Integer | The parameter ID.                                                                |
| TableIndex  | String  | The table index (in case the parameter is a table parameter).                    |

## Output

| Item | Format | Description |
|--|--|--|
| GetParameterForServiceWithDynamic­UnitsResult | [DMAParameter](xref:DMAParameter) | The data of the specified parameter of the specified service, with dynamic units. |
