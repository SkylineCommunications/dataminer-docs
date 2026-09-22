---
metadata_version: 1
uid: Protocol.TreeControls.TreeControl-readOnly
description: "Reference the DataMiner connector protocol schema entry for readOnly attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# readOnly attribute

If set to "true", disables all the write parameters in the tree control.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[TreeControl](xref:Protocol.TreeControls.TreeControl)

## Remarks

Default: false.

## Examples

```xml
<TreeControl parameterId="4640" readOnly="true">
```
