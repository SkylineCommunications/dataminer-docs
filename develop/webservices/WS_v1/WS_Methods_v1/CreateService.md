---
uid: CreateService
---

# CreateService

Use this method to create a new service on a specified DataMiner Agent.

## Input

| Item          | Format                   | Description                                                  |
|---------------|--------------------------|--------------------------------------------------------------|
| connection    | String                   | The connection string. See [ConnectApp](xref:ConnectApp).    |
| dmaID         | Integer                  | The DataMiner Agent ID.                                      |
| viewIDs       | Array of Integer         | The IDs of the views in which the element should be created. |
| configuration | DMAServiceConfiguration | See [DMAServiceConfiguration](xref:DMAServiceConfiguration).  |

## Output

| Item                | Format          | Description                                         |
|---------------------|-----------------|-----------------------------------------------------|
| CreateServiceResult | Array of string | The DataMiner ID and service ID of the new service. |
