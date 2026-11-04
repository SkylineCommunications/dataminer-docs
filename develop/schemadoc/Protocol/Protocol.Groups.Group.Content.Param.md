---
uid: Protocol.Groups.Group.Content.Param
description: "Use the Param element under Group Content in a DataMiner protocol to identify a parameter included for consecutive execution."
---

# Param element

Specifies the ID of a parameter to be included in the group.

## Type

[TypeGroupParamId](xref:Protocol-TypeGroupParamId)

## Parent

[Content](xref:Protocol.Groups.Group.Content)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[next](xref:Protocol.Groups.Group.Content.Param-next)|unsignedInt||Specifies the number of milliseconds DataMiner has to wait before reading the next parameter.|

## Examples

```xml
<Param>25</Param>
```
