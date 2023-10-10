---
uid: NT_DELETE_ROW
---

# NT_DELETE_ROW (156)

Removes a row from a table.



## Parameters

Removing a row from the **local element**:

```csharp
int tableID = 1000;
string primaryKey = "Row 1";

int rowCount = (int)protocol.NotifyProtocol(156/*NT_DELETE_ROW*/ , tableID, primaryKey);
```

- tableID (int): ID of the table parameter.
- primaryKey (string): Primary key of the row that needs to be removed. 

Removing a row from a **remote element**:

```csharp
uint[] ids = new uint[3];
ids[0] = (uint)protocol.DataMinerID;
ids[1] = (uint)protocol.ElementID;
ids[2] = (uint)tableId;

string primaryKey = "Row 1";

int rowCount = (int)protocol.NotifyDataMiner(156 /*NT_DELETE_ROW*/, ids, primaryKey);
```

- ids (uint[]):
  - ids[0]: DataMiner Agent ID.
  - ids[1]: Element ID
  - ids[2]: table parameter ID
- primaryKey (string): Primary key of the row that needs to be removed.

## Return Value

- (int) Number of remaining rows in the table.

## Remarks

- In order to delete multiple rows, provide a string array containing the primary keys of the rows to remove as second parameter.
- Also supported for logger tables in the indexing database from DataMiner 9.6.4 (RN 17018) onwards.

## See also

- DeleteRow
- ClearAllKeys
