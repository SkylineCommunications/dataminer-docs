---
uid: Protocol.ParameterGroups.Group-dynamicUsePK
---

# dynamicUsePK attribute

Specifies whether the display key or the primary key should be used in the interface name (Default: false).

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Group](xref:Protocol.ParameterGroups.Group)

## Remarks

By default, when defining a parameter group that uses a dynamic ID to dynamically generate interfaces, the display key is used. If you want to use the primary key instead of the display key in the interface name, use this attribute and set it to “true”.

*Feature introduced in DataMiner 8.5.6 (RN 9767).*

## Examples

```xml
<Group id="4" name="NamingFormatMain" type="inout" dynamicId="2000" dynamicIndex="*" dynamicUsePK="true"/>
```
