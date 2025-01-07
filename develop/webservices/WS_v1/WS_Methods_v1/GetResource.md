---
uid: GetResource
---

# GetResource

Use this method to retrieve a specific resource.

## Input

| Item       | Format | Description                                           |
|------------|--------|-------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| resourceID | String | The resource ID.                                      |

## Output

| Item              | Format                          | Description             |
|-------------------|---------------------------------|-------------------------|
| GetResourceResult | [DMAResource](xref:DMAResource) | The requested resource. |
