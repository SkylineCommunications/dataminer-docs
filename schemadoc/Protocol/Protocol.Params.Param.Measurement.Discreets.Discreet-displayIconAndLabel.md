---
uid: Protocol.Params.Param.Measurement.Discreets.Discreet-displayIconAndLabel
---

# displayIconAndLabel attribute

Specifies whether to show only the icon (false) or to show the icon together with the display value of the discrete entry (true).

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Discreet](xref:Protocol.Params.Param.Measurement.Discreets.Discreet)

## Remarks

Default: false.

> [!NOTE]
> The behavior of the write control is unchanged: the text is always shown next to the icon (if an icon is configured).

*Feature introduced in DataMiner 9.5.7 (RN 16881, RN 16997).*

## Examples

```xml
<Discreet iconRef="DATA" displayIconAndLabel="True">
	<Display>DATA</Display>
	<Value>2</Value>
</Discreet>
```
