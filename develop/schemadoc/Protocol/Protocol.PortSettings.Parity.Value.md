---
uid: Protocol.PortSettings.Parity.Value
---

# Value element

Using one or more *Value* tags, you can specify the different values that users are allowed to enter.

## Type

[EnumPortSettingsParity](xref:Protocol-EnumPortSettingsParity)

## Parent

[Parity](xref:Protocol.PortSettings.Parity)

## Remarks

> [!NOTE]
>
> - The value specified in the DefaultValue tag does not have to be specified in a Value tag.
> - When no Value tags are specified, users will only be allowed to enter the value specified in the DefaultValue tag.
> - For an SNMPv3 connection, this tag can be used to specify the possible authentication algorithms.

## Examples

In the following example, users can only enter the values “Even” and “Odd”:

```xml
<Value>Even</Value>
<Value>Odd</Value>
```
