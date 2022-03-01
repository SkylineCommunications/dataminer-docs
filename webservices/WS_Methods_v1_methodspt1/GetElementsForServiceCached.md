---
uid: GetElementsForServiceCached
---

# GetElementsForServiceCached

Use this method to retrieve only service child items (elements and/or services) added or changed since a particular point in time.

> [!NOTE]
> Using this method, you can e.g. request service child items in batches in order to minimize loading time.

## Input

| Item            | Format       | Description                                                                                                                                                                                                                                                      |
|-----------------|--------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Connection      | String       | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                                                                                                                                                                             |
| DmaID           | Integer      | The DataMiner Agent ID.                                                                                                                                                                                                                                          |
| ServiceID       | Integer      | The service ID.                                                                                                                                                                                                                                                  |
| IncludeServices | Boolean      | Whether or not to also include the child services in the specified service.                                                                                                                                                                                      |
| Index           | Integer      | The point from which to start returning child items.                                                                                                                                                                                                             |
| Count           | Integer      | The number of child items to be returned.                                                                                                                                                                                                                        |
| OrderBy         | String       | The field(s) by which to order the child items (separated by semicolons).                                                                                                                                                                                        |
| CacheDateUTC    | Long integer | If you enter a timestamp in UTC format (milliseconds since midnight January 1, 1970 GMT), then the method will return only service child items that were added or changed since that particular point in time.<br> If you enter -1, there will be no date check. |

## Output

| Item                               | Format                                           | Description                                                                                            |
|------------------------------------|--------------------------------------------------|--------------------------------------------------------------------------------------------------------|
| GetElementsForService­CachedResult | [DMACache](xref:DMACache) | The service child items (elements and/or services) added or changed since the specified point in time. |

> [!NOTE]
> In this case, the DMACache object (see [DMACache](xref:DMACache)) will contain an array of DMAElement objects (see [DMAElement](xref:DMAElement)).

