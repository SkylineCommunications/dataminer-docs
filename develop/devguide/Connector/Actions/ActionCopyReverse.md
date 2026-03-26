---
uid: LogicActionCopyReverse
---

# copy reverse

This action can be executed on parameters only.

This action copies the value of the source parameter, in reverse order, to the destination parameter(s).

> [!NOTE]
> The existing value of the destination parameter will be overwritten.

## Attributes

### On@id

Specifies the ID(s) of the destination parameter(s).

### Type@id

(optional): Specifies the ID of the source parameter.

> [!NOTE]
> When the action is executed via a trigger that triggers on a parameter, the use of the Type@id attribute is not required. In this case, when the Type@id attribute is left out, DataMiner will use the trigger parameter (i.e., the parameter referred to in the On element of the trigger) as the source parameter.

## Remarks

## Examples

In the following example, the value of parameter 2 will be copied in reverse order to parameter 1. So, if parameter 2 contains the value “3-4”, after the “copy reverse” action, parameter 1 will contain the value “4-3”:

```xml
<Action id="1">
  <On id="1">parameter</On>
  <Type id="2">copy reverse</Type>
</Action>
```
