---
uid: Protocol.Params.Param.Measurement.Discreets.Discreet-displayIconAndLabel
---

# displayIconAndLabel attribute

<!-- RN 16881, RN 16997 -->

Specifies whether to show only the icon (false) or to show the icon together with the display value of the discrete entry (true).

Default: false.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Discreet](xref:Protocol.Params.Param.Measurement.Discreets.Discreet)

## Remarks

The behavior of the write control is unchanged: the text is always shown next to the icon (if an icon is configured).

## Examples

```xml
<Discreet iconRef="DATA" displayIconAndLabel="True">
   <Display>DATA</Display>
   <Value>2</Value>
</Discreet>
```
