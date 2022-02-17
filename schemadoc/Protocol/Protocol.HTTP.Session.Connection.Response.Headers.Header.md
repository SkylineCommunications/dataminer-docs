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

In this context, this has to be done by means of a key/value pair.


