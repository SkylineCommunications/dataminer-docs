---
uid: GetElementsForService
---

# GetElementsForService

Use this method to retrieve the list of all child items (elements and/or services) of a particular service.

## Input

| Item            | Format  | Description                                                                 |
|-----------------|---------|-----------------------------------------------------------------------------|
| connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp).                        |
| dmaID           | Integer | The DataMiner Agent ID.                                                     |
| serviceID       | Integer | The service ID.                                                             |
| includeServices | Boolean | Whether child services should be included in the specified service. |

## Output

| Item | Format | Description |
|--|--|--|
| GetElementsForServiceResult | Array of [DMAElement](xref:DMAElement) | The list of all the child items of the specified service. |
