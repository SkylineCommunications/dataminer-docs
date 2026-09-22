---
metadata_version: 1
uid: Protocol.TreeControls.TreeControl.Hierarchy.Table-parent
description: "Reference the DataMiner connector protocol schema entry for parent attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
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
