---
uid: GetServiceDefinitions
---

# GetServiceDefinitions

Use this method to retrieve all available service definitions. Available from DataMiner 10.0.2 onwards.

## Input

| Item       | Format | Description                                                                          |
|------------|--------|--------------------------------------------------------------------------------------|
| connection | String | The connection string. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetServiceDefinitionsResult | Array of [DMAServiceDefinitionLite](xref:DMAServiceDefinitionLite) | A DMAServiceDefinitionLite object for each of the available service definitions, containing the ID and name of the service definition. |
