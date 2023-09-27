---
uid: Protocol.Params.Param.CrossDriverOptions.CrossDriverOption
---

# CrossDriverOption element

Specifies column mappings from a remote protocol to this protocol.

## Parent

[CrossDriverOptions](xref:Protocol.Params.Param.CrossDriverOptions)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[protocol](xref:Protocol.Params.Param.CrossDriverOptions.CrossDriverOption-protocol)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)|Yes|Specifies the name of the protocol.|
|[remoteTablePID](xref:Protocol.Params.Param.CrossDriverOptions.CrossDriverOption-remoteTablePID)|unsignedInt|Yes|Specifies the parameter ID of the remote table.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[PIDTranslation](xref:Protocol.Params.Param.CrossDriverOptions.CrossDriverOption.PIDTranslation)|[1, *]|Maps a column parameter ID from the remote protocol to this protocol.|
