---
uid: Protocol.Triggers.Trigger.Time-value
---

# value attribute

Specifies the value that will be used as condition operand.

## Content Type

string

## Parent

[Time](xref:Protocol.Triggers.Trigger.Time)

## Examples

```xml
<Trigger id="ID">
   <Name>No Such Name PID</Name>
   <On id="PID">parameter</On>
   <Time value="NO SUCH NAME">timeout</Time>
   <Type>action</Type>
   <Content>
      <Id>ActionID</Id>
   </Content>
</Trigger>
```

## Remarks

The combination of a timeout with the value attribute shown in the example above no longer works in the currently supported DataMiner versions<!-- RN 8550 -->. Instead, the trigger on timeout will always go off when the polling of a parameter results in a timeout, regardless of what is configured in the value attribute.
