---
uid: GetAllRedundancyGroupsSorted
---

# GetAllRedundancyGroupsSorted

Use this method to retrieve a specific number of redundancy groups.

> [!NOTE]
> Using this method, you can e.g. request redundancy groups in batches in order to minimize loading time.

## Input

| Item       | Format  | Description                                                                     |
|------------|---------|---------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp).                           |
| Index      | Integer | The point from which to start returning redundancy groups.                      |
| Count      | Integer | The number of redundancy groups to be returned.                                 |
| OrderBy    | String  | The field(s) by which to order the redundancy groups (separated by semicolons). |

## Output

| Item | Format | Description |
|--|--|--|
| GetAllRedundancy­GroupsSortedResult | Array of [DMARedundancyGroup](xref:DMARedundancyGroup) | The redundancy groups, sorted as requested. |
