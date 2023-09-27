---
uid: GetRedundancyGroupsForView
---

# GetRedundancyGroupsForView

Use this method to retrieve all the redundancy groups for a particular view.

## Input

| Item            | Format  | Description                                                                      |
|-----------------|---------|----------------------------------------------------------------------------------|
| connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID          | Integer | The view ID.                                                                     |
| includeSubViews | Boolean | Indicates whether redundancy groups from subviews are included.                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetRedundancyGroupsForViewResult | Array of [DMARedundancyGroup](xref:DMARedundancyGroup) | The redundancy groups of the specified view. |
