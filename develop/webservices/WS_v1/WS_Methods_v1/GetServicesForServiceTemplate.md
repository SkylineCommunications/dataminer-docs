---
uid: GetServicesForServiceTemplate
---

# GetServicesForServiceTemplate

Use this method to retrieve all the services attached to a specified service template.

## Input

| Item              | Format  | Description                                                                      |
|-------------------|---------|----------------------------------------------------------------------------------|
| connection        | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID             | Integer | The DataMiner Agent ID.                                                          |
| serviceTemplateID | Integer | The ID of the service template.                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetServicesForServiceTemplateResult | Array of [DMAElement](xref:DMAElement) | The services attached to the specified service template. |
