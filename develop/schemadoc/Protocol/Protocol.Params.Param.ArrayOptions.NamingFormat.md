---
uid: Protocol.Params.Param.ArrayOptions.NamingFormat
---

# NamingFormat element

Defines the structure of the display key.<!-- RN 6343 -->

## Type

string

## Parent

[ArrayOptions](xref:Protocol.Params.Param.ArrayOptions)

## Remarks

The first character in the NamingFormat tag is the separator used between the different components. In the example below, a comma is used to separate the components. A component is either a parameter ID or static text.

It is not necessary to put static text in between the separators. You can just sum up a number of parameter IDs to be replaced by their values:

```xml
<NamingFormat>,1512,1514,1516</NamingFormat>
```

If you want to use characters like "<", ">" and "&" in the naming format, enclose the format in a CDATA block.

> [!NOTE]
> If you use this NamingFormat tag, it will override any naming rules specified in the options attribute of the ArrayOptions tag (`options=";naming=/1512,1514"`). Using the NamingFormat tag is preferred over the use of the naming option.

> [!NOTE]
> When referencing a parameter ID, take care not to add spaces before or after the number. For example:
>
> - Correct: ";Input;1005;TS;2004"
> - Incorrect: ";Input; 1005;TS;2004 "

## Examples

The following example:

```xml
<NamingFormat>,string ,1512, discreet ,1514</NamingFormat>
```

produces a display key with the following format:

`string [valueOfParameter1512ForThisRow] discreet [valueOfParameter1514ForThisRow]`

## See also

[Display keys](xref:UIComponentsTableDisplayKeys)
