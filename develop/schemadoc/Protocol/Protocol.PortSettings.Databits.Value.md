---
uid: Protocol.PortSettings.Databits.Value
---

# Value element

Using one or more Value elements, you can specify the different values that users are allowed to enter.

## Type

unsignedInt

## Parent

[Databits](xref:Protocol.PortSettings.Databits)

## Remarks

- The value specified in the DefaultValue tag does not have to be specified in a Value tag.
- When no Value tags are specified, users will only be allowed to enter the value specified in the DefaultValue tag.

## Examples

In the following example, the user can enter the values 7 and 8:

```xml
<Value>7</Value>
<Value>8</Value>
```
