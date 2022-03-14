---
uid: Protocol.Pairs.Pair-timeout
---

# timeout attribute

If you specify a timeout value in a Protocol.Pairs.Pair tag using this attribute, DataMiner will use this timeout value instead of the default one when executing the pair.

## Content Type

unsignedInt

## Parent

[Pair](xref:Protocol.Pairs.Pair)

## Remarks

Using this option, you can enlarge the period of time DataMiner will wait for a response after having sent a command.

Note that when a dynamic timeout is needed, you should use the following instead of this timeout attribute: on change of a Param (id=10) holding the dynamic timeout, an Action can be triggered to set the Timeout on a Pair.

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
...
<Actions>
  <Action id="1">
     <Name>setTimeoutOnPairs</Name>
     <!--set timeout of pair 1, 2, 3 and 4-->
     <On id="1;2;3;4">pair</On>
     <Type id="10">timeout</Type>
  </Action>
</Actions>
```

## Examples

```xml
<Pair id="1" timeout="5000">
```
