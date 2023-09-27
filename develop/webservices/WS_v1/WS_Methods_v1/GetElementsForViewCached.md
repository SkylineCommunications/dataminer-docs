---
uid: GetElementsForViewCached
---

# GetElementsForViewCached

Use this method to retrieve only view child items (elements and/or services) added or changed since a particular point in time.

> [!NOTE]
> Using this method, you can e.g. request service child items in batches in order to minimize loading time.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID | Integer | The view ID. |
| includeSubViews | Boolean | Whether child items found in subviews should be included. |
| includeServices | Boolean | Whether the services in the specified view should be included. |
| index | Integer | The point from which to start returning child items. |
| count | Integer | The number of child items to be returned. |
| orderBy | String | The field(s) by which to order the child items (separated by semicolons). |
| cacheDateUTC | Long integer | If you enter a timestamp in UTC format (milliseconds since midnight January 1, 1970 GMT), then the method will return only child items that were added or changed since that particular point in time. If you enter -1, there will be no date check. |

## Output

| Item | Format | Description |
|--|--|--|
| GetElementsForViewCachedResult | [DMACache](xref:DMACache) | The view child items (elements and/or services) added or changed since the specified point in time. |

> [!NOTE]
> In this case, the [DMACache](xref:DMACache) object will contain an array of [DMAElement](xref:DMAElement) objects.
