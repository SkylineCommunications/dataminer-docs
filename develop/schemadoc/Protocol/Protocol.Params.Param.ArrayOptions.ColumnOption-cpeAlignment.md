---
uid: Protocol.Params.Param.ArrayOptions.ColumnOption-cpeAlignment
---

# cpeAlignment attribute

Sets the alignment of KPI values in an EPM interface.<!-- RN 9430 -->

## Content Type

[EnumCpeAlignment](xref:Protocol-EnumCpeAlignment)

## Parent

[ColumnOption](xref:Protocol.Params.Param.ArrayOptions.ColumnOption)

## Remarks

Default value: right.

> [!NOTE]
>
> - The above-mentioned options are case insensitive.
> - When the table is a view, these options have to be set on the view columns, not on the columns of the base table.

## Examples

```xml
<ColumnOption idx="6" pid="12507" type="custom" cpeAlignment="left" options=";view=2507 " />
<ColumnOption idx="7" pid="12508" type="custom" cpeAlignment="center" options=";view=2508 " />
```
