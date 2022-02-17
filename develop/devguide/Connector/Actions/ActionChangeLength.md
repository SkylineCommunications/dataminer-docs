---
uid: LogicActionChangeLength
---

# change length

This action can be used on parameters only.

This action will change the length of a parameter.

The maximum length is 1048576 (1024x1024) bytes. If you specify a larger number, it will be reduced to that maximum number of bytes.

## Attributes

### On@id

Specifies the ID(s) of the parameter(s) of which the length needs to be changed.

> [!NOTE]
> The parameter must have length type set to fixed.

### Type@id

Specifies the ID of the parameter that specifies the length value to be set.

## Examples

In the following example, the length of the parameter is set to the number of bytes specified in the parameter with ID 502:

```xml
<Action id="1">
   <On id="1">parameter</On>
   <Type id="502">change length</Type>
</Action>
```
