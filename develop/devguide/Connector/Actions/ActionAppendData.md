---
uid: LogicActionAppendData
---

# append data

This action can be executed on parameters only.

Contrary to an action of type "copy", which causes the displayed value to be copied, an action of type "append data" copies the actual value of the parameter as stored in memory.

## Attributes

### On@id

Specifies the ID(s) of the destination parameter(s).

### Type@id

Specifies the ID of the source parameter.

## Examples

```xml
<Action id="1">
   <On id="1">parameter</On>
   <Type id="2">append data</Type>
</Action>
```
