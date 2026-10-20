---
uid: Protocol.Groups.Group.Type
description: "Use the Type element under Group in a DataMiner protocol to select whether a group contains actions, triggers, parameters, or pairs."
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
