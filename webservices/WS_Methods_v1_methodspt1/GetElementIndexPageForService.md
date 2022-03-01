---
uid: GetElementIndexPageForService
---

# GetElementIndexPageForService

Use this method to retrieve the first letters of all the elements in a service.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                              |
| ServiceID  | Integer | The service ID.                                      |

## Output

| Item                                 | Format          | Description                                                     |
|--------------------------------------|-----------------|-----------------------------------------------------------------|
| GetElementIndexPage­ForServiceResult | Array of string | The first letters of all the elements in the specified service. |

