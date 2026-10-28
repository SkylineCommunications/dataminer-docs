---
uid: Protocol.TreeControls.TreeControl-readOnly
description: "Set the readOnly attribute of the TreeControl element to true in a DataMiner protocol to disable all write parameters in the tree control."
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
