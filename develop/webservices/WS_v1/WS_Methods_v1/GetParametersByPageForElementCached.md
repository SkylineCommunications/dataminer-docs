---
uid: GetParametersByPageForElementCached
---

# GetParametersByPageForElementCached

Use this method to retrieve the data of the parameters on a particular Data Display page of an element added or changed since a particular point in time.

> [!NOTE]
> Using this method, you can e.g. request parameter data in batches in order to minimize loading time.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| pageName | String | The name of the Data Display page. |
| index | Integer | The point from which to start returning parameters. |
| count | Integer | The number of parameters to be returned. |
| orderBy | String | The field(s) by which to order the parameters (separated by semicolons). |
| cacheDateUTC | Long integer | If you enter a timestamp in UTC format (milliseconds since midnight January 1, 1970 GMT), then the method will return only parameters that were added or changed since that particular point in time. If you enter -1, there will be no date check. |

## Output

| Item | Format | Description |
|--|--|--|
| GetParametersByPageForElementCachedResult | [DMACache](xref:DMACache) | The parameters on the specified Data Display page added or changed since the specified point in time. |

> [!NOTE]
> In this case, the [DMACache](xref:DMACache) object will contain an array of [DMAParameter](xref:DMAParameter) objects.
