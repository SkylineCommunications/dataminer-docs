---
uid: GetSecurityInfo
---

# GetSecurityInfo

Use this method to retrieve the permissions granted to the current user account.

## Input

| Item       | Format | Description                                           |
|------------|--------|-------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetSecurityInfoResult | [DMASecurity](xref:DMASecurity) | The list of permissions granted to the current user account. |
