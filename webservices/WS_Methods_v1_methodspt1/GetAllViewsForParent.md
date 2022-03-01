---
uid: GetAllViewsForParent
---

# GetAllViewsForParent

Use this method to retrieve all views for the specified parent view, including subviews.

## Input

| Item         | Format  | Description                                          |
|--------------|---------|------------------------------------------------------|
| Connection   | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| ParentViewID | Integer | The parent view ID.                                  |

## Output

| Item                        | Format                                                  | Description                                         |
|-----------------------------|---------------------------------------------------------|-----------------------------------------------------|
| GetAllViewsForParent­Result | Array of [DMAView](xref:DMAView) | The data of the views in the specified parent view. |

