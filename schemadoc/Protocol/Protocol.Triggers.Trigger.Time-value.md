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
