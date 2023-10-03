---
uid: NT_FILL_ARRAY_WITH_COLUMN_ONLY_UPDATES
---

# NT_FILL_ARRAY_WITH_COLUMN_ONLY_UPDATES (336)

## Parameters

To set a column on the **local element**, performing an NT_FILL_ARRAY_WITH_COLUMN_ONLY_UPDATES via NotifyProtocol behaves in the exact same way as [NT_FILL_ARRAY_WITH_COLUMN (220)](xref:NT_FILL_ARRAY_WITH_COLUMN).

To set a column on a **remote element**:

```csharp
uint elementAgentId = 200;
uint elementElementId = 1;
uint tableId = 1000;
uint columnPid = 1002;

var ids = new[] { elementAgentId, elementElementId, tableId, columnPid };

object[] primaryKeys = new object[] { "Row 1", "Row 2" };
object[] columnValues = new object[] { "X", "Y" };

object[] values = new object[] { primaryKeys, columnValues };

protocol.NotifyDataMiner(336 /*NT_FILL_ARRAY_WITH_COLUMN_ONLY_UPDATES*/, ids, values);/
```

- ids (uint[]):
  - ids[0]: DMA ID
  - ids[1]: Element ID
  - ids[2]: Parameter ID of table
  - ids[3]: Parameter ID of column to set

## Remarks

From DataMiner 10.3.10 onwards (RN 36973), the NotifyDataMiner call supports setting multiple columns at once. For example:

```csharp
uint elementAgentId = 200;
uint elementElementId = 1;
uint tableId = 1000;
uint columnPid = 1002;
uint columnPid2 = 1003;

var ids = new[] { elementAgentId, elementElementId, tableId, columnPid, columnPid2 };

object[] primaryKeys = new object[] { "Row 1", "Row 2" };
object[] columnValues = new object[] { "X", "Y" };
object[] column2Values = new object[] { "A", "B" };

object[] values = new object[] { primaryKeys, columnValues, column2Values };

protocol.NotifyDataMiner(336 /*NT_FILL_ARRAY_WITH_COLUMN_ONLY_UPDATES*/, ids, values);/
```

## See also

- [NT_FILL_ARRAY_WITH_COLUMN (220)](xref:NT_FILL_ARRAY_WITH_COLUMN)
