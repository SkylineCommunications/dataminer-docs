---
uid: Protocol.Triggers.Trigger.On-id
---

# id attribute

Specifies the ID of the parameter, command, response, etc.

## Content Type

[TypeTriggerOnId](xref:Protocol-TypeTriggerOnId)

## Parent

[On](xref:Protocol.Triggers.Trigger.On)

## Remarks

This attribute is required for all values of On except for "communication" and "protocol".

This attribute contains either a number or the value "each".

In case a number is defined, this specifies the ID of the item (the type of item is specified in On, e.g., "parameter") that makes this trigger go off.

Example:

The following example specifies that this trigger will go off on a change of parameter 100.

```xml
<Trigger id="100">
   <Name>OnResetButtonClickedTrigger</Name>
   <On id="100">parameter</On>
   <Time>change</Time>
   <Type>action</Type>
   <Content>
      <Id>100</Id>
   </Content>
</Trigger>
```

When "each" is defined as the attribute value, the trigger will act as a default trigger, i.e., this trigger will be used unless there is another trigger defined that triggers on that specific item.

Example:

```xml
<Trigger id="201">
   <Name>After Timeout</Name>
   <Condition><![CDATA[(id:500 == 1 AND id:252 == 1)]]></Condition>
   <On id="each">parameter</On>
   <Time>timeout after retries</Time>
   <Type>action</Type>
   <Content>
      <Id>201</Id>
   </Content>
</Trigger>
```

This trigger will be used for each parameter except for parameters that have a trigger that explicitly triggers on those parameters. E.g. the trigger above will not be used for parameter 200 in case the trigger below is also defined in the protocol:

```xml
<Trigger id="200">
  ...
   <On id="200">parameter</On>
  ...
</Trigger>
```
