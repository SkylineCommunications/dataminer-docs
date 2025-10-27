---
uid: Protocol.HTTP.Session.Connection.Response.Headers.Header
---

# Header element

Specifies that the contents of a particular response header has to be stored in a parameter.

## Parent

[Headers](xref:Protocol.HTTP.Session.Connection.Response.Headers)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[key](xref:Protocol.HTTP.Session.Connection.Response.Headers.Header-key)|[HttpResponseHeader](xref:Protocol-HttpResponseHeader)|Yes|Specifies the name of the header of which you want the contents to be stored in the parameter having the ID defined in the pid attribute.|
|[pid](xref:Protocol.HTTP.Session.Connection.Response.Headers.Header-pid)|unsignedInt|Yes|Specifies the ID of the parameter in which you want to store the contents of the header defined in the key attribute.|

## Remarks

In case the HTTP response contains multiple headers with the same key, the specified parameter will contain the combined value of all these headers, with each header value separated by `\r\n`.

For example, suppose the following response header is configured in the protocol:

```xml
<Header key="X-Custom" pid="30" />
```

Assuming the response contains the following headers:

```
X-Custom: A
X-Custom: B
```

As a result, parameter 30 will contain the following value: `A\r\nB`.
