---
uid: LogicActionMultiply
---

# multiply

This action can be executed on parameters only.

This action multiplies the specified parameter with the specified value.

## Attributes

### On@id

Specifies the ID(s) of the parameter(s) that need to be multiplied.

### Type@value

The value to multiply with. Default: 1.

## Examples

```xml
<Action id="1">
  <On id="5000">parameter</On>
  <Type value="10">multiply</Type>
</Action>
```
