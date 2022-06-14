---
uid: LogicActionSetNext
---

# set next

This action can be executed on pairs only.

This action dynamically sets the value of the [next](xref:Protocol.Groups.Group.Content.Param-next) attribute. Normally this is set to a fixed value in the driver, but in certain cases, you want to be able to change it dynamically.

> [!NOTE]
> Only supported for serial, smart-serial and GPIB.

## Attributes

### On@nr

Specifies the 1-based position(s) of the pair(s) in the group on which the next value needs to be set.

### Type@id

(optional): Specifies the ID of the parameter containing the value to be set.

### Type@value

(optional): Specifies the value to be set.

> [!NOTE]
> Either use the Type@id attribute or the Type@value attribute. The Type@id attribute takes precedence over the Type@value attribute.

## Examples

```xml
<Group id="3">
  <Name>Measure</Name>
  <Content>
     <Pair next="1000">10</Pair>
     <Pair next="1000">11</Pair>
     <Pair next="1000">12</Pair>
     <Pair next="1000">13</Pair>
  </Content>
</Group>
```

```xml
<Trigger id="527">
   <On id="3">group</On>
   <Time>before</Time>
   <Type>action</Type>
   <Content>
      <Id>18</Id>
   </Content>
</Trigger>
```

```xml
<Action id="18">
   <On nr="1;2;3;4">pair</On>
   <Type id="41">set next</Type>
</Action>
```
