---
metadata_version: 1
uid: AdvancedDVEsSeverityState
description: "Configure the DVE severity column so the parent element can display the overall severity of a DVE element."
---

# Severity state column

To have the overall DVE element severity in the main DVE table on the parent element, use the severity option on a column.

## Audience and prerequisites

Use this configuration when you are implementing dynamic virtual elements (DVEs) and need their overall severity to be visible in the parent element's DVE table. You should already understand the DVE table layout and `ColumnOption` syntax.

<a id="advanced-dves-severity-state-scope"></a>

## Scope

Set the `options` value of a retrieved DVE column to include `;severity`. The column must be part of the parent element's DVE table; this option does not calculate or change the alarm state of the child element.

## Expected result

DataMiner uses the selected column to display the overall severity of the DVE element in the parent element's DVE table.

<a id="advanced-dves-severity-state-failure-and-edge-cases"></a>

## Failure and edge cases

If the `;severity` option is omitted or applied to a column that is not used in the DVE table, the parent table will not expose the intended severity state. Keep the column ID and DVE table definition aligned when the protocol changes.

```xml
<ColumnOption idx="13" pid="520" type="custom" value="" options="" />
<ColumnOption idx="14" pid="530" type="retrieved" value="" options=";element" />
<ColumnOption idx="15" pid="531" type="retrieved" value="" options=";view" />
<ColumnOption idx="16" pid="533" type="retrieved" value="" options=";severity" />
```

## Related concepts

- [Advanced DVEs](xref:AdvancedDVEs)
- [Implementing DVEs](xref:AdvancedDVEsImplementation)
- [ColumnOption element](xref:Protocol.Params.Param.ArrayOptions.ColumnOption)

## Authoritative references

- [DVE table configuration](xref:AdvancedDVEs)
- [Protocol XML schema](xref:SchemaProtocol)
