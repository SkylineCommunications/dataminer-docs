---
uid: GetElementsFromView
---

# GetElementsFromView

Use this method to request a list of all the elements in a specific view.

## Input

| Item            | Format  | Description                                                              |
|-----------------|---------|--------------------------------------------------------------------------|
| Connection      | String  | The connection ID. See [Connect](xref:Connect).                            |
| ViewName        | String  | The view name.                                                           |
| IncludeSubViews | Boolean | If true, then all the elements in the subviews will be returned as well. |

## Output

| Item | Format | Description |
|--|--|--|
| GetElementsFrom­ViewResult | Array of [DMAElement](xref:DMAElement1) | All the elements in the specified view. |
