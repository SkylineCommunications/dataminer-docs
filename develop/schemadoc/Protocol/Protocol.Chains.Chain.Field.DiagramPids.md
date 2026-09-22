---
metadata_version: 1
uid: Protocol.Chains.Chain.Field.DiagramPids
description: "Reference the DataMiner connector protocol schema entry for DiagramPids element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# DiagramPids element

<!-- RN 14442, RN 14468 -->

Specifies the IDs of the (read) parameters to be shown in the diagram box.

## Type

[TypeCommaSeparatedNumbers](xref:Protocol-TypeCommaSeparatedNumbers)

## Parent

[Field](xref:Protocol.Chains.Chain.Field)

## Remarks

> [!NOTE]
> This renders the KPIsInDiagram option defined in the Field@options attribute obsolete (see [KPIsInDiagram](xref:Protocol.Chains.Chain.Field-options#kpisindiagram)).

## Examples

```xml
<Field name="Headend" options="ShowCPEChilds;displayInFilter;ignoreEmptyFilterValues;details:11400;tabs:11400-KPI;ShowBubbleupAndInstanceAlarmLevel" pid="11402">
   <DiagramTitleFormat>
<![CDATA[Name:\t\t{pid:1502}\nLocation:\t{pid:1503}\nCode:\t\t{pid:1504}\nTemperature:\t{pid:1506}]]>
   </DiagramTitleFormat>
   <DiagramPids>123,456,768</DiagramPids>
   <DiagramSorting>InstanceSeverity,Name</DiagramSorting>
</Field>
```
