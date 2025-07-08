---
uid: Protocol.HTTP.Session.Connection.Request.Parameters.Parameter
---

# Parameter element

Specifies a parameter of which you want its content to be included in the HTTP request.

## Type

string

## Parent

[Parameters](xref:Protocol.HTTP.Session.Connection.Request.Parameters)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[key](xref:Protocol.HTTP.Session.Connection.Request.Parameters.Parameter-key)|string|Yes|Specifies the key of the key/value pair.|
|[pid](xref:Protocol.HTTP.Session.Connection.Request.Parameters.Parameter-pid)|unsignedInt||Specifies the ID of the parameter that contains the value to be sent.|

## Remarks

Via HTTP, this has to be done by means of key/value pairs.

Contains a string that specifies the value of the parameter.

> [!NOTE]
> When you provide the value to be sent through the PID of a parameter, that parameter needs to be of type `string`.

> [!IMPORTANT]
> DataMiner does not perform any encoding on the provided data. Therefore, if you are, for example, building a URL for a GET request with a query string or the body of a POST request with content type "application/x-www-form-urlencoded", you must ensure that the data is using [percent-encoding](https://datatracker.ietf.org/doc/html/rfc3986#section-2.1) (also known as URL encoding) to avoid misinterpretation of the provided data. Otherwise, the provided data might be misinterpreted by the server in case the data contains characters from the [reserved character set](https://datatracker.ietf.org/doc/html/rfc3986#section-2.2) (e.g. '&amp;').

## Examples

In the following example, the value can be found in parameter 215:

```xml
<Parameter key="iex" pid="215" />
```

In the following example, we use a fixed value “foobar”:

```xml
<Parameter key="iex">foobar</Parameter>
```
