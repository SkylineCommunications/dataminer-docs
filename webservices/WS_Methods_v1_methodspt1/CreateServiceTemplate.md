---
uid: CreateServiceTemplate
---

# CreateServiceTemplate

Use this method to create a new service template. Available from DataMiner 10.2.1/10.3.0 onwards.

## Input

| Item                                     | Format          | Description                                                                                                   |
|------------------------------------------|-----------------|---------------------------------------------------------------------------------------------------------------|
| Connection                               | String          | The connection string. See [ConnectApp](xref:ConnectApp) .                                                      |
| DmaID                                    | Integer         | The DataMiner Agent ID.                                                                                       |
| ViewIDs                                  | Array of string | The IDs of the views in which the service template should be created.                                         |
| Template                                 | Array           | The service template configuration. See [DMAServiceTemplate](xref:DMAServiceTemplate). |
| ExtraOptions.AutoUp­dateExistingServices | Boolean         | Indicates whether existing services generated with the service template should be updated automatically.      |

## Output

None.

