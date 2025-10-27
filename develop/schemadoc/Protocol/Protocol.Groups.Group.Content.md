---
uid: Protocol.Groups.Group.Content
---

# Content element

Contains the items that have to be executed consecutively when the group is executed.

## Parent

[Group](xref:Protocol.Groups.Group)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[multipleGet](xref:Protocol.Groups.Group.Content-multipleGet)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||If "true", all parameters will be read in one SNMP Get operation.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***choice***|||
|&nbsp;&nbsp;[Action](xref:Protocol.Groups.Group.Content.Action)|[0, *]|Specifies the ID of an action to include in the group.|
|&nbsp;&nbsp;[Pair](xref:Protocol.Groups.Group.Content.Pair)|[0, *]|Specifies the ID of a command/response pair to be included in the 
|&nbsp;&nbsp;[Param](xref:Protocol.Groups.Group.Content.Param)|[0, *]|Specifies the ID of a parameter to be included in the group.|
|&nbsp;&nbsp;[Session](xref:Protocol.Groups.Group.Content.Session)|[0, *]|Specifies the ID of an HTTP session to be included in the group.|
|&nbsp;&nbsp;[Trigger](xref:Protocol.Groups.Group.Content.Trigger)|[0, *]|Specifies the ID of a trigger to be included in the group.|

## Remarks

The content of a group has to consist of items the same type.

- action items only
- pair items only
- parameter items only
- session items only
- trigger items only

> [!TIP]
> Do not include more than 10 parameters, pairs, actions or triggers in one Protocol.Groups.Group.Content tag.

> [!IMPORTANT]
> Depending on the content type, the behavior regarding when the polling request/command is built might differ:
>
> - For serial, see [makeCommandByProtocol](xref:ConnectionsSerialCreatingCommandsAndResponses#makecommandbyprotocol).
> - For HTTP, the requests will be built and buffered when the group is added to the SLProtocol queue. This means that if some request parameters are updated by the time the group gets executed, the sent request will still contain the values from when the group was added to the queue, avoiding race condition issues.
