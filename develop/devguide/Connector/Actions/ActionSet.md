---
uid: LogicActionSet
---

# set

This action can be executed on parameters (single set) or groups (multiple sets).

This action will perform an SNMP set operation.

## On parameter

### Attributes

#### On@id

Specifies the ID(s) of the parameters.

#### Type@nr

(optional): Specifies the connection. Default: 0.

## On group

### Attributes

#### On@id

Specifies the ID of the group.

#### Type@nr (optional)

Specifies the connection. Default: 0.

## Examples

Example on parameter:

```xml
<Action id="402">
  <On id="402">parameter</On>
  <Type>set</Type>
</Action>
```

Example on group

```xml
<Action id="10003">
  <On id="10003">group</On>
  <Type>set</Type>
</Action>
<Group id="10003">
  <Name>Sets</Name>
  <Description>Sets</Description>
  <Content>
     <Param>2006</Param>
     <Param>2007</Param>
  </Content>
</Group>
```
