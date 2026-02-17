---
uid: Protocol.Chains.Chain.Field.DiagramSorting
---

# DiagramSorting element

<!-- RN 14442, RN 14468 -->

Specifies the diagram item sort order.

## Type

[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)

## Parent

[Field](xref:Protocol.Chains.Chain.Field)

## Remarks

Sorting per field (horizontal stack of items in the diagram).

- Name: sorted by the display value.
- CellSeverity: sorted by alarm severity of item and sub-items.
- BubbleUpSeverity: sorted by alarm severity of sub-items only.
- InstanceSeverity: sorted by alarm severity of item only (KPIs).

Sorting only applies to the diagram and not to the tables or lists.

Example:

```xml
<Field name="Headend" options="ShowCPEChilds;displayInFilter;ignoreEmptyFilterValues;details:11400;
tabs:11400-KPI;ShowBubbleupAndInstanceAlarmLevel" pid="11402">
   <DiagramTitleFormat>
<![CDATA[Name:\t\t{pid:1502}\nLocation:\t{pid:1503}\nCode:\t\t{pid:1504}\nTemperature:\t{pid:1506}]]>
   </DiagramTitleFormat>
   <DiagramPids>123,456,768</DiagramPids>
   <DiagramSorting>InstanceSeverity,Name</DiagramSorting>
</Field>
```

> [!NOTE]
> This renders the DiagramSort option defined in the Field@options attribute obsolete (see [DiagramSort](xref:Protocol.Chains.Chain.Field-options#diagramsort)).

It is possible to specify that the diagram items have to be sorted based on the value of a particular column parameter. This is done by specifying the ID of the column parameter.

Example:

```xml
<Field options="DiagramSort:BubbleUpSeverity:0;DiagramSort:1002:1;DiagramSort:1003:2" ...="">
```

In this example, the items will first be ordered by bubble-up alarm level, then by the value found in column 1002 and then by the value of column 1003.

> [!NOTE]
>
> - Empty values (Not Initialized) are always put at the bottom of the list.
> - If a column value changes, the diagram items will automatically be sorted again.

It is also possible to define the sort order, i.e., ascending or descending, by adding `|ASC` (for ascending order) or `|DESC` (for descending order) after the sorting field, e.g., `1506|DESC,1507|ASC`.<!-- RN 14946 -->

The default sort order is ascending.

Example: `1506|DESC,1507|ASC`
