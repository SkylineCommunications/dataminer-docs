---
uid: Protocol.Params.Param.Interprete.Rounding
---

# Rounding element

Specifies how the parameter value is rounded.

## Type

[EnumRounding](xref:Protocol-EnumRounding)

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Remarks

Default: down

*Feature introduced in DataMiner 9.0.0 CU7/9.0.4 (RN 13519).*

## Examples

```xml
<Interprete>
		<RawType>unsigned number</RawType>
		<LengthType>fixed</LengthType>
		<Length>4</Length>
		<Type>double</Type>
		<Rounding>halfToInfinity</Rounding>
</Interprete>
```
