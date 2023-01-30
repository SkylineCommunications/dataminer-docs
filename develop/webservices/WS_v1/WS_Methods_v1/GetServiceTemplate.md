---
uid: GetServiceTemplate
---

# GetServiceTemplate

Use this method to retrieve an existing service template. Available from DataMiner 10.2.1/10.3.0 onwards.

## Input

| Item              | Format  | Description                                                                          |
|-------------------|---------|--------------------------------------------------------------------------------------|
| connection        | String  | The connection string. See [ConnectApp](xref:ConnectApp). |
| dmaID             | Integer | The DataMiner Agent ID.                                                              |
| serviceTemplateID | Integer | The service template ID.                                                             |

## Output

| Item                      | Format                   | Description                                                               |
|---------------------------|--------------------------|---------------------------------------------------------------------------|
| GetServiceTemplateResult | [DMAServiceTemplate](xref:DMAServiceTemplate) | The requested service template. |
