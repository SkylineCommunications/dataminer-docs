---
metadata_version: 1
uid: Protocol.Params.Param.ArrayOptions.ColumnOption-cpeAlignment
description: "Reference the DataMiner connector protocol schema entry for cpeAlignment attribute, including its documented structure, attributes, values, and constraint."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
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
