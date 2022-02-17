---
uid: DMSScript.Script.Exe.Condition
---

# Condition element

Specifies a condition.

## Type

string

## Parent

[Exe](xref:DMSScript.Script.Exe)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[combination](xref:DMSScript.Script.Exe.Condition-combination)|string||Specifies the logical operator to be applied.|
|[compare](xref:DMSScript.Script.Exe.Condition-compare)|string||Specifies the operator to use in the Boolean expression.|
|[pid](xref:DMSScript.Script.Exe.Condition-pid)|positiveInteger||Specifies the ID of the parameter that is referred to.|
|[protocol](xref:DMSScript.Script.Exe.Condition-protocol)|positiveInteger||Specifies the ID of the dummy script variable that is referred to.|
|[ref](xref:DMSScript.Script.Exe.Condition-ref)|string||In case the right hand operand is a script variable, this attribute specifies the script variable that is referred to.|
|[type](xref:DMSScript.Script.Exe.Condition-type)|string||Specifies whether the left hand operand of the Boolean expression is a script variable or a parameter value.|
|[var](xref:DMSScript.Script.Exe.Condition-var)|string||Specifies the name of the script variable.|

## Remarks

Used in a script action of type "if".

In case the right operand of the Boolean expression is a condition that uses a specific value, the content of Condition specifies the value (In case the right hand operand of the Boolean expression is a script variable, the ref attribute specifies the script variable).

## Examples

```xml
<Condition combination="and" type="param" protocol="1" pid="64501" compare="lt" ref="param1">
</Condition>
<Condition combination="or" type="variable" var="param1" compare="eq" ref="">10</Condition>
```
