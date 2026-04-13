---
uid: Protocol.ParameterGroups.Group-isInternal
---

# isInternal attribute

<!-- RN 29326, RN 29438 -->

Specifies whether this an internal interface.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Group](xref:Protocol.ParameterGroups.Group)

## Remarks

Default: false.

Specifies whether the interface is internal. Allows a distinction between:

- internal DCF interfaces (i.e., virtual interfaces used within the protocol), and
- external DCF interfaces (i.e., physical interfaces that will appear in interface lists in the UI).

By default, all DCF interfaces are considered external. Interfaces that should be considered internal have to be explicitly marked as internal.

## Examples

```xml
<Protocol xmlns="http://www.skyline.be/protocol">
  ...
  <ParameterGroups>
     <Group id="1" name="500_in" type="in" dynamicId="500" dynamicIndex="*" isInternal="true"/>
     <Group id="2" name="1000_out" type="out" dynamicId="1000" dynamicIndex="*"/>
     <Group id="3" name="1500_inout" type="inout" dynamicId="1500" dynamicIndex="*"/>
     <Group id="4" name="2000_inout" type="inout" dynamicId="2000" dynamicIndex="*"/>
     <Group id="5" name="fixed" type="inout" isInternal="true"/>
  </ParameterGroups>
  ...
</Protocol>
```
