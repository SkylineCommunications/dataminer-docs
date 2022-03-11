---
uid: LogicActionTimeout
---

# timeout

This action can be executed on pairs only.

This action overrules the default timeout.

## Attributes

### On@id

Specifies the ID(s) of the pair(s) for which the timeout value should be overridden.

### Type@id

Specifies the ID of the parameter that holds the timeout value (in ms).

## Examples

In the following example, on change of a parameter (id=10) holding the dynamic timeout, an action can be triggered to set the timeout on a pair.

```xml
<Triggers>
  <Trigger id="1">
     <Name>setTimeout</Name>
     <!--param 10 : dynamic timeout value-->
     <On id="10">parameter</On>
     <Time>change</Time>
     <Type>action</Type>
     <Content>
        <Id>1</Id>
     </Content>
  </Trigger>
</Triggers>
<Actions>
  <Action id="1">
     <Name>setTimeoutOnPairs</Name>
     <!--set timeout of pair 1, 2, 3 and 4-->
     <On id="1;2;3;4">pair</On>
     <Type id="10">timeout</Type>
  </Action>
</Actions>
```
