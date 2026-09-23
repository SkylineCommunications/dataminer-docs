---
metadata_version: 1
uid: Protocol.TreeControls
description: "Reference the DataMiner connector protocol schema entry for TreeControls element, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# TreeControls element

Contains all the tree controls defined in the protocol.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[TreeControl](xref:Protocol.TreeControls.TreeControl)|[1, *]|Defines a tree control.|

## Examples


```xml
<TreeControls>
  <TreeControl parameterId="1" ...="">...</TreeControl>
  <TreeControl parameterId="2" ...="">...</TreeControl>
</TreeControls>
```



