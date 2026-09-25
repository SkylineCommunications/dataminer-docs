---
metadata_version: 1
uid: Protocol.SNMP
description: "Learn how the protocol-level SNMP element controls MIB generation, including automatic parameter OIDs and page submaps."
---

# SNMP element

Specifies how the MIB file for the protocol will be created.

## Type

[EnumSNMP](xref:Protocol-EnumSNMP)

## Parent

[Protocol](xref:Protocol)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[includepages](xref:Protocol.SNMP-includepages)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)|Yes|If set to "true", the MIB of the protocol will contain several submaps: one for each page defined in the protocol.|

## Remarks

> [!NOTE]
> When the main connection of the protocol is SNMP, the parameters will always be included in the generated MIB regardless of the value specified here.
