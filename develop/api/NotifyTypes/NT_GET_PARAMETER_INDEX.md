---
uid: NT_GET_PARAMETER_INDEX
---

# NT_GET_PARAMETER_INDEX (122)

Gets the value of the specified cell in the specified table.

```csharp
uint tableID = 1000;
uint rowPosition = 1;
uint columnPosition = 2;
uint[] cellDetails = new uint[] { tableID, rowPosition, columnPosition };
object result = protocol.NotifyProtocol(122, cellDetails, null);

if (result != null)
{
    ////...
}
else
{
    ////...
}
```

## Parameters

- When specifying the row by the 1-based position, the second parameter should be an uint[]:
  - cellDetails[0]: The ID of the table parameter.
  - cellDetails[1]: The 1-based position of the row.
  - cellDetails [2]: The 1-based position of the column.
- When specifying the row by its primary key, the second parameter should be an object[]:
  - cellDetails[0] (int): The ID of the table parameter.
  - cellDetails[1] (string): The primary key of the row.
  - cellDetails [2] (int): The 1-based position of the column.

## Return Value

- (object): The value of the cell.

## Remarks

- This SLProtocol interface defines two wrapper methods for this call: `GetParameterIndex` and `GetParameterIndexByKey`. See [GetParameterIndex (SLProtocol)](xref:Skyline.DataMiner.Scripting.SLProtocol.GetParameterIndex(System.Int32,System.Int32,System.Int32)) and [GetParameterIndexByKey (SLProtocol)](xref:Skyline.DataMiner.Scripting.SLProtocol.GetParameterIndexByKey(System.Int32,System.String,System.Int32)) methods.
- When a GetParameterIndex call fails because the retrieved cell falls outside the bounds of the table, a null reference is returned and the following message is logged: "NotifyProtocol with 122 failed. 0x80040244".
- When a GetParameterIndex call fails because the protocol does not contain a table parameter with the provided table ID, a null reference is returned and the following message is logged: "NotifyProtocol with 122 failed. 0x80040221".
