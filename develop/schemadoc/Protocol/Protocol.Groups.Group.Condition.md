---
uid: Protocol.Groups.Group.Condition
---

# Condition element

Specifies a condition that must be met in order for the group to execute.

## Type

string

## Parent

[Group](xref:Protocol.Groups.Group)

## Remarks

If you specify a condition, the group will only be executed when the condition is met.
Note that a condition can be enclosed in a CDATA tag.

Refer to <xref:LogicConditions> for more information about conditions.

> [!IMPORTANT]
> When the group has has a condition, 'before group' and 'after group' trigger will only go off if the condition result is 'true'. Not that prior to DataMiner 10.4.8 (CU1) and 10.4 (CU5) trigger would go off no matter the group condition result, this has now been fixed.

## Examples

In the following example, the group will be executed when the value of parameter 500 is equal to “Active”:

```xml
<Group id="200">
  <Condition>id:500 == "Active"</Condition>
</Group>
```

In the following example, the group will be executed when the value of parameter 5 is equal to 1:

```xml
<Group id="200">
  <Condition><![CDATA[(id:5 == 1)]]></Condition>
</Group>
```
