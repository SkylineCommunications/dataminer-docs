---
uid: NT_FILL_ARRAY_WITH_COLUMN
keywords: FillArrayWithColumn
---

# NT_FILL_ARRAY_WITH_COLUMN (220)

Sets or updates one or more table columns with provided values.

## Parameters

```csharp
int tableID = 1000;
int columnID = 1002;

object[] columnInfo = new object[] { tableID, columnID};
object[] primaryKeys = new object[]{"Row 1", "Row 2"};
object[] columnValues = new object[] { "A", "B"};
object[] values = new object[] { primaryKeys, columnValues };

protocol.NotifyProtocol(220 /*NT_FILL_ARRAY_WITH_COLUMN*/, columnInfo, values);
```

- columnInfo (object[]):
  - columnInfo[0]: ID of table parameter.
  - columnInfo[1…n]: ID of column parameter.
- values (object[]):
  - values[0] (object[]): Primary keys (as string).
  - values[1…n] (object[]): Values to set/update.

In case the column data make use of the protocol.Clear and/or protocol.Leave properties, the columnInfo array must contain an additional Boolean which is set to true indicating that the method call should consider the values corresponding with protocol.Clear and protocol.Leave as special values indicating a cell action to clear or preserve the cell content (respectively) instead of an actual cell value.

```csharp
int tableID = 1000;
int columnID = 1002;

object[] columnInfo = new object[] { tableID, columnID, true};
object[] primaryKeys = new object[]{"Row 1", "Row 2"};
object[] columnValues = new object[] { "A", protocol.Clear};
object[] values = new object[] { primaryKeys, columnValues };

protocol.NotifyProtocol(220 /*NT_FILL_ARRAY_WITH_COLUMN*/, columnInfo, values);
```

- columnInfo (object[]):
  - columnInfo[0]: ID of table parameter.
  - columnInfo[1…n-1]: ID of column parameter.
  - columnInfo[n] (bool): When setting a single column, you can add a boolean value as a third value in the array containing the table and column identifier (In case this value is not provided, it is false by default). If this value is set to true, the protocol.Clear and protocol.Leave properties can be used as cell values indicating that the content of a cell should be cleared or preserved, respectively.

    > [!NOTE]
    >
    > - The Boolean value is only supported when a single column is set. In case you want to use protocol.Clear and protocol.Leave when setting multiple columns, use an object array as described below.
    > - It is possible to add an object array as the last value in the array containing the table and column identifier(s). Index 0 of this array is reserved for the "use clear and leave" flag, which can be provided and should be of type boolean.<!-- RN 19707 -->
    >
    > Example:
    >
    > ```csharp
    > bool useClearAndLeave = true;
    > 
    > protocol.NotifyProtocol(220, new object[] { 1000, 1009, new object[] { useClearAndLeave } }, new object[] { fillArray[0], fillArray[8] });
    > ```

- values (object[]):
  - values[0] (object[]): Primary keys (as string).
  - values[1…n] (object[]): Values to set/update.

## Return Value

- Does not return an object.

## Remarks

- The column type must be set to "retrieved".

  ```csharp
  <ColumnOption idx="0" pid="1001" type="retrieved" options="" />
  ```

- The column data should always be wrapped in object arrays for the data to be correctly interpreted by the SLProtocol process.

- It is possible to specify a datetime that will be applied to all values passed in the parameter set.<!-- RN 21482 -->

  ```csharp
  protocol.NotifyProtocol(220/*NT_FILL_ARRAY_WITH_COLUMN*/ , new object[] { <TablePid>, <ColumnPid>, new object[2] { <bOverrideBehaviour_bool>,<DateTime>}}, Values);
  ```

  For example:

  ```csharp
  int tableID = 1000;
  int columnID = 1002;
  bool allowClearAndLeave = true;
  DateTime timestamp = DateTime.Now;

  object[] columnInfo = new object[] { tableID, columnID, new object[] { allowClearAndLeave, timestamp }};
  object[] primaryKeys = new object[]{"Row 1", "Row 2"};
  object[] columnValues = new object[] { "A", protocol.Clear};
  object[] values = new object[] { primaryKeys, columnValues };

  protocol.NotifyProtocol(220 /*NT_FILL_ARRAY_WITH_COLUMN*/, columnInfo, values);
  ```

- A timestamp can be provided per cell to perform a history set on cell level. This is done by providing an object array containing the value and timestamp.<!-- RN 23815 -->

  Note that not all cells require a timestamp. If no timestamp is specified, DateTime.Now will be used.

  ```csharp
  int tableID = 1000;
  int columnID = 1002;
  
  object[] columnInfo = new object[] { tableID, columnID };
  object[] primaryKeys = new object[] { "Row 1", "Row 2" };
  object[] columnValues = new object[] { "A", new object[] { "B" , DateTime.Now - TimeSpan.FromDays(5) } };
  object[] values = new object[] { primaryKeys, columnValues };
  
  protocol.NotifyProtocol(220 /*NT_FILL_ARRAY_WITH_COLUMN*/, columnInfo, values);
  ```

## See also

- [FillArrayWithColumn (SLProtocol)](xref:Skyline.DataMiner.Scripting.SLProtocol.FillArrayWithColumn(System.Int32,System.Int32,System.Object[],System.Object[])) method
