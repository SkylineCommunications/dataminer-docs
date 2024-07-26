---
uid: GetUserGroups
---

# GetUserGroups

Use this method to retrieve the user groups containing the current user.

## Input

| Item       | Format | Description                                           |
|------------|--------|-------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetUserGroupsResult | Array of [DMAUserGroup](xref:DMAUserGroup) | A DMAUserGroup object for each of the groups containing the current user, consisting of the ID and name of the group. |
