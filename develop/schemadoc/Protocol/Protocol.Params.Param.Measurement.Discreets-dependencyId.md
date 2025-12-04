---
uid: Protocol.Params.Param.Measurement.Discreets-dependencyId
---

# dependencyId attribute

If the discrete values of the parameter depend on the current state of another parameter, the ID of that other parameter can be specified using this attribute.

## Content Type

[TypeParamId](xref:Protocol-TypeParamId)

## Parent

[Discreets](xref:Protocol.Params.Param.Measurement.Discreets)

## Remarks

This parameter can be a single parameter or a column. In case of a column, the cell value will contain the semicolon-separated string with the possible items.

> [!NOTE]
> The column that is referred to by the dependencyId attribute must be displayed in the table.

DependencyId can be used either with Measurement Type "string" or "discreet".

If no dependencyValues are defined, an empty list will be shown.<!-- RN 5817 -->

```xml
<Measurement>
	<Type>discreet</Type>
	<Discreets dependencyId="10" />
</Measurement>
```

## Examples

In the following example, the parameter will show a dropdown box of all the semicolon-separated items in parameter 10, but the user will be allowed to add extra items:

```xml
<Measurement>
	<Type>string</Type>
	<Discreets dependencyId="10"/>
</Measurement>
```
