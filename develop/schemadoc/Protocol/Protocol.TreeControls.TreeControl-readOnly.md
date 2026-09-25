---
metadata_version: 1
uid: Protocol.TreeControls.TreeControl-readOnly
description: "Consult the DataMiner connector protocol schema reference for the readOnly attribute, which disables every write parameter in the tree control when true."
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
