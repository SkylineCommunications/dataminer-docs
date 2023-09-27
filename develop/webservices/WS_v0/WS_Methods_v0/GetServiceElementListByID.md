---
uid: GetServiceElementListByID
---

# GetServiceElementListByID

Use this method to request a list of all the elements and services in a specific service (referenced by ID).

## Input

| Item       | Format  | Description                                   |
|------------|---------|-----------------------------------------------|
| connection | String  | The connection ID. See [Connect](xref:Connect). |
| DmaID      | Integer | The DataMiner Agent ID.                       |
| ServiceID  | Integer | The service ID.                               |

## Output

| Item | Format | Description |
|--|--|--|
| GetServiceElementListByIDResult | Array of [DMAElement](xref:DMAElement1) | The elements and services in the specified service. |
