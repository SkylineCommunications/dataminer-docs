---
uid: GetViewsForParent
---

# GetViewsForParent

Use this method to retrieve all the views in a particular parent view.

## Input

| Item         | Format  | Description                                                                      |
|--------------|---------|----------------------------------------------------------------------------------|
| Connection   | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ParentViewID | Integer | The parent view ID.                                                              |

## Output

| Item | Format | Description |
|--|--|--|
| GetViewsForParent­Result | Array of [DMAView](xref:DMAView) | The list of all the views in the specified parent view. |
