---
uid: Protocol.Groups.Group.Content.Trigger
---

# Trigger element

Specifies the ID of a trigger to be included in the group.

## Type

[TypeObjectId](xref:Protocol-TypeObjectId)

## Parent

[Content](xref:Protocol.Groups.Group.Content)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[next](xref:Protocol.Groups.Group.Content.Trigger-next)|unsignedInt||Specifies the number of milliseconds DataMiner has to wait before executing the next trigger.|

## Remarks

> [!NOTE]
> If you include triggers in a group, do not forget to set the value of the "type" attribute of this group to “trigger”.

## Examples

```xml
<Trigger next="5000">25</Trigger>
```
