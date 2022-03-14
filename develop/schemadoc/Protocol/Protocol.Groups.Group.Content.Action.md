---
uid: Protocol.Groups.Group.Content.Action
---

# Action element

Specifies the ID of an action to include in the group.

## Type

[TypeObjectId](xref:Protocol-TypeObjectId)

## Parent

[Content](xref:Protocol.Groups.Group.Content)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[next](xref:Protocol.Groups.Group.Content.Action-next)|unsignedInt||Specifies the number of milliseconds DataMiner has to wait after having received the response of the last executed action before executing the next action.|

## Remarks

> [!NOTE]
> If you include actions in a group, do not forget to set the "type" attribute of the Group element to “action”.
