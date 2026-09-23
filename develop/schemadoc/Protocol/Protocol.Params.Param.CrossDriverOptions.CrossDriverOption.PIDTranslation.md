---
metadata_version: 1
uid: Protocol.Params.Param.CrossDriverOptions.CrossDriverOption.PIDTranslation
description: "Reference the DataMiner connector protocol schema entry for PIDTranslation element, including its documented structure, attributes, values, and constraint."
---

# PIDTranslation element

Maps a column parameter ID from the remote protocol to this protocol.

## Parent

[CrossDriverOption](xref:Protocol.Params.Param.CrossDriverOptions.CrossDriverOption)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[local](xref:Protocol.Params.Param.CrossDriverOptions.CrossDriverOption.PIDTranslation-local)|unsignedInt|Yes|Specifies the parameter ID of the column in this protocol.|
|[remote](xref:Protocol.Params.Param.CrossDriverOptions.CrossDriverOption.PIDTranslation-remote)|unsignedInt|Yes|Specifies the parameter ID of the column in the remote protocol.|
