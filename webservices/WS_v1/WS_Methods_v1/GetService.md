---
uid: GetService
---

# GetService

Use this method to retrieve the data of a particular service.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ServiceID  | Integer | The service ID.                                                                  |

## Output

| Item             | Format                                               | Description                        |
|------------------|------------------------------------------------------|------------------------------------|
| GetServiceResult | [DMAElement](xref:DMAElement) | The data of the specified service. |

