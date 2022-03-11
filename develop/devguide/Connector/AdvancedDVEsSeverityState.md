---
uid: AdvancedDVEsSeverityState
---

# Severity state column

Since DataMiner version 8.0, it is possible to have the overall DVE element severity in the main DVE table on the parent element. This is done using the severity option on a column.

```xml
<ColumnOption idx="13" pid="520" type="custom" value="" options="" />
<ColumnOption idx="14" pid="530" type="retrieved" value="" options=";element" />
<ColumnOption idx="15" pid="531" type="retrieved" value="" options=";view" />
<ColumnOption idx="16" pid="533" type="retrieved" value="" options=";severity" />
```
