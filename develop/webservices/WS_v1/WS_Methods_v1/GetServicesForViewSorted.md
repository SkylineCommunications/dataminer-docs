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
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ViewID | Integer | The view ID. |
| IncludeSubViews | boolean | Indicates whether subviews should be included. |
| StartsWith | String | If, in this field, you enter a piece of text, then the method will only return services of which the name starts with that piece of text. |
| Query | String | If, in this field, you enter a piece of text, then the method will only return services of which the name contains that piece of text. |
| Index | Integer | The point from which to start returning services. |
| Count | Integer | The number of services to be returned. |
| OrderBy | String | The field(s) by which to order the services (separated by semicolons). |

## Output

| Item | Format | Description |
|--|--|--|
| GetServicesForView­SortedResult | Array of [DMAElement](xref:DMAElement) | The services from the specified view, sorted as requested. |
