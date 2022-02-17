---
uid: LogicActionSave
---

# save

This action can be executed on parameters only.

This action allows you to save the value of a certain parameter. When DataMiner is restarted, the saved parameter will display its last known value.

## Attributes

### On@id

The ID of the parameter(s) that need to be saved.

## Examples

```xml
<Action id="1101">
  <On id="1001">parameter</On>
  <Type>save</Type>
</Action>
```
