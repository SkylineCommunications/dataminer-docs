---
uid: GetParameterForServiceWithDynamicUnits
---

# GetParameterForServiceWithDynamicUnits

Use this method to retrieve a particular parameter for a service, with dynamic units. Available from DataMiner 10.0.11 onwards.

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
| GetParameterForServiceWithDynamicUnitsResult | [DMAParameter](xref:DMAParameter) | The data of the specified parameter of the specified service, with dynamic units. |
