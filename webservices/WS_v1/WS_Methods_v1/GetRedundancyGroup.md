---
uid: GetRedundancyGroup
---

# GetRedundancyGroup

Use this method to retrieve the data of a particular redundancy group.

## Input

| Item              | Format  | Description                                                                      |
|-------------------|---------|----------------------------------------------------------------------------------|
| Connection        | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID             | Integer | The DataMiner Agent ID.                                                          |
| RedundancyGroupID | Integer | The redundancy group ID.                                                         |

## Output

| Item | Format | Description |
|--|--|--|
| GetRedundancyGroup­Result | [DMARedundancyGroup](xref:DMARedundancyGroup) | The data of the specified redundancy group. |
