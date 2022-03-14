---
uid: NT_REBUILD_INDEX
---

# NT_REBUILD_INDEX (238)

Rebuilds the index of the specified column.

```csharp
int columnID = 1002;

 protocol.NotifyProtocol(238/*NT_REBUILD_INDEX*/ , columnID, null);
```

## Parameters

- columnID (int): ID of indexed column parameter.

## Return Value

- Does not return an object.

## Remarks

- This method call only applies to foreign key columns and indexed columns (columns having option 'indexColumn').
- When NT_GET_KEYS_FOR_INDEX is called, DataMiner first checks if the index is still up to date. If it is not, the index is rebuilt first. Therefore, in normal operation calling this method is not needed.
