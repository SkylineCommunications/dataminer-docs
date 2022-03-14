---
uid: Protocol.HTTP.Session.Connection.Request-url
---

# url attribute

Specifies the URL of the request.

## Content Type

string

## Parent

[Request](xref:Protocol.HTTP.Session.Connection.Request)

## Remarks

If you do not specify this attribute, the root directory of the server specified in the element wizard will be used.

> [!NOTE]
>
> - If the specified value for the url attribute does not contain "://", then it is assumed that the provided value is a relative URL, and the URL will be constructed using the polling IP and port of the corresponding connection.
> - Prior to DataMiner 9.6.11, the maximum length of the URL path is restricted to about 1300 characters. From DataMiner 9.6.11 (RN 23115) onwards, no restriction is applicable to the length of the URL path.

## Examples

```xml
<Request verb="DELETE" url="/foobar.html">
```
