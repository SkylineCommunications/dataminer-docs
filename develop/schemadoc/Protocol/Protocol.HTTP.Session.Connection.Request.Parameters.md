---
uid: Protocol.HTTP.Session.Connection.Request.Parameters
---

# Parameters element

Specifies request parameters.

## Parent

[Request](xref:Protocol.HTTP.Session.Connection.Request)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Parameter](xref:Protocol.HTTP.Session.Connection.Request.Parameters.Parameter)|[1, *]|Specifies a parameter of which you want its content to be included in the HTTP request.|

## Remarks

If you do not want to specify a fixed block of data in the Data tag, but rather a number of parameters containing the data to be sent, then use this tag to define the list of parameters of which you want the contents to be sent in the HTTP request.

> [!NOTE]
> From DataMiner 10.1.0 \[CU18]/10.2.0 \[CU6]/10.2.9 (RN33796) onwards, the order of the parameters will be consistent in the packet itself. Prior to this change, the order observed via Wireshark could be different.
