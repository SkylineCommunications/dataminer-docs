---
uid: Protocol.Groups.Group.Content.Pair-next
---

# next attribute

Specifies the number of milliseconds DataMiner has to wait after having received the response of the last executed pair before executing the next pair.

## Content Type

unsignedInt

## Parent

[Pair](xref:Protocol.Groups.Group.Content.Pair)

## Remarks

If the last item in the group contains this attribute, it will also cause a delay before the next group is executed.

Example:


```xml
<Pair next="5000">25</Pair>
```



