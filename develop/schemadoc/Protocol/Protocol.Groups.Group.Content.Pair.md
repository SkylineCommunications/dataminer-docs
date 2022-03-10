---
uid: Protocol.Groups.Group.Content.Pair
---

# Pair element

Specifies the ID of a command/response pair to be included in the group.

## Type

[TypeNonLeadingZeroUnsignedInt](xref:Protocol-TypeNonLeadingZeroUnsignedInt)

## Parent

[Content](xref:Protocol.Groups.Group.Content)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[next](xref:Protocol.Groups.Group.Content.Pair-next)|unsignedInt||Specifies the number of milliseconds DataMiner has to wait after having received the response of the last executed pair before executing the next pair.|

## Remarks

When a setting has to be changed, it is common practice to include in a group

- a “SET” pair, directly followed by
- a “GET” pair.

That way, the DataMiner interface will immediately show the changes.

## Examples

```xml
<Pair next="5000">25</Pair>
```
