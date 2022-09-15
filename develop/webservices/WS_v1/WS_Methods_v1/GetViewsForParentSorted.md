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
| connection   | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| parentViewID | Integer | The parent view ID.                                                              |
| index        | Integer | The point from which to start returning views.                                   |
| count        | Integer | The number of views to be returned.                                              |
| orderBy      | String  | The field(s) by which to order the views (separated by semicolons).              |

## Output

| Item | Format | Description |
|--|--|--|
| GetViewsForParentSortedResult | Array of [DMAView](xref:DMAView) | The requested number of subviews, sorted as specified. |
