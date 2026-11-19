---
uid: NT_FILL_ARRAY_NO_DELETE
---

# NT_FILL_ARRAY_NO_DELETE (194)

Adds the provided content to the specified table.

> [!NOTE]
> Rather than calling `NotifyProtocol(194, ...)` directly, we recommend using [SLProtocol.FillArrayNoDelete](xref:Skyline.DataMiner.Scripting.SLProtocol.FillArrayNoDelete*) or `FillArray` with `SaveOption.Partial`.

```csharp
int tableID = 1000;
object[] column1 = new object[] { "Row 1", "Row 2" };
object[] column2 = new object[] { "E", "F" };
object[] tableContent = new object[] { column1, column2 };

protocol.NotifyProtocol(194 /*NT_FILL_ARRAY_NO_DELETE*/, tableID, tableContent);
```

## Parameters

- tableID (int): ID of the table parameter.
- tableContent (object[]): content to add.

## Return Value

- bool: true or a null reference in case an error occurred (e.g., in case invalid data was provided).

## Remarks

- In case the column data contains null references, the corresponding cells will be cleared.
- When NT_FILL_ARRAY_NO_DELETE is used, the column type must be set to "retrieved".  In case other column types are present between the specified columns (e.g., columns of type "custom"), these other columns will be skipped.
- The FillArrayNoDelete method cannot be used together with the "autoincrement" column option.
- To set an additional flag indicating that some cells should be cleared (using protocol.Clear) or preserved (using protocol.Leave), set the second entry of the tableInfo to true as indicated below:<!-- RN 7351 -->

  ```csharp
  object tableInfo = new object[] { 10, true }; // Setting the second entry to true enables the use of the protocol.Clear and protocol.Leave functionality.
  object[] tableData = new object[]
  {
      new object[] { "1-Index", "2-Index", "3-Index" },
      new object[] { 10, 10, 10 },
      new object[] { protocol.Clear, protocol.Clear, protocol.Clear },
      new object[] { 30, 30, 30 },
  };

  protocol.NotifyProtocol(194, tableInfo, tableData);
  ```

- To specify a datetime that will be applied to all values passed in the parameter set, set the third entry of tableInfo as indicated below:<!-- RN 21482 -->

  ```csharp
  object tableInfo = new object[] { 10, false, DateTime.Now };
  object[] tableData = new object[]
  {
      new object[] { "1-Index", "2-Index", "3-Index" },
      new object[] { 10, 10, 10 },
      new object[] { 10, 10, 10 },
      new object[] { 30, 30, 30 },
  };

  protocol.NotifyProtocol(194, tableInfo, tableData);
  ```

- A timestamp can be provided per cell to perform a history set on cell level. This is done by providing an object array containing the value and timestamp.<!-- RN 23815 -->

  Note that not all cells require a timestamp. If no timestamp is specified, DateTime.Now will be used.

  ```csharp
  int tableID = 2000;
  object[] column1 = new object[] { "Row 1", "Row 2" };
  object[] column2 = new object[] { "A", new object[] { "B", DateTime.Now - TimeSpan.FromDays(11) } };
  object[] tableContent = new object[] { column1, column2 };

  object result = protocol.NotifyProtocol(194 /*NT_FILL_ARRAY_NO_DELETE*/, tableID, tableContent);
  ```

## See also

- [RowCount (SLProtocol)](xref:Skyline.DataMiner.Scripting.SLProtocol.RowCount(System.Object)) method
