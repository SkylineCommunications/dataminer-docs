---
uid: Protocol.HTTP.Session.Connection.Response-statusCode
---

# statusCode attribute

Specifies the ID of the parameter in which the HTTP status-line has to be stored.

## Content Type

unsignedInt

## Parent

[Response](xref:Protocol.HTTP.Session.Connection.Response)

## Remarks

The status line is formatted as follows ([RFC 7230](https://tools.ietf.org/html/rfc7230#section-3.1.2)):


```none
status-line = HTTP-version SP status-code SP reason-phrase CRLF
```


, where SP represents a space and CRLF carriage return line feed.

Example: "HTTP/1.1 200 OK"


