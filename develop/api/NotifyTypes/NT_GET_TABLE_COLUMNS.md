---
uid: NT_GET_TABLE_COLUMNS
---

# NT_GET_TABLE_COLUMNS (321)

Retrieves the selected columns of a table.

> [!NOTE]
> Rather than calling `NotifyProtocol(321, ...)` directly, we recommend using the [GetColumns](xref:Skyline.DataMiner.Utils.Protocol.Extension.ProtocolExtension.GetColumns*) or [GetColumn](xref:Skyline.DataMiner.Utils.Protocol.Extension.ProtocolExtension.GetColumn*) extension methods from the [Skyline.DataMiner.Utils.Protocol.Extension](https://www.nuget.org/packages/Skyline.DataMiner.Utils.Protocol.Extension) NuGet package.

```csharp
int tablePid = 1000;
uint[] columnsToGetIdx = new uint[] { 0, 1 };
object[] columns = (object[])protocol.NotifyProtocol(321, tablePid, columnsToGetIdx);
object[] primaryKeyColumn = (object[])columns[0];
object[] valueColumn = (object[])columns[1];
```

## Parameters

- tablePid (int): ID of the table parameter.
- columnsToGetIdx (uint[]): IDXs of the columns that need to be retrieved.

## Return Value

- (object[]): Array containing object arrays for each returned column. In case an error occurred, a null reference will be returned.
