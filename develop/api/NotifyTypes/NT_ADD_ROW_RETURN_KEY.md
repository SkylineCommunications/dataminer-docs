---
uid: NT_ADD_ROW_RETURN_KEY
---

# NT_ADD_ROW_RETURN_KEY (240)

Adds a row to a table and returns the primary key of the created row.

```csharp
int tableID = 1000;
string primaryKey = "Row 1";

string rowPrimaryKey = Convert.ToString(protocol.NotifyProtocol(240 /*NT_ADD_ROW_RETURN_KEY*/, tableID, primaryKey));
```

## Parameters

- tableID (int): ID of table parameter.

- primaryKey (string): Primary key of row to add. Set to null for tables with auto-incrementing keys.

## Return Value

- rowPrimaryKey (string): Primary key of the created row (useful when working used on tables with auto-incrementing keys).

## See also

- [AddRowReturnKey (SLProtocol)](xref:Skyline.DataMiner.Scripting.SLProtocol.AddRowReturnKey(System.Int32))
- [AddRowReturnKey (QActionTable)](xref:Skyline.DataMiner.Scripting.QActionTable.AddRowReturnKey)
