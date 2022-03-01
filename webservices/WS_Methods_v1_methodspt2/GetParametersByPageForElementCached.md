---
uid: GetParametersByPageForElementCached
---

# GetParametersByPageForElementCached

Use this method to retrieve the data of the parameters on a particular Data Display page of an element added or changed since a particular point in time.

> [!NOTE]
> Using this method, you can e.g. request parameter data in batches in order to minimize loading time.

## Input

| Item         | Format       | Description                                                                                                                                                                                                                                             |
|--------------|--------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Connection   | String       | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                                                                                                                                        |
| DmaID        | Integer      | The DataMiner Agent ID.                                                                                                                                                                                                                                 |
| ElementID    | Integer      | The element ID.                                                                                                                                                                                                                                         |
| PageName     | String       | The name of the Data Display page.                                                                                                                                                                                                                      |
| Index        | Integer      | The point from which to start returning parameters.                                                                                                                                                                                                     |
| Count        | Integer      | The number of parameters to be returned.                                                                                                                                                                                                                |
| OrderBy      | String       | The field(s) by which to order the parameters (separated by semicolons).                                                                                                                                                                                |
| CacheDateUTC | Long integer | If you enter a timestamp in UTC format (milliseconds since midnight January 1, 1970 GMT), then the method will return only parameters that were added or changed since that particular point in time.<br> If you enter -1, there will be no date check. |

## Output

| Item                                       | Format                                           | Description                                                                                           |
|--------------------------------------------|--------------------------------------------------|-------------------------------------------------------------------------------------------------------|
| GetParametersByPage­ForElementCachedResult | [DMACache](xref:DMACache) | The parameters on the specified Data Display page added or changed since the specified point in time. |

> [!NOTE]
> In this case, the DMACache object (see [DMACache](xref:DMACache)) will contain an array of DMAParameter objects (see [DMAParameter](xref:DMAParameter)).

