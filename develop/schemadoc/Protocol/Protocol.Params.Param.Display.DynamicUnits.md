---
uid: Protocol.Params.Param.Display.DynamicUnits
---

# DynamicUnits element

<!-- RN 18321, RN 26318, RN26330 -->

Specifies the dynamic units that can be used.

## Parent

[Display](xref:Protocol.Params.Param.Display)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Unit](xref:Protocol.Params.Param.Display.DynamicUnits.Unit)|[1, *]|Specifies a dynamic unit.|

## Remarks

- When dynamic units are used in Visual Overview, and parameter values of parameters with "decimals" set to 1 or less are converted to a bigger unit, these will be displayed with such a number of decimals that there are at least 3 significant figures. For example, 1320 MB will be displayed as 1.32 GB, even if the parameter has 0 decimals defined.<!-- RN 27544 -->

- Dynamic units are supported on parameter pages in the Monitoring app from DataMiner 10.3.9/10.4.0 onwards.<!-- RN 36869 -->

- From DataMiner 10.4.0 [CU10]/10.5.0/10.5.1 onwards<!--RN 41436-->, or in earlier DataMiner versions if the [*DynamicUnits* soft-launch option](xref:Overview_of_Soft_Launch_Options#dynamicunits) is enabled, the following units are automatically converted even if they have not been specified using the DynamicUnits element:

  - Bytes: B, kB, MB, GB, TB, PB, EB, ZB, YB

  - Kibibytes: KiB, MiB, GiB, TiB, PiB, EiB, ZiB, YiB

  - Bits: b, kb, Mb, Gb, Tb, Pb, Eb, Zb, Yb

  - Bits per second: bps, kbps, Mbps, Gbps, Tbps, Pbps, Ebps, Zbps, Ybps

  - Bytes per second: Bps, kBps, MBps, GBps, TBps, PBps, ZBps, YBps

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
