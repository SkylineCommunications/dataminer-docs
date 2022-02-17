---
uid: LogicActionSetWithWait
---

# set with wait

This action can be executed on parameters and groups.

## On parameter

This action performs an SNMP set, and will wait until the device has answered.

Optionally, the connection can be specified in the nr attribute.

> [!NOTE]
> Always put a “set with wait” action in an “execute group” action.

### Attributes

#### On@id

Specifies the ID(s) of the parameter(s) to set.

#### Type@nr

(optional): Specifies the connection number. Default: 0.

## On group

### Attributes

#### On@id

Specifies the ID(s) of the group(s) for which the parameter(s) need to be set.

#### Type@nr

(optional): Specifies the connection number. Default: 0.

## Examples

Example on parameter:

```xml
<Action id="1302">
  <On id="1302">parameter</On>
  <Type>set with wait</Type>
</Action>
```

Example on group

```xml
<Action id="10">
  <On id="10">group</On>
  <Type>set with wait</Type>
</Action>
```
