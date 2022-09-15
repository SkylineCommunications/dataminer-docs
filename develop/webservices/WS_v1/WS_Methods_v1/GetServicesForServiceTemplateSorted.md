---
uid: GetServicesForServiceTemplateSorted
---

# GetServicesForServiceTemplateSorted

Use this method to retrieve a specific number of services attached to a specified service template.

> [!NOTE]
> Using this method, you can e.g. request services in batches in order to minimize loading time.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| serviceTemplateID | Integer | The ID of the service template. |
| startsWith | String | If, in this field, you enter a piece of text, then the method will only return services of which the name starts with that piece of text. |
| query | String | If, in this field, you enter a piece of text, then the method will only return services of which the name contains that piece of text. |
| index | Integer | The point from which to start returning services. |
| count | Integer | The number of services to be returned. |
| orderBy | String | The field(s) by which to order the services (separated by semicolons). |

## Output

| Item | Format | Description |
|--|--|--|
| GetServicesForServiceTemplateSortedResult | Array of [DMAElement](xref:DMAElement) | The services attached to the specified service template, sorted as requested. |
