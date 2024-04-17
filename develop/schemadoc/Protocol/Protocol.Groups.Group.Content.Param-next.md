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

When this is applied on a table parameter with the partialSNMP OID option active, it will also cause the delay being applied between the execution of the different partial row gets because this is considered as a next get to be executed.

This attribute is broken since RN33197 in DataMiner versions 10.1.0 CU15, 10.2.0 CU3, 10.2.6. This is fixed again with RN39430, DataMiner version still to be determined.
