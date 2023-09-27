---
uid: GetRedundancyGroup
---

# GetRedundancyGroup

Use this method to retrieve the data of a particular redundancy group.

## Input

| Item              | Format  | Description                                                                      |
|-------------------|---------|----------------------------------------------------------------------------------|
| connection        | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID             | Integer | The DataMiner Agent ID.                                                          |
| redundancyGroupID | Integer | The redundancy group ID.                                                         |

## Output

| Item | Format | Description |
|--|--|--|
| GetRedundancyGroupResult | [DMARedundancyGroup](xref:DMARedundancyGroup) | The data of the specified redundancy group. |
