---
uid: NT_PUT_PARAMETER_INDEX
---

# NT_PUT_PARAMETER_INDEX (121)

Sets the value of a cell in a table, identified by the primary key (or row number) of the row and column position, with the specified value.


## Parameters

Setting a **single cell**:

```csharp
int tableId = 1000;
string rowKey = "20";
int columnNumber = 4;
string value = "myValue";
object[] cellIdentifier = new object[] { tableId, rowKey, columnNumber };

bool result = (bool) protocol.NotifyProtocol(121, cellIdentifier, value);
```

- cellIdentifier (object[]):
  - cellIdentifier[0] (int): table ID
  - cellIdentifier[1] (string): row key
  - cellIdentifier[2] (int): 1-based column position
- value: The cell value. In case a time stamp should be provided as well, value should be an object array of size two, where the first entry denotes the value and the second entry the DateTime value.

Setting **multiple cells**:

```csharp
int[] tableIds = new int[] { 1000, 1000};
string[] rowKeys = new string[] { "6", "8" };
int[] columnNumbers = new int[] { 4, 4 };
object[] cellIdentifiers = new object[] { tableIds, rowKeys, columnNumbers };
object[] values = new object[] { new object[] { "Value X", "Value Y" } };

uint[] result = (uint[]) protocol.NotifyProtocol(121, cellIdentifiers, values);
```

- cellIdentifiers (object[]):
  - cellIdentifiers[0] (int[]): table IDs
  - cellIdentifiers[1] (string[]): row keys
  - cellIdentifiers[2] (int[]): 1-based column positions
- value: The cell values. In case a time stamp should be provided as well, value should be an object array of size two, where the first entry denotes the values and the second entry the DateTime values.

## Return Value

Setting a **single cell**:

- (bool): Value indicating whether the cell value has changed. *true* indicates success; otherwise *false*.

Setting **multiple cells**:

- (uint[]): HRESULT values.

## Remarks

- When setting a single cell, make sure to use the syntax as shown in the "setting a single cell" section above. The syntax shown in "Setting multiple cells" does not work when the arrays tableIds, rowKeys, columnNumbers and values only have a single item.
  - The SLProtocol interface defines the following wrapper methods for this call.
  - SetParameterIndex (see SLProtocol.SetParameterIndex method)
  - SetParameterIndexByKey (see SLProtocol.SetParameterIndexByKey method)
  - SetParametersIndex (see SLProtocol.SetParametersIndex method)
  - SetParametersIndexByKey (see SLProtocol.SetParametersIndexByKey method)

Example:

Setting multiple cell values with a time stamp:

```csharp
int[] tableIds = new int[] { 1000, 1000};
string[] rowKeys = new string[] { "6", "8" };
int[] columnNumbers = new int[] { 4, 4 };
object[] cellIdentifiers = new object[] { tableIds, rowKeys, columnNumbers };

object[] values = new object[] { new object[] { "Value X", "Value Y" }, new object[] { DateTime.Now, DateTime.Now } };

uint[] result = (uint[]) protocol.NotifyProtocol(121, cellIdentifiers, values);
```
