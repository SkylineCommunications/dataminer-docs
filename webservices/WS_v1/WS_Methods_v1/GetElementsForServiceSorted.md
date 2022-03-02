---
uid: GetElementsForServiceSorted
---

# GetElementsForServiceSorted

Use this method to retrieve a specific number of service child items (elements and/or services).

> [!NOTE]
> Using this method, you can e.g. request service child items in batches in order to minimize loading time.

## Input

| Item            | Format  | Description                                                                                                                                          |
|-----------------|---------|------------------------------------------------------------------------------------------------------------------------------------------------------|
| Connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                                                                 |
| DmaID           | Integer | The DataMiner Agent ID.                                                                                                                              |
| ServiceID       | Integer | The service ID.                                                                                                                                      |
| IncludeServices | Boolean | Whether or not to also include the child services in the specified service.                                                                          |
| StartsWith      | String  | If, in this field, you enter a piece of text, then the method will only return service child items of which the name starts with that piece of text. |
| Index           | Integer | The point from which to start returning child items.                                                                                                 |
| Count           | Integer | The number of child items to be returned.                                                                                                            |
| OrderBy         | String  | The field(s) by which to order the child items (separated by semicolons).                                                                            |

## Output

| Item                               | Format                                                                         | Description                                                       |
|------------------------------------|--------------------------------------------------------------------------------|-------------------------------------------------------------------|
| GetElementsForService­SortedResult | Array of DMAElement (see [DMAElement](xref:DMAElement)) | The requested number of service child items, sorted as specified. |

