---
uid: NT_FILL_ARRAY_WITH_COLUMN
---

# NT_FILL_ARRAY_WITH_COLUMN (220)

Sets or updates one or more table column with provided values.

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
  - values[1] (object[]): Values to set/update.

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
    > - From DataMiner 9.5.0 [CU11]/9.5.14 [CU1] (RN 19707) onwards, an object array as the last value in the array containing the table and column identifier(s) can be provided. Index 0 of this array is reserved for the "use clear and leave" flag, which can be provided and should be of type boolean.
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
  - values[1] (object[]): Values to set/update.

## Return Value

- Does not return an object.

## Remarks

- The column type must be set to "retrieved".

  ```csharp
  <ColumnOption idx="0" pid="1001" type="retrieved" options="" />
  ```

- The column data should always be wrapped in object arrays for the data to be correctly interpreted by the SLProtocol process. From DataMiner 9.0.0/9.5.9 onward, an additional safeguard is implemented to prevent access violations in case the provided data are not of the expected types (RN 14692).
- From DataMiner 9.6.6 onwards (RN 21482), it is possible to specify a datetime that will be applied to all values passed in the parameter set.
  
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

- From DataMiner 9.6.13 onwards (RN 23815), a timestamp can be provided per cell to perform a history set on cell level. This is done by providing an object array containing the value and timestamp.

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

- FillArrayWithColumn
