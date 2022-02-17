---
uid: LogicActionIncrement
---

# increment

This action can be executed on parameters only.

This action increments the specified parameter with the specified value.

## Attributes

### On@id

Specifies the ID(s) of the parameter(s) that need to be incremented.

### Type@value

(optional): The increment value. Default: 1.

## Examples

```xml
<Action id="104">
  <On id="104">parameter</On>
  <Type value="10">increment</Type>
</Action>
```
