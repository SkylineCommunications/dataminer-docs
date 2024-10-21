---
uid: Protocol.ParameterGroups.Group-dynamicId
---

# dynamicId attribute

Specifies the ID of the table parameter.

## Content Type

[TypeParamId](xref:Protocol-TypeParamId)

## Parent

[Group](xref:Protocol.ParameterGroups.Group)

## Remarks

See also [dynamicIndex](xref:Protocol.ParameterGroups.Group-dynamicIndex).

It is also possible to define 2 parameter groups using in and out type for a matrix. This is illustrated in the example below, where dynamicId 50 is a matrix parameter.

```xml
<ParameterGroups>
    <Group id="1" name="source" type="in" dynamicId="50" dynamicIndex="*"/>
    <Group id="2" name="destination" type="out" dynamicId="50" dynamicIndex="*"/>
</ParameterGroups>
```
