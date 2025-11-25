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
> - If the specified value for the *url* attribute does not contain `://`, it is assumed that the provided value is a relative URL, and the URL will be constructed using the polling IP and port of the corresponding connection.
> - No restrictions apply to the length of the URL path. <!-- RN 23115 -->

## Examples

```xml
<Request verb="DELETE" url="/foobar.html">
```
