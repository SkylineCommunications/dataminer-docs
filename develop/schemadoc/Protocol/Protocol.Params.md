---
uid: Protocol.Params
---

# Params element

Contains all the parameters defined in the protocol.

## Parent

[Protocol](xref:Protocol)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[loadSequence](xref:Protocol.Params-loadSequence)|string||Changes the order in which saved parameter data is retrieved when the element starts up.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Param](xref:Protocol.Params.Param)|[0, *]|Defines a parameter.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID of a parameter must be unique. |Param |@id |
|Unique |The combination of Type and Name of a parameter must be unique. |Param |dis:Name, dis:Type |
