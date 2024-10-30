---
uid: NT_EXISTS_ROW 
---

# NT_EXISTS_ROW (265)

Checks if a row with the provided primary key exists in the table.

```csharp
int tableID = 1000;
string primaryKey = "Row 1";

bool rowExists = Convert.ToBoolean(protocol.NotifyProtocol(265/*NT_EXISTS_ROW*/, tableID, primaryKey));
```

## Parameters

- tableID (int): ID of the table parameter.
- primaryKey (string): Primary key.

## Return Value

- (bool): True = row exists, False = row does not exist.

## See also

- [Exists (SLProtocol)](xref:Skyline.DataMiner.Scripting.SLProtocol.Exists(System.Int32,System.String)) method
