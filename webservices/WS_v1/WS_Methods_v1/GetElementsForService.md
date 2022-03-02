---
uid: GetElementsForService
---

# GetElementsForService

Use this method to retrieve the list of all child items (elements and/or services) of a particular service.

## Input

| Item            | Format  | Description                                                                 |
|-----------------|---------|-----------------------------------------------------------------------------|
| Connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp) .                        |
| DmaID           | Integer | The DataMiner Agent ID.                                                     |
| ServiceID       | Integer | The service ID.                                                             |
| IncludeServices | Boolean | Whether or not to also include the child services in the specified service. |

## Output

| Item                         | Format                                                                         | Description                                               |
|------------------------------|--------------------------------------------------------------------------------|-----------------------------------------------------------|
| GetElementsForService­Result | Array of DMAElement (see [DMAElement](xref:DMAElement)) | The list of all the child items of the specified service. |

