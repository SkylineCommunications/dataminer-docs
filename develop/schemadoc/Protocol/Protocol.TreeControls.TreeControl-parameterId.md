---
metadata_version: 1
uid: Protocol.TreeControls.TreeControl-parameterId
description: "Reference the DataMiner connector protocol schema entry for parameterId attribute, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
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
