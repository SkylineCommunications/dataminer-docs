---
uid: GetServicesForViewSorted
---

# GetServicesForViewSorted

Use this method to retrieve the data of a number of services in a particular view.

> [!NOTE]
> Using this method, you can e.g. request services in batches in order to minimize loading time.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID | Integer | The view ID. |
| includeSubViews | boolean | Indicates whether subviews should be included. |
| startsWith | String | If, in this field, you enter a piece of text, then the method will only return services of which the name starts with that piece of text. |
| query | String | If, in this field, you enter a piece of text, then the method will only return services of which the name contains that piece of text. |
| index | Integer | The point from which to start returning services. |
| count | Integer | The number of services to be returned. |
| orderBy | String | The field(s) by which to order the services (separated by semicolons). |

## Output

| Item | Format | Description |
|--|--|--|
| GetServicesForViewSortedResult | Array of [DMAElement](xref:DMAElement) | The services from the specified view, sorted as requested. |
