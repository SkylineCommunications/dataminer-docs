---
uid: GetUsers
---

# GetUsers

Use this method to retrieve the users configured on a DMA.

## Input

| Item       | Format | Description                                                                      |
|------------|--------|----------------------------------------------------------------------------------|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item           | Format           | Description                                         |
|----------------|------------------|-----------------------------------------------------|
| GetUsersResult | Array of [DMAUser](xref:DMAUser) | An array of DMAUser objects, consisting of the login name, full name, and email address of each user. |
