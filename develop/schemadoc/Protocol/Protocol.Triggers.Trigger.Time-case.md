---
uid: Protocol.Triggers.Trigger.Time-case
---

# case attribute

Specifies the condition operator: equal, not equal, greater, less, or a logical combination of those operators.

## Content Type

string

## Parent

[Time](xref:Protocol.Triggers.Trigger.Time)

## Examples

In the following example, the trigger will be executed when the value of the Parameter with ID 1 is equal to 2:


```xml
<Time id="1" case="equal" value="2">
```



