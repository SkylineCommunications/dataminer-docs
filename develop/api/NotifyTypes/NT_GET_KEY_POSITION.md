---
uid: NT_GET_KEY_POSITION
---

# NT_GET_KEY_POSITION (163)

Gets the (1-based) internal position of the row.

## Parameters

Retrieving the key position of a table of the **local element**:

```csharp
int tableID = 1000;
string primaryKey = "Row 4";

int keyPosition = Convert.ToInt32(protocol.NotifyProtocol(163 /*NT_GET_KEY_POSITION*/ , tableID, primaryKey));
```

- parameterID (int): ID of the table parameter.
- primaryKey (string): Primary key of the row for which the position needs to be retrieved.

Retrieving the key position of a table of a **remote element**:

```csharp
uint dmaID = 364;
uint elementID = 100;
uint parameterID = 1000;
uint[] ids = new uint[] { dmaID; elementID, parameterID };

int keyPosition = Convert.ToInt32(protocol.NotifyProtocol(163 /*NT_GET_KEY_POSITION*/ , ids, primaryKey));
```

- ids (int[]):
  - ids[0]: DataMiner Agent ID.
  - ids[1]: Element ID.
  - ids[2]: ID of the table parameter.
- primaryKey (string): Primary key of the row for which the position needs to be retrieved. 

## Return Value

- (int): The (1-based) internal position of the row in the table. If the table does not contain a row with the provided primary key, the value 0 is returned.

## See also

- [GetKeyPosition (SLProtocol)](xref:Skyline.DataMiner.Scripting.SLProtocol.GetKeyPosition(System.Int32,System.String)) method
