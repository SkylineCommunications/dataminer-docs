---
uid: GetServiceDefinition
---

# GetServiceDefinition

Use this method to retrieve a specific service definition.

## Input

| Item                | Format | Description                                               |
|---------------------|--------|-----------------------------------------------------------|
| connection          | String | The connection string. See [ConnectApp](xref:ConnectApp). |
| serviceDefinitionID | String | The ID of the service definition.                         |

## Output

| Item | Format | Description |
|--|--|--|
| GetServiceDefinitionResult | [DMAServiceDefinition](xref:DMAServiceDefinition) | The requested service definition. |
