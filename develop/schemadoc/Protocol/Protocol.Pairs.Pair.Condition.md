---
uid: Protocol.Pairs.Pair.Condition
---

# Condition element

Specifies a condition that must be met in order for the pair to execute.

## Type

string

## Parent

[Pair](xref:Protocol.Pairs.Pair)

## Remarks

Note that a condition can be enclosed in a CDATA tag.

Refer to <xref:LogicConditions> for more information about conditions.

## Examples

In the following example, the pair will be executed when parameter 500 contains "Active":

```xml
<Pair id="200">
<Condition>id:500 == "Active"</Condition>
```

In the following example, the pair will be executed when parameter 5 contains 1:

```xml
<Condition><![CDATA[(id:5 == 1)]]></Condition>
```
