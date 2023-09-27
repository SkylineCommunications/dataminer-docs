---
uid: GetServiceElementListByName
---

# GetServiceElementListByName

Use this method to request a list of all the elements and services in a specific service (referenced by name).

## Input

| Item        | Format | Description                                   |
|-------------|--------|-----------------------------------------------|
| connection  | String | The connection ID. See [Connect](xref:Connect). |
| ServiceName | String | The service name.                             |

## Output

| Item | Format | Description |
|--|--|--|
| GetServiceElementListByNameResult | Array of [DMAElement](xref:DMAElement1) | The elements and services in the specified service. |
