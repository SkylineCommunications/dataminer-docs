---
metadata_version: 1
uid: Protocol.TreeControls.TreeControl.OverrideIconColumns
description: "Reference the DataMiner connector protocol schema entry for OverrideIconColumns element, including its documented structure, attributes, values, and const."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# OverrideIconColumns element

By specifying a column in this element, you can apply a custom icon based on a cell value in a row.

## Type

string

## Parent

[TreeControl](xref:Protocol.TreeControls.TreeControl)

## Remarks

The column must be a parameter of type Discreet and all discreet values must have an IconRef referring to an icon. If not, a default icon will be displayed.

## Examples

```xml
<OverrideIconColumns>106,206</OverrideIconColumns>
```
