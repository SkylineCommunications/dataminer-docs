---
uid: NT_DELETE_VIEW
---

# NT_DELETE_VIEW (4)

Deletes the specified view.

```csharp
int viewID = 10008;

protocol.NotifyDataMiner(4 /*NT_DELETE_VIEW*/, viewID, null);
```

## Parameters

- viewID (int): The ID of the view to delete (Root view ID = -1).

## Return Value

- Does not return an object.
