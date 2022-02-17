---
uid: Protocol.Params.Param.ArrayOptions.NamingFormat
---

# NamingFormat element

Defines the structure of the display key.

## Type

string

## Parent

[ArrayOptions](xref:Protocol.Params.Param.ArrayOptions)

## Remarks

The first character in the naming format will be considered the separator between the different components. In the example above, a comma is used to separate the components (which can be either parameter values or static text). Every separator is replaced by a space. That way, you can choose where to insert spaces.

If you want to use characters like “<”, “>” and “&” in the naming format, enclose the format in a CDATA block.

It is not necessary to put static text in between the separators. You can just sum up a number of parameter IDs to be replaced by their values:

```xml
<NamingFormat><![CDATA[,1512,1514,1516]]></NamingFormat>
```

> [!NOTE]
> If you use this NamingFormat tag, it will override any naming rules specified in the `options=”;naming=1512/1514”` attribute of the ArrayOptions tag. Use one of the two methods according to the format you wish to use.

*Feature introduced in DataMiner 8.0.5 (RN 6343)*

## Examples

The following example:

```xml
<NamingFormat>,string,1512,discreet,1514</NamingFormat>
```

produces a display key with the following format:

```
string [value of parameter 1512 for this row] discreet [value of parameter 1514 for this row]
```
