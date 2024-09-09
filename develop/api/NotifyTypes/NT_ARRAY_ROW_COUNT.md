---
uid: NT_ARRAY_ROW_COUNT
---

# NT_ARRAY_ROW_COUNT (195)

Gets the number of rows in a table.

```csharp
int tableID = 2000;

int numberOfRows = (int) protocol.NotifyProtocol(195/*NT_ARRAY_ROW_COUNT*/ , tableID, null);
```

## Parameters

- tableID (int): ID of the table parameter.

## Return Value

- (int): The number of rows the table contains. If the table was not found, a value of -1 is returned.

## See also

- [RowCount (SLProtocol)](xref:Skyline.DataMiner.Scripting.SLProtocol.RowCount(System.Object)) method
