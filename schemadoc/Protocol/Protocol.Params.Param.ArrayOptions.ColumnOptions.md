---
uid: Protocol.Params.Param.ArrayOptions.ColumnOptions
---

# ColumnOptions element

Groups ColumnOption XML elements.

## Parent

[ArrayOptions](xref:Protocol.Params.Param.ArrayOptions)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[ColumnOption](xref:Protocol.Params.Param.ArrayOptions.ColumnOptions.ColumnOption)|[1, *]||

## Remarks

*Feature introduced in DataMiner 9.0.0 (RN 11853).*

## Examples

```xml
<ArrayOptions index="0" options=";naming=/102;">
   <ColumnOptions>
     <ColumnOption idx="0" pid="101" type="snmp" options=";"/>
     <ColumnOption idx="1" pid="102" type="snmp" options=";"/>
   </ColumnOptions>
</ArrayOptions>
```
