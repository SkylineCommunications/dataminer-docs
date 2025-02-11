---
uid: Protocol.Timers.Timer.Condition
---

# Condition element

Specifies a condition that must be met in order for the timer to execute.

## Type

string

## Parent

[Timer](xref:Protocol.Timers.Timer)

## Remarks

Refer to <xref:LogicConditions> for more information about conditions.

> [!NOTE]
> Avoid using conditions on timers. Instead, use a condition on the timer group(s).

## Examples

In the following example, the timer is activated when the value of parameter 500 is equal to Active:

```xml
<Timer id="1">
  <Condition>id:500 == "Active"</Condition>
    ...
```

In the following example, the timer is activated when the value of the parameter with ID 1 is equal to 1 and the value of the parameter with ID 104 is equal to 0:

```xml
<Timer id="1">
  <Condition><![CDATA[(id:1 == 1 AND id:104 == 0)]]></Condition>
    ...
```
