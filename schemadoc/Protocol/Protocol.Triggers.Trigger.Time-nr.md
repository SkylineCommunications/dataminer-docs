---
uid: Protocol.Triggers.Trigger.Time-nr
---

# nr attribute

Set this attribute to true if the value attribute contains a parameter ID instead of a parameter value.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Time](xref:Protocol.Triggers.Trigger.Time)

## Examples

In the following example, the trigger will be executed when the value of the parameter with ID 1 is equal to the value of the parameter with ID 2:

```xml
<Time id="1" case="equal" value="2" nr="true">
```

In the following example, the trigger will be executed when the value of the parameter with ID 5 changes, but only if, at that moment, the value of the parameter with ID 20 equals 100:

```xml
<On id="5">parameter</On>
<Time id="20" case="equal" value="100">change</Time>
```
