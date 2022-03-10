---
uid: GetServiceDefinition
---

# GetServiceDefinition

Use this method to retrieve a specific service definition. Available from DataMiner 10.0.2 onwards.

## Input

| Item                | Format | Description                                                                          |
|---------------------|--------|--------------------------------------------------------------------------------------|
| Connection          | String | The connection string. See [ConnectApp](xref:ConnectApp). |
| ServiceDefinitionID | String | The ID of the service definition.                                                    |

## Output

| Item | Format | Description |
|--|--|--|
| GetServiceDefinition­Result | [DMAServiceDefinition](xref:DMAServiceDefinition) | The requested service definition. |
