---
uid: NT_SET_ROW
---

# NT_SET_ROW (225)

Sets the data of the specified row to the specified values.

## Parameters

Preforming a set on the **local element**:

```csharp
object[] rowDetails = new object[]{1000, "Row 5"};
object[] rowData = new object[] { null, 4, "Main" };
object result = protocol.NotifyProtocol(225, rowDetails, rowData);

if (result != null)
{
    object[] res = (object[])result;

    ////...
}
else
{
    ////...
}
```

- rowDetails (object[]): The details specifying the row:
  - rowDetails[0]: table ID.
  - rowDetails[1]: (string) primary key.
  - rowDetails[2]: (DateTime) timestamp (optional).
  - rowDetails[3]: (bool) enableCellActions: When set to true, protocol.Clear and protocol.Leave can be used as cell values, which will clear or preserve the cell content, respectively. (Optional, default: false.)
- rowData (object[]): The row data to set. In order to preserve the value of a cell, provide a null reference for that cell.

Performing a set on a **remote element**:

```csharp
int dmaId = protocol.DataMinerID;
int elementId = protocol.ElementID;
int tableId = 6000;
string primaryKey = "1";
object[] rowDetails = new object[4];

rowDetails[0] = dmaId;
rowDetails[1] = elementId;
rowDetails[2] = tableId;
rowDetails[3] = primaryKey;

object[] rowData = new object[] { null, "test" };
object[] result = (object[]) protocol.NotifyDataMiner(225 /*NT_SET_ROW*/, rowDetails, rowData);
```

- rowDetails (object[]): The details specifying the row.
  - rowDetails[0]: (int) DataMiner Agent ID.
  - rowDetails[1]: (string) element ID.
  - rowDetails[2]: (int) table parameter ID.
  - rowDetails[3]: (string) primary key.
- rowData (object[]): The row data to set. In order to preserve the value of a cell, provide a null reference for that cell.

## Return Value

- (object): In case the call was executed, an object[] is returned. The length of this array equals the length of the rowData array.

## Remarks

- The SLProtocol interface defines a wrapper method "SetRow" for this call. See [SLProtocol.SetRow](xref:Skyline.DataMiner.Scripting.SLProtocol.SetRow(System.Int32,System.Int32,System.Object)) method.
- On a table with the *AutoAdd* option with a key that does not exist yet, NT_SET_ROW (225) will ignore protocol.Leave and protocol.Clear values. The "use clear and leave" flag must be set to true.<!-- RN 19707 -->
