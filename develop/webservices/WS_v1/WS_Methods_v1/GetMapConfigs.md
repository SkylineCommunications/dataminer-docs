---
uid: GetMapConfigs
---

# GetMapConfigs

Use this method to retrieve all map configurations available in the system.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetMapConfigsResult | Array of [DMAMapConfigLite](xref:DMAMapConfigLite) | The map configurations with the corresponding map parameters. |
