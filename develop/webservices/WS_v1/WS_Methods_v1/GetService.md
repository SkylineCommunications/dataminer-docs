---
uid: GetService
---

# GetService

Use this method to retrieve the data of a particular service.

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                               |
| serviceID  | Integer | The service ID.                                       |

## Output

| Item             | Format                        | Description                        |
|------------------|-------------------------------|------------------------------------|
| GetServiceResult | [DMAElement](xref:DMAElement) | The data of the specified service. |
