---
uid: GetElementIndexPageForService
---

# GetElementIndexPageForService

Use this method to retrieve the first letters of all the elements in a service.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                              |
| serviceID  | Integer | The service ID.                                      |

## Output

| Item                                 | Format          | Description                                                     |
|--------------------------------------|-----------------|-----------------------------------------------------------------|
| GetElementIndexPageForServiceResult | Array of string | The first letters of all the elements in the specified service. |
