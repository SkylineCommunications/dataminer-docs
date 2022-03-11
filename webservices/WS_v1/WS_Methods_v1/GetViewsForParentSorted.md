---
uid: GetViewsForParentSorted
---

# GetViewsForParentSorted

Use this method to retrieve a specific number of subviews from a particular view.

> [!NOTE]
> Using this method, you can e.g. request views in batches in order to minimize loading time.

## Input

| Item         | Format  | Description                                                                      |
|--------------|---------|----------------------------------------------------------------------------------|
| Connection   | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ParentViewID | Integer | The parent view ID.                                                              |
| Index        | Integer | The point from which to start returning views.                                   |
| Count        | Integer | The number of views to be returned.                                              |
| OrderBy      | String  | The field(s) by which to order the views (separated by semicolons).              |

## Output

| Item | Format | Description |
|--|--|--|
| GetViewsForParent­SortedResult | Array of [DMAView](xref:DMAView) | The requested number of subviews, sorted as specified. |
