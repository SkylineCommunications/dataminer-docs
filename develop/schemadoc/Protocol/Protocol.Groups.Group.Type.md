---
metadata_version: 1
uid: Protocol.Groups.Group.Type
description: "Learn how the Type element selects whether a group contains actions, triggers, parameters, or pairs in a DataMiner connector protocol."
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
