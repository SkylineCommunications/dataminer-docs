---
uid: GetServiceByName
---

# GetServiceByName

Use this method to retrieve the data of a particular service by name.

## Input

| Item        | Format | Description                                           |
|-------------|--------|-------------------------------------------------------|
| connection  | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| serviceName | String | The service name.                                     |

## Output

| Item                   | Format                        | Description                        |
|------------------------|-------------------------------|------------------------------------|
| GetServiceByNameResult | [DMAElement](xref:DMAElement) | The data of the specified service. |
