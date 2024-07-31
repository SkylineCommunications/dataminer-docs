---
uid: EditService
---

# EditService

Use this method to edit a specified service.

## Input

| Item          | Format                  | Description                                                  |
|---------------|-------------------------|--------------------------------------------------------------|
| connection    | String                  | The connection string. See [ConnectApp](xref:ConnectApp).    |
| dmaID         | Integer                 | The DataMiner Agent ID.                                      |
| serviceID     | Integer                 | The service ID.                                              |
| viewIDs       | Array of Integer        | The IDs of the views in which the element should be created. |
| configuration | DMAServiceConfiguration | See [DMAServiceConfiguration](xref:DMAServiceConfiguration). |

## Output

None.
