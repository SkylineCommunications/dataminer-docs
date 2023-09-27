---
uid: CreateServiceTemplate
---

# CreateServiceTemplate

Use this method to create a new service template. Available from DataMiner 10.2.1/10.3.0 onwards.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection string. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| viewIDs | Array of string | The IDs of the views in which the service template should be created. |
| template | [DMAServiceTemplate](xref:DMAServiceTemplate) | The service template configuration. |
| extraOptions.AutoUpdateExistingServices | Boolean | Indicates whether existing services generated with the service template should be updated automatically. |

## Output

None.
