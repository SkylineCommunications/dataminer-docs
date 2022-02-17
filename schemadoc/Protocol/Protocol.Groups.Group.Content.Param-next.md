---
uid: Protocol.Groups.Group.Content.Param-next
---

# next attribute

Specifies the number of milliseconds DataMiner has to wait before reading the next parameter.

## Content Type

unsignedInt

## Parent

[Param](xref:Protocol.Groups.Group.Content.Param)

## Remarks

If the last item in the group contains this attribute, it will also cause a delay before the next group is executed.

Only applicable in case of single GETs.
