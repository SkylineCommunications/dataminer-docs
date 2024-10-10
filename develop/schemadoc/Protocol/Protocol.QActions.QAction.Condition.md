---
uid: Protocol.QActions.QAction.Condition
---

# Condition element

Specifies a condition that must be met in order for the QAction to execute.

## Type

string

## Parent

[QAction](xref:Protocol.QActions.QAction)

## Remarks

Refer to <xref:LogicConditions> for more information about conditions.

## Examples

In the following example, the QAction will be executed on trigger of parameter ID 3000 and only when the value of parameter ID 500 is equal to Active:

```xml
<QAction id="1" encoding="csharp" triggers="3000" inputParameters="">
  <Condition>id:500 == "Active"</Condition>
  <![CDATA[
    ...
```

In the following example, the QAction will be executed when the value of the parameter with ID 1 is equal to 1 and the value of the parameter with ID 104 is equal to 0:

```xml
<Condition><![CDATA[(id:1 == 1 AND id:104 == 0)]]></Condition>
<![CDATA[
  ...
```
