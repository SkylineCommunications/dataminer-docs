---
uid: NT_GET_ROW
---

# NT_GET_ROW (215)

Retrieves a row from a table.

## Parameters

Retrieving a row from the **local element**:

```csharp
int tableId = 6000;
string primaryKey = "Row 1";

object[] rowIdentification = new object[] { tableId, primaryKey };
object[] row = (object[])protocol.NotifyProtocol(215, rowIdentification, null);
```

- rowIdentification (object[]):
- rowIdentification[0] (int): ID of the table parameter.
- rowIdentification[1] (string): Primary key of the row to retrieve. 

Retrieving a row from a **remote element**:

```csharp
int dmaID = 346;
int elementID = 806;
int tableID = 1000;
string primaryKey = "Row 886";

object[] rowIdentification = new object[] { dmaID, elementID, tableID, primaryKey };
object[] rowData = (object[])protocol.NotifyDataMiner(215, rowIdentification, null);
```

- rowIdentification (object[]):
  - rowIdentification[0] (int): DMA ID.
  - rowIdentification[1] (int): Element ID.
  - rowIdentification[2] (int): ID of the table parameter.
  - rowIdentification[3] (string): Primary key of the row to retrieve.

## Return Value

Retrieving a row from the **local element**:

- object[]): Object array containing the row data.

  In case the specified table ID does not exist or is not a table parameter, null is returned.
  In case there is no row with the specified key in the table, an object array with empty cells is returned.

Retrieving a row from a **remote element**:

- object[]): Object array containing the row data.
  
  In case there is no row with the specified key in the table, a null reference is returned.

## Remarks

- The [GetRow (SLProtocol)](xref:Skyline.DataMiner.Scripting.SLProtocol.GetRow(System.Int32,System.String)) and [GetRow (QActionTable)](xref:Skyline.DataMiner.Scripting.QActionTable.GetRow(System.String)) method acts as a wrapper method for this Notify call.
