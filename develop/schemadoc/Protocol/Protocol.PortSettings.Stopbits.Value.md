---
uid: Protocol.PortSettings.Stopbits.Value
---

# Value element

Using one or more Value elements, you can specify the different values that users are allowed to enter.

## Type

[EnumPortSettingsStopBits](xref:Protocol-EnumPortSettingsStopBits)

## Parent

[Stopbits](xref:Protocol.PortSettings.Stopbits)

## Remarks

> [!NOTE]
>
> - The value specified in the DefaultValue tag does not have to be specified in a *Value* tag.
> - When no Value tags are specified, users will only be allowed to enter the value specified in the *DefaultValue* tag.

## Examples

In the following example, users can only enter the values 1 and 2:

```xml
<Value>1</Value>
<Value>2</Value>
```
