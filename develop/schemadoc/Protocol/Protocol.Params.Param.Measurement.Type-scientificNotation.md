---
uid: Protocol.Params.Param.Measurement.Type-scientificNotation
---

# scientificNotation attribute

Specifies the scientific notation to be used.

## Content Type

[EnumScientificNotation](xref:Protocol-EnumScientificNotation)

## Parent

[Type](xref:Protocol.Params.Param.Measurement.Type)

## Remarks

Only to be specified in case of measurement type “number”.

By default, 0 decimals are shown. To specify the number of decimals to show, the Decimals tag of the Display tag can be used.

See also: Protocol.Params.Param.Display.[Decimals](xref:Protocol.Params.Param.Display.Decimals).

From DataMiner 10.0.13 (RN 27690) onwards, values are represented using culture-independent (invariant) formatting.

*The scientificNotation attribute is introduced in DataMiner version 9.0.1.4 (RN 12433, RN 12600).*

## Examples

The value 12345 will be displayed as follows (assuming that the number of decimals has been set to 3).

- universal: 1.235E+004
- scientific: 12.345E+003
