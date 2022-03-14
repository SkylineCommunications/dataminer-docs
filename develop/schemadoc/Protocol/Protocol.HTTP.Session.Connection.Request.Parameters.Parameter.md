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



## Examples

In the following example, the value can be found in parameter 215:


```xml
<Parameter key="iex" pid="215" />
```


In the following example, we use a fixed value “foobar”:


```xml
<Parameter key="iex">foobar</Parameter>
```



