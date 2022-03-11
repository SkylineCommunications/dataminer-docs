---
uid: Protocol.PortSettings.Baudrate.Value
---

# Value element

Using one or more Value elements, you can specify the different values that users are allowed to enter.

## Type

integer

## Parent

[Baudrate](xref:Protocol.PortSettings.Baudrate)

## Remarks

> [!NOTE]
>
> - The value specified in the DefaultValue tag does not have to be specified in a Value tag.
> - When no Value tags are specified, users will only be allowed to enter the value specified in the DefaultValue tag.

Contains a value of type integer.

## Examples

In the following example, users can only enter the values 1, 3, and 5:

```xml
<Value>1</Value>
<Value>3</Value>
<Value>5</Value>
```
