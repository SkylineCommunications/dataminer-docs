---
uid: Protocol.HTTP.Session.Connection.Request.Data
---

# Data element

Specifies the request data.

## Type

string

## Parent

[Request](xref:Protocol.HTTP.Session.Connection.Request)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[pid](xref:Protocol.HTTP.Session.Connection.Request.Data-pid)|unsignedInt||Specifies the ID of the parameter that holds the data to be sent.|

## Remarks

> [!IMPORTANT]
> DataMiner does not perform any encoding on the provided data. Therefore, if you are, for example, building a URL for a GET request with a query string or the body of a POST request with content type "application/x-www-form-urlencoded", you must ensure that the data is using [percent-encoding](https://datatracker.ietf.org/doc/html/rfc3986#section-2.1) (also known as URL encoding) to avoid misinterpretation of the provided data. Otherwise, the provided data might be misinterpreted by the server in case the data contains characters from the [reserved character set](https://datatracker.ietf.org/doc/html/rfc3986#section-2.2) (e.g., '&amp;').
