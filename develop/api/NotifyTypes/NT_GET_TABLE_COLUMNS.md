---
uid: NT_GET_TABLE_COLUMNS
---

# NT_GET_TABLE_COLUMNS (321)

Retrieves the selected columns of a table.

```csharp
int tableID = 1000;
uint[] columnIndexes = new uint[] { 0, 1 };
object[] columns = (object[])protocol.NotifyProtocol(321, tableID, columnIndexes);

if (columns != null && columns.Length == 2)
{
    object[] primaryKeyColumn = (object[])columns[0];
    object[] valueColumn = (object[])columns[1];
    
    ////....
}
```

## Parameters

- tableID (int): ID of the table parameter.
- columnIndexes (uint[]): Indexes of the columns that need to be retrieved.

## Return Value

- (object[]): Array containing object arrays for each returned column. In case an error occurred, a null reference will be returned.

## Remarks

- Supported since DataMiner version 7.5.0.
