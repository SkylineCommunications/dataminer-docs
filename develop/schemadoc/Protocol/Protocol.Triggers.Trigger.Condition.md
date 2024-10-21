---
uid: Protocol.Triggers.Trigger.Condition
---

# Condition element

Specifies a condition that must be met in order for the trigger to go off.

## Type

string

## Parent

[Trigger](xref:Protocol.Triggers.Trigger)

## Remarks

Refer to <xref:LogicConditions> for more information about conditions.

## Examples

In the following example, the trigger is activated when the value of the parameter with ID 2001 is equal to 24:

```xml
<Condition><![CDATA[(id:2001 == "24")]]></Condition>
```

In the following example, the trigger is activated when the value of the parameter with ID 1 is equal to 1 and the value of the parameter with ID 104 is equal to 0:

```xml
<Condition><![CDATA[(id:1 == 1 AND id:104 == 0)]]></Condition>
```

In the following example, the trigger is activated when the value of the parameter with ID 92 is empty. When the parameter is a number and of type fixed, the condition will be true when the value is 0. This is also the case when using the IsEmpty() function via a QAction.

```xml
<Condition><![CDATA[(id:92 == empty)]]></Condition>
```
