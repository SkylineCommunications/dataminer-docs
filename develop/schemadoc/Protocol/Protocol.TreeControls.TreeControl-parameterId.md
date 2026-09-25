---
metadata_version: 1
uid: Protocol.TreeControls.TreeControl-parameterId
description: "Consult the DataMiner connector protocol schema reference for the parameterId attribute, which identifies the parameter that implements the tree control."
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
<Param id="4640" trending="false">
  <Name>TreeControlParam</Name>
  <Description>Parameter of the TreeControl</Description>
  <Type>read</Type>
  ...
</Param>
```
