---
metadata_version: 1
uid: Protocol.TreeControls.TreeControl-readOnly
description: "Reference the DataMiner connector protocol schema entry for readOnly attribute, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
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
