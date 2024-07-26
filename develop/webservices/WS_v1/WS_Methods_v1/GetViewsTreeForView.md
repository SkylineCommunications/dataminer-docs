---
uid: GetViewsTreeForView
---

# GetViewsTreeForView

Use this method to retrieve the view hierarchy of a particular view.

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID     | Integer | The view ID.                                          |

## Output

| Item                | Format                           | Description                               |
|---------------------|----------------------------------|-------------------------------------------|
| GetViewsTreeForView | Array of [DMAView](xref:DMAView) | The view hierarchy of the specified view. |
