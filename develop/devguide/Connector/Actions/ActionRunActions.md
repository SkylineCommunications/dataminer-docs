---
uid: LogicActionRunActions
---

# run actions

This action can be executed on parameters only.

This action will trigger the execution of any QActions that trigger on the specified parameter.

## Attributes

### On@id

The ID of the parameter(s) for which any linked QAction must be executed.

## Examples

In the following example, DataMiner will execute the QActions triggered by an update of the parameter with ID 3:

```xml
<Action id="1">
  <On id="3">parameter</On>
  <Type>run actions</Type>
</Action>
```
