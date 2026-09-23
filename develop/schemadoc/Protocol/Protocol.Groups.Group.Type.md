---
metadata_version: 1
uid: Protocol.Groups.Group.Type
description: "Reference the DataMiner connector protocol schema entry for Type element, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# Type element

Specifies the group type.

## Type

[EnumGroupType](xref:Protocol-EnumGroupType)

## Parent

[Group](xref:Protocol.Groups.Group)

## Remarks

By default, a group includes parameters or pairs. If you want to include actions or triggers in a group, use this element.

## Examples

```xml
<Type>action</Type>
```
