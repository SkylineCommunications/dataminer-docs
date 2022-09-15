---
uid: GetViewsForParent
---

# GetViewsForParent

Use this method to retrieve all the views in a particular parent view.

## Input

| Item         | Format  | Description                                                                      |
|--------------|---------|----------------------------------------------------------------------------------|
| connection   | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| parentViewID | Integer | The parent view ID.                                                              |

## Output

| Item | Format | Description |
|--|--|--|
| GetViewsForParentResult | Array of [DMAView](xref:DMAView) | The list of all the views in the specified parent view. |
