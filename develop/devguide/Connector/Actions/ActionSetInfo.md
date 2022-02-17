---
uid: LogicActionSetInfo
---

# set info

This action can be executed on parameters only.

This action dynamically changes the sequence and the scale of the specified parameters.

> [!NOTE]
>
> - If you change both sequence and scale, the latter will be calculated first.
> - When the sequence and/or the scale of the parameter have to be ignored, enter a hyphen (“-”) in the value of the attribute.

## Attributes

### Type@scale

(optional): Specifies the scale to be set on the parameter. This is a semicolon-separated sequence of integer values with the following meaning.

1. Scale low data
1. Scale high data
1. Scale low
1. Scale high

### Type@sequence

(optional): Specifies the sequence to be set on the parameter. The sequence must be formatted as explained in [Protocol.Params.Param.Interprete.Sequence](xref:Protocol.Params.Param.Interprete.Sequence).

## Examples

```xml
<Action id="5">
   <On id="21002;22002;23002;24002;25002;26002;27002;28002">parameter</On>
   <Type scale="0;65535;-10;10" sequence="*:1000">set info</Type>
</Action>
```

```xml
<Action id="105">
   <On id="1000">parameter</On>
   <Type sequence="*:id:103;+:id:101">set info</Type>
</Action>
```
