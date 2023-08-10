---
uid: Protocol.Params.Param.Display.DynamicUnits
---

# DynamicUnits element

Specifies the dynamic units that can be used.

## Parent

[Display](xref:Protocol.Params.Param.Display)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Unit](xref:Protocol.Params.Param.Display.DynamicUnits.Unit)|[1, *]|Specifies a dynamic unit.|

## Remarks

> [!NOTE]
>
> - A different implementation of this feature is being developed, which will make it unnecessary to specify this configuration.
> - From DataMiner 10.0.12 (RN 27544) onwards, when dynamic units are used in Visual Overview, and parameter values of parameters with "decimals" set to 1 or less are converted to a bigger unit, these will be displayed with such a number of decimals that there are at least 3 significant figures. For example, 1320 MB will be displayed as 1.32 GB, even if the parameter has 0 decimals defined.
> - Dynamic units are supported on parameter pages in the Monitoring app from DataMiner 10.3.9/10.4.0 onwards<!-- RN 36869 -->.

*Feature introduced in DataMiner 10.0.9 (RN 18321, RN 26318, RN26330).*

## Examples

```xml
<Display>
    <RTDisplay>true</RTDisplay>
    <Units>m</Units>
    <DynamicUnits>
        <Unit decimals="3">mm</Unit>
        <Unit>cm</Unit>
        <Unit>km</Unit>
    </DynamicUnits>
    <Decimals>2</Decimals>
</Display>
```
