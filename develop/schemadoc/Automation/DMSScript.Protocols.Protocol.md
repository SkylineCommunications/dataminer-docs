---
uid: DMSScript.Protocols.Protocol
---

# Protocol element

Defines a dummy script variable.

## Parent

[Protocols](xref:DMSScript.Protocols)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:DMSScript.Protocols.Protocol-id)|positiveInteger|Yes|Specifies the unique ID of the dummy script variable.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Sequence***|||
|&nbsp;&nbsp;[Description](xref:DMSScript.Protocols.Protocol.Description)||Specifies the name of the dummy variable.|
|&nbsp;&nbsp;[Name](xref:DMSScript.Protocols.Protocol.Name)||Specifies the name of the protocol.|
|&nbsp;&nbsp;[Version](xref:DMSScript.Protocols.Protocol.Version)||Specifies the version of the protocol.|
|&nbsp;&nbsp;[DefaultElement](xref:DMSScript.Protocols.Protocol.DefaultElement)||Specifies the default element. Format: "Agent ID/Element ID" (e.g., 200/160).|

## Remarks

When the script is run, an actual element will be linked to each dummy.
