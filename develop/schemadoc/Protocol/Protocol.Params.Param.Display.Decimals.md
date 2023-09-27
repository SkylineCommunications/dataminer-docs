---
uid: Protocol.Params.Param.Display.Decimals
---

# Decimals element

Defines the number of decimals to be used to display the parameter value on the user interface.

## Type

unsignedInt

## Parent

[Display](xref:Protocol.Params.Param.Display)

## Remarks

In case the number of decimals is not specified, no rounding will occur. Only if scientific notation is used (see [scientificNotation](xref:Protocol.Params.Param.Measurement.Type-scientificNotation)), the absence of the Decimals tag will be interpreted as 0 decimals (RN 12600).

## Examples

```xml
<Decimals>2</Decimals>
```
