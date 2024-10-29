---
uid: NT_GET_INDEXES
---

# NT_GET_INDEXES (168)

Gets the primary keys and display keys of a table.

## Parameters

Retrieving the indexes of a table from the **local element**:

```csharp
int tableID = 1000;
object[] result = (object[])protocol.NotifyProtocol(168, tableID, null);

if (result != null && result.Length == 2 )
{
    if (result[0] != null)
    {
        string[] primaryKeys = (string[])result[0];
    }

    if(result[1] != null)
    {
        string[] displayKeys = (string[])result[1];
    }
}
```

- tableID (int): ID of the table parameter.

Retrieving the indexes of a table from a **remote element**:

```csharp
uint agentID = 1000;
uint elementID = 1000;
uint[] elementDetails = new uint[] { agentId, elementId };
int tableID = 1000;
object[] result = (object[])protocol.NotifyDataMiner(168, elementDetails, tableID);

if (result != null && result.Length == 2 )
{
  if (result[0] != null)
  {
     string[] primaryKeys = (string[])result[0];
  }

  if(result[1] != null)
  {
     string[] displayKeys = (string[])result[1];
  }
}
```

- elementDetails (uint[]):
  - elementDetails[0]: agent ID
  - elementDetails[1]: element ID
- tableID (int): ID of the table parameter.

## Return Value

- result (object[]): Array containing two object arrays
  - result[0] (string[]): primary keys.
  - result[1] (string[]): display keys.

In case the table does not exist, a null reference is returned.

## Remarks

- When this call is used, the SLProtocol process retrieves the primary keys and display keys from the SLElement process. Therefore, in case only the primary keys need to be retrieved, use [NT_GET_KEYS_SLPROTOCOL (397)](xref:NT_GET_KEYS_SLPROTOCOL) instead, as in this call the primary keys are retrieved in the SLProtocol process without interacting with SLElement.

## See also

- [GetKeys](xref:Skyline.DataMiner.Scripting.SLProtocol.GetKeys*)
- [ClearAllKeys](Skyline.DataMiner.Scripting.SLProtocol.ClearAllKeys*)
