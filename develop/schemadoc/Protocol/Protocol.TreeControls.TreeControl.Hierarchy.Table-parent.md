---
uid: Protocol.TreeControls.TreeControl.Hierarchy.Table-parent
description: "Use the parent attribute of the Table element in a DataMiner protocol to identify the parent table in a tree control hierarchy."
---

# parent attribute

Specifies the parameter ID of the table that is the parent of the table specified in the *id* attribute.

## Content Type

unsignedInt

## Parent

[Table](xref:Protocol.TreeControls.TreeControl.Hierarchy.Table)

## Examples

```xml
<Hierarchy>
   <Table id="200" parent="100"/>
   ...
```
