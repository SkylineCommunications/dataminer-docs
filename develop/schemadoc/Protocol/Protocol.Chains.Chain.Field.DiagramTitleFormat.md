---
uid: Protocol.Chains.Chain.Field.DiagramTitleFormat
---

# DiagramTitleFormat element

<!-- RN 14442, RN 14468 -->

Specifies a custom title for the diagram box.

## Type

string

## Parent

[Field](xref:Protocol.Chains.Chain.Field)

## Remarks

By default, the title is the corresponding display key.

The following placeholders are supported:

- {pid:x} inserts the value of the specified field row cell (x denotes the column parameter ID to be included).
- {rowDK} inserts the display key.

To include a new line or tab, use "\n" or "\t", respectively.

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
