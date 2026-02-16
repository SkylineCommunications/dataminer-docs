---
uid: LogicConditions
---

# Conditions

Conditions are used to enable conditional item execution. A condition is defined using the Condition element.

> [!NOTE]
>
> - A condition can be enclosed in a CDATA tag, e.g., when you want to define a condition that uses the < operator.
> - An example protocol "SLC SDF Conditions" is available in the [Protocol Development Guide Companion Files](https://community.dataminer.services/documentation/protocol-development-guide-companion-files/).

## Operators

The following tables provide an overview of the supported operators in conditions.

### Additive operators

|Expression  |Description  |
|---------|---------|
|x + y     |Addition         |
|x - y     |Subtraction         |

> [!NOTE]
> The addition operator can be used with doubles or strings. In case of double values, it will add the values. In case of strings, it will concatenate these. The subtraction operator only works with double values. The operands must have the same type, i.e., they must both be a double or both be a string. In case the operand refers to a parameter (using the id:\<paramId\> placeholder) the Interprete type of the parameter must be "string" when the other operand is a string or either "double" or "high nibble" when the other operand is a double.
>
> For example: id:10 + 10 > 20: The parameter with ID 10 must have an Interprete type equal to "double" or "high nibble".

### Multiplicative operators

|Expression  |Description  |
|---------|---------|
|x * y     |Multiplication         |
|x / y     |Division         |

> [!NOTE]
> The multiplication and division operators only work with double values.

### Relational operators

|Expression  |Description  |
|---------|---------|
|x > y     |Greater than         |
|x < y     |Less than         |
|x >= y     |Greater than or equal         |
|x <= y     |Less than or equal         |

> [!NOTE]
> These operators can be used with strings or doubles. If both operands are strings, then a string comparison is performed. If both operands are doubles, the value is compared. In case one operand is a string and another is a double, the string operand is expected to represent a double value, and therefore DataMiner will try to convert the string value to a double.

### Equality operators

|Expression  |Description  |
|---------|---------|
|x == y     |Equal         |
|x != y     |Not equal         |

> [!NOTE]
> These operators can be used with strings or doubles. If both operands are strings, then a string comparison is performed. If both operands are doubles, the value is compared. In case one operand is a string and another is a double, the string operand is expected to represent a double value and therefore DataMiner will try to convert the string value to a double.

### Logical and conditional operators

|Expression  |Description  |
|---------|---------|
|x & y     |Integer bitwise AND         |
|x | y     |Integer bitwise OR         |
|x ^ y     |Integer bitwise XOR         |
|x AND y     |Boolean logical AND         |
|x OR y     |Boolean logical OR         |

> [!IMPORTANT]
> The AND and OR operators must always be surrounded by spaces. For all other operators, it is also advised to surround these operators with spaces.

> [!NOTE]
> The integer bitwise AND (&), integer bitwise OR (|) and integer bitwise XOR (^) only work with operands of type double. (These should represent an integer value, but DataMiner will perform a conversion to int by performing a floor operation.)
>
> The Boolean logical AND (AND) and Boolean logical OR (OR) operators must be used with Boolean expressions as operand.

## Operands

The following table shows an overview of the operands that can be used.

|Operand  |Description  |
|---------|---------|
|id:     |Refers to a protocol parameter (E.g. id:100). Note that the ID of the parameter must follow immediately after the colon (e.g., id:10) No space is allowed between id: and the parameter ID.         |
|"{value}"     |When enclosed by double quotes, the operand represents a string literal (E.g. "ALARM").         |
|empty     |Indicates an empty parameter ("Not Initialized").         |
|emptystring     |Indicates an empty string or an empty parameter ("Not Initialized").         |

Everything else is assumed to represent a double.

Note that when the parameter is a number and of LengthType "fixed", as in the following example, the below-mentioned condition will result in true.

Parameter:

```xml
<Param id="1">
   <Name>exampleParameter</Name>
   <Description>Example Parameter</Description>
   <Type>read</Type>
   <Interprete>
      <RawType>numeric text</RawType>
      <Type>double</Type>
      <LengthType>fixed</LengthType>
      <Length>4</Length>
      <Value>0</Value>
   </Interprete>
</Param>
```

Condition:

```xml
<Condition>id:1 == empty</Condition>
```

> [!IMPORTANT]
> Do not use the '#' or '$' characters in a condition, unless they are part of a string literal (i.e., when enclosed by double quotes)

## Defining a condition

Conditions can be defined on the following items:

- [Actions](xref:Protocol.Actions.Action.Condition)
- [Groups](xref:Protocol.Groups.Group.Condition)
- [Pairs](xref:Protocol.Pairs.Pair.Condition)
- [QActions](xref:Protocol.QActions.QAction.Condition)
- [Timers](xref:Protocol.Timers.Timer.Condition)
- [Triggers](xref:Protocol.Triggers.Trigger.Condition)

> [!NOTE]
> Avoid using conditions on a Timer. Instead, use a condition on the timer group(s).
>
> For a group condition, the evaluation of the condition will be performed when the group is executed by the group execution queue. This means the group will always be added to the queue of the protocol thread anyway. If the condition value changes between the moment the group is added to the queue and the moment the group is executed, it is possible that the behavior of the group is different than was intended when the group was added. This also means that it is no problem to have a poll group with a condition as the last group in a timer.

To build more advanced conditional constructs, you can use brackets.

> [!IMPORTANT]
> Always put a space between two consecutive brackets.

## Examples

In the following example, the condition is met when the value of the parameter with ID 2001 is equal to 24:

```xml
<Condition><![CDATA[(id:2001 == 24)]]></Condition>
```

In the following example, the condition is met when the value of the parameter with ID 1 is equal to 1 and the value of the parameter with ID 104 is equal to 0:

```xml
<Condition><![CDATA[(id:1 == 1 AND id:104 == 0)]]></Condition>
```

In the following example, the condition is met when the value of the parameter with ID 92 is empty.

```xml
<Condition><![CDATA[(id:92 == empty)]]></Condition>
```

In the following example, the condition is met when the value of parameter ID 500 is equal to “Active”.

```xml
<Condition>id:500 == "Active"</Condition>
```

In the following example, the condition is met when the sum of the value of the parameter with ID 1 and parameter with ID 2 is equal to 24:

```xml
<Condition>(id:1 + id:2) == 24</Condition>
```

## See also

DataMiner Protocol Markup Language:

- [Protocol.Actions.Action.Condition](xref:Protocol.Actions.Action.Condition)
- [Protocol.Groups.Group.Condition](xref:Protocol.Groups.Group.Condition)
- [Protocol.Pairs.Pair.Condition](xref:Protocol.Pairs.Pair.Condition)
- [Protocol.QActions.QAction.Condition](xref:Protocol.QActions.QAction.Condition)
- [Protocol.Timers.Timer.Condition](xref:Protocol.Timers.Timer.Condition)
- [Protocol.Triggers.Trigger.Condition](xref:Protocol.Triggers.Trigger.Condition)
