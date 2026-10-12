---
uid: DMSScript.Script.Exe.Condition-combination
description: "Use the combination attribute to combine conditions in an automation script 'if' action using the lowercase 'and' or 'or' logical operator."
---

# combination attribute

Use this attribute on a condition belonging to an `if` action. It specifies the logical operator to be applied, which determines how the condition is combined with the other conditions in the `if` action.

Use lowercase `and` or `or` values.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|`and`|And|
|&nbsp;&nbsp;Enumeration|`or`|Or|

## Parent

[Condition](xref:DMSScript.Script.Exe.Condition)

## Remarks

- For a single condition, the combination attribute does not add another condition to evaluate. Keep the conditions in the same `Exe` element so that the operator applies to the intended expression.
- DataMiner evaluates the conditions as one logical expression before it selects the `if`, `else`, or `endif` path.
- An unsupported value, mismatched condition set, or condition that refers to the wrong parameter can make the branch behave differently from the intended expression. Check the referenced parameter and variable IDs whenever you change the condition list.

## Example

```xml
<Exe id="2" type="if">
   <Type>conditions</Type>
   <Condition combination="and" type="param" protocol="1" pid="64501" compare="lt" ref="param1"></Condition>
   <Condition combination="or" type="variable" var="param1" compare="eq" ref="">10</Condition>
</Exe>
```

## Related concepts

- [Condition element](xref:DMSScript.Script.Exe.Condition)
- [If action](xref:AutomationActionIf)
- [Exe element](xref:DMSScript.Script.Exe)

## Authoritative references

- [Automation script actions](xref:AutomationActions)
- [Automation XML schema](xref:SchemaAutomationScript)
