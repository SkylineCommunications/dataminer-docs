---
uid: GetServices
---

# GetServices

Use this method to request a list of all the services in the DMS.

## Input

| Item       | Format | Description                                   |
|------------|--------|-----------------------------------------------|
| Connection | String | The connection ID. See [Connect](xref:Connect). |

## Output

| Item | Format | Description |
|--|--|--|
| GetServicesResult | Array of [DMAElement](xref:DMAElement1) | All the services in the DMS. |
