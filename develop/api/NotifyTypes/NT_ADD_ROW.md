---
uid: NT_ADD_ROW
---

# NT_ADD_ROW (149)

Adds a row to a table.

## Parameters

Adding a row to the **local element**:

```csharp
int tableID = 1000;
string primaryKey = "Row 1";

int rowPosition = (int) protocol.NotifyProtocol(149/*NT_ADD_ROW*/ , tableID, primaryKey);
```

- tableID (int): ID of the table parameter.
- primaryKey (string): Primary key of the row that needs to be added.

Adding a row to a **remote element**:

```csharp
uint dmaId = (uint)protocol.DataMinerID;
uint elementId = (uint)protocol.ElementID;
uint tableId = 6000;
uint[] ids = new uint[] { dmaId, elementId, tableId };
object[] rowData = new object[] { "Row 2", 100 };

int result = (int) protocol.NotifyDataMiner(149, ids, rowData);
```

- ids (uint[])
  - ids[0]: DataMiner Agent ID
  - ids[1]: Element ID
  - ids[2]: Parameter ID
- rowData (object[]): The row data.

## Return Value

- (int): The 1-based internal position of the row in the table.

## Remarks

- When no value is provided for a cell with NT_ADD_ROW (149), the cell will be set to *Not initialized*.<!-- RN 19707 -->
- To add a row with a specific timestamp:

  ```csharp
  int tableID = 1000;
  object rowData = new object[] { "Key 200", "S", "20.20" };
  DateTime timeStamp = DateTime.Now - TimeSpan.FromDays(2);

  protocol.NotifyProtocol(149 /* NT_ADD_ROW */, tableId, new object[] { rowData, timeStamp });
  ```

## See also

- [AddRow(Int32, Object[])](xref:Skyline.DataMiner.Scripting.SLProtocol.AddRow(System.Int32,System.Object[]))
