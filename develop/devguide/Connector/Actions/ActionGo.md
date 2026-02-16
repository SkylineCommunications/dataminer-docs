---
uid: LogicActionGo
---

# go

This action can be executed on parameters only.

This action tells DataMiner to automatically re-enter the last value into the specified parameter. All triggers linked to this write parameter will then go off.

This action can be used to e.g., reset a write parameter when its value and the value of the associated read parameter are different, for example because of a power failure on the device.

## Attributes

### On@id

Specifies the ID(s) of the parameter(s).

## Examples

```xml
<Action id="1">
  <On id="1">parameter</On>
  <Type>go</Type>
</Action>
```
