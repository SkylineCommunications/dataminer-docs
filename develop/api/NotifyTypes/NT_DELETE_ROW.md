---
uid: NT_DELETE_ROW
---

# NT_DELETE_ROW (156)

Removes a row from a table.

> [!NOTE]
> Rather than calling `NotifyProtocol(156, ...)` directly, we recommend using [SLProtocol.DeleteRow](xref:Skyline.DataMiner.Scripting.SLProtocol.DeleteRow*) or the [DeleteRows](xref:Skyline.DataMiner.Utils.Protocol.Extension.ProtocolExtension.DeleteRows*) extension method from the [Skyline.DataMiner.Utils.Protocol.Extension](https://www.nuget.org/packages/Skyline.DataMiner.Utils.Protocol.Extension) NuGet package.

## Parameters

Removing a row from the **local element**:

```csharp
int tableID = 1000;
string primaryKey = "Row 1";

int rowCount = (int)protocol.NotifyProtocol(156 /*NT_DELETE_ROW*/, tableID, primaryKey);
```

- tableID (int): ID of the table parameter.
- primaryKey (string): Primary key of the row that needs to be removed.

Removing a row from a **remote element**:

```csharp
uint[] ids = new uint[]
{
    (uint)protocol.DataMinerID,
    (uint)protocol.ElementID,
    (uint)tableId,
};

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
- Also supported for logger tables in the indexing database.<!-- RN 17018 -->

## See also

- [DeleteRow](xref:Skyline.DataMiner.Scripting.NotifyProtocol.DeleteRow*)
- [ClearAllKeys](xref:Skyline.DataMiner.Scripting.SLProtocol.ClearAllKeys*)
