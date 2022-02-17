---
uid: Protocol.Params.Param.Measurement.Type-lines
---

# lines attribute

Specifies the number of lines that will be displayed.

## Content Type

unsignedInt

## Parent

[Type](xref:Protocol.Params.Param.Measurement.Type)

## Remarks

Only to be specified in case of measurement type String.

> [!NOTE]
> From DataMiner 9.0.0 (RN 10826) onwards, read parameters with multiple lines can be displayed in the details pane of an EPM (formerly known as CPE) element. This attribute can be used to determine how many lines are displayed. See [details](xref:Protocol.Chains.Chain.Field-options#details) "details".

## Examples

```xml
<Measurement>
    <Type lines="3">string</Type>
</Measurement>
```
