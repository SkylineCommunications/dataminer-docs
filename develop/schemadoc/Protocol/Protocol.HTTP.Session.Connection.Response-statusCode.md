---
metadata_version: 1
uid: Protocol.HTTP.Session.Connection.Response-statusCode
description: "Learn how to use the statusCode attribute to store the HTTP response status line in the specified parameter in a DataMiner connector protocol."
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


