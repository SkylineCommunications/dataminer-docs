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
> When read parameters with multiple lines are displayed in the details pane of an EPM element, this attribute can be used to determine how many lines are displayed. See [details](xref:Protocol.Chains.Chain.Field-options#details).<!-- RN 10826 -->

## Examples

```xml
<Measurement>
    <Type lines="3">string</Type>
</Measurement>
```
