---
uid: GetElementsForServiceCount
---

# GetElementsForServiceCount

Use this method to count the number of child items (elements and/or services) in a particular service.

## Input

| Item            | Format  | Description                                                                 |
|-----------------|---------|-----------------------------------------------------------------------------|
| connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp).                        |
| dmaID           | Integer | The DataMiner Agent ID.                                                     |
| serviceID       | Integer | The service ID.                                                             |
| includeServices | Boolean | Whether child services of the specified service should be included. |

## Output

| Item                              | Format  | Description                                         |
|-----------------------------------|---------|-----------------------------------------------------|
| GetElementsForServiceCountResult | Integer | The number of child items in the specified service. |
