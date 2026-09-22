---
metadata_version: 1
uid: Protocol.Pairs.Pair-ping
description: "Reference the DataMiner connector protocol schema entry for ping attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# ping attribute

If set to true, the pair will be executed when the device is in timeout and slow polling is activated.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Pair](xref:Protocol.Pairs.Pair)

## Remarks

> [!NOTE]
> This option cannot be used in protocols of type SNMP.

## Examples

```xml
<Pair id="1" ping="true">
```
