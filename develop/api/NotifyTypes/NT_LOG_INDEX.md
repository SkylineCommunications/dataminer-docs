---
uid: NT_LOG_INDEX
---

# NT_LOG_INDEX (239)

Writes content of the index for the specified column to the element log file.

```csharp
int columnID = 2002;

protocol.NotifyProtocol(238 /* NT_REBUILD_INDEX */, columnID, null);
protocol.NotifyProtocol(239 /* NT_LOG_INDEX */, columnID, null);
```

## Parameters

- columnID (int): Parameter ID of the indexed column. 

## Return Value

- Does not return an object.

## Remarks

- This call should only be used for testing purposes.
