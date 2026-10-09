---
uid: AdvancedDVEsSeverityState
description: "Configure the DVE severity column so the parent element can display the overall severity of a DVE element."
---

# Severity state column

To display the overall severity of a Dynamic Virtual Element (DVE) in its parent element's DVE table, add `;severity` to the `options` attribute of a retrieved `ColumnOption` element. This displays the severity without changing the DVE element's alarm state.

```xml
<ColumnOption idx="13" pid="520" type="custom" value="" options="" />
<ColumnOption idx="14" pid="530" type="retrieved" value="" options=";element" />
<ColumnOption idx="15" pid="531" type="retrieved" value="" options=";view" />
<ColumnOption idx="16" pid="533" type="retrieved" value="" options=";severity" />
```

> [!NOTE]
> The column must belong to the parent element's DVE table. Without `;severity` on the correct column, the table will not show the intended severity. Keep the column ID and table definition aligned when updating the protocol.

> [!TIP]
> For DVE table setup, see [Implementing DVEs](xref:AdvancedDVEsImplementation).
