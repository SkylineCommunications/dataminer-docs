---
uid: Protocol.Actions.Action.Condition
---

# Condition element

Specifies a condition that must be met in order for the action to execute.

## Type

string

## Parent

[Action](xref:Protocol.Actions.Action)

## Remarks

- The condition can be specified in a CDATA tag.
- Refer to <xref:LogicConditions> for more information about conditions.

## Examples

If you specify the following, the action will be executed when the value of parameter ID 500 is equal to “Active”.

```xml
<Condition>id:500 == "Active"</Condition>
```

As another example, if you specify the following, the action will be executed when the value of parameter ID 5 is equal to 1.

```xml
<Condition><![CDATA[(id:5 == 1)]]></Condition>
```
