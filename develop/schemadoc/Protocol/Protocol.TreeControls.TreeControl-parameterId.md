---
uid: Protocol.TreeControls.TreeControl-parameterId
description: "Use the parameterId attribute of the TreeControl element in a DataMiner protocol to identify the parameter that implements the tree control."
---

# parameterId attribute

Specifies the parameter ID of the tree control.

## Content Type

[TypeParamId](xref:Protocol-TypeParamId)

## Parent

[TreeControl](xref:Protocol.TreeControls.TreeControl)

## Examples

```xml
<TreeControl parameterId="4640">
  ...
</TreeControl>
...
<Param id="4640">
  <Name>TreeControl</Name>
  <Description>Tree Control</Description>
  <Type>read</Type>
  ...
</Param>
```
