---
uid: GetViewsForParentCached
---

# GetViewsForParentCached

Use this method to retrieve the views in a particular parent view added or changed since a particular point in time.

> [!NOTE]
> Using this method, you can e.g. request views in batches in order to minimize loading time.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ParentViewID | Integer | The parent view ID. |
| Index | Integer | The point from which to start returning views. |
| Count | Integer | The number of views to be returned. |
| OrderBy | String | The field(s) by which to order the views (separated by semicolons). |
| CacheDateUTC | Long integer | If you enter a timestamp in UTC format (milliseconds since midnight January 1, 1970 GMT), then the method will return only views that were added or changed since that particular point in time. If you enter -1, there will be no date check. |

## Output

| Item | Format | Description |
|--|--|--|
| GetViewsForParent­CachedResult | [DMACache](xref:DMACache) | The views added or changed since the specified point in time. |

> [!NOTE]
> In this case, the [DMACache](xref:DMACache) object will contain an array of [DMAView](xref:DMAView) objects.
