---
uid: GetElementsForServiceCount
---

# GetElementsForServiceCount

Use this method to count the number of child items (elements and/or services) in a particular service.

## Input

| Item            | Format  | Description                                                                 |
|-----------------|---------|-----------------------------------------------------------------------------|
| Connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp).                        |
| DmaID           | Integer | The DataMiner Agent ID.                                                     |
| ServiceID       | Integer | The service ID.                                                             |
| IncludeServices | Boolean | Whether child services of the specified service should be included. |

## Output

| Item                              | Format  | Description                                         |
|-----------------------------------|---------|-----------------------------------------------------|
| GetElementsForSer­viceCountResult | Integer | The number of child items in the specified service. |
