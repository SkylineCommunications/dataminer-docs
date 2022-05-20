---
uid: LogicActionSetAndGetWithWait
---

# set and get with wait

This action can be executed on parameters only.

This action will perform an SNMP set and get, and will wait until the action has been executed on the device.

By default, the get action is performed on the associated read parameter. If you want a specific parameter to be retrieved by the get, you can specify the ID of that parameter in the id attribute of the Type tag.

> [!IMPORTANT]
> Always put a “set and get with wait” action in an “execute group” action.

## Attributes

### On@id

Specifies the ID(s) of the parameters to retrieve.

### Type@id

(Optional.) Specifies the ID of the parameter to retrieve. If not provided, the corresponding read parameter of the parameter specified in On@id is used.

#### Type@nr

(Optional.) Specifies the connection number. Default: 0.

## Examples

```xml
<Action id="167">
   <Name>De-Embedder 1-1 set and get with wait</Name>
   <On id="267">parameter</On>
   <Type>set and get with wait</Type>
</Action>
```

```xml
<Action id="19">
   <On id="45">parameter</On>
   <Type id="44">set and get with wait</Type>
</Action>
```
