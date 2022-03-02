---
uid: GetRedundancyGroupsForView
---

# GetRedundancyGroupsForView

Use this method to retrieve all the redundancy groups for a particular view.

## Input

| Item            | Format  | Description                                                                      |
|-----------------|---------|----------------------------------------------------------------------------------|
| Connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ViewID          | Integer | The view ID.                                                                     |
| IncludeSubViews | Boolean | Indicates whether redundancy groups from subviews are included.                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetRedundancyGroups­ForViewResult | Array of [DMARedundancyGroup](xref:DMARedundancyGroup) | The redundancy groups of the specified view. |
