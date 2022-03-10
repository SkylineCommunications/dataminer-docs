---
uid: NT_GET_KEYS_SLPROTOCOL
---

# NT_GET_KEYS_SLPROTOCOL (397)

Retrieves the primary keys of a table from the SLProtocol process without interacting with the SLElement process.

```csharp
int tableID = 1000;
string[] primaryKeys = (string[])protocol.NotifyProtocol(397, tableID, null);

if (primaryKeys != null && primaryKeys.Length > 0)
{
    ////...
}
```

## Parameters

- tableID (int): ID of the table parameter.

## Return Value

- (string[]): Primary keys of the table. In case there is no table with the specified ID, a null reference is returned.

## Remarks

- This call does not make use of the SLElement process to retrieve the primary keys. Therefore, in case only the primary keys are needed, this call is favored over the NT_GET_INDEXES (168) call. See <xref:NT_GET_INDEXES>.
- The GetKeys extension method defined in the NotifyProtocol class (Skyline.DataMiner.Scripting) performs this call in case the primary keys are requested (type=KeyType.Index).
