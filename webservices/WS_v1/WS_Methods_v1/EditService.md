---
uid: EditService
---

# EditService

Use this method to edit a specified service.

## Input

| Item          | Format                   | Description                                                                         |
|---------------|--------------------------|-------------------------------------------------------------------------------------|
| Connection    | String                   | The connection string. See [ConnectApp](xref:ConnectApp).                           |
| DmaID         | Integer                  | The DataMiner Agent ID.                                                             |
| ServiceID     | Integer                  | The service ID.                                                                     |
| ViewIDs       | Array of Integer         | The IDs of the views in which the element should be created.                        |
| Configuration | DMAServiceConfiguration | See [DMAServiceConfiguration](xref:DMAServiceConfiguration). |

## Output

None.
