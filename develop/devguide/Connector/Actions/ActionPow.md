---
uid: LogicActionPow
---

# pow

This action can be executed on parameters only.

This action raises the value by the exponent.

## Attributes

### On@id

Specifies the ID(s) of the parameter(s) on which the action needs to be performed.

### Type@value

The exponent.

Default: 1.

## Examples

```xml
<Action id="1">
  <On id="5000">parameter</On>
  <Type value="1">pow</Type>
</Action>
```
