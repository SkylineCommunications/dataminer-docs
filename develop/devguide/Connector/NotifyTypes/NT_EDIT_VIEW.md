---
uid: NT_EDIT_VIEW
---

# NT_EDIT_VIEW (6)

Renames a view.

```csharp
int viewID = 10008;

string newName = "HeadQuarter";

protocol.NotifyDataMiner(6 /*NT_EDIT_VIEW*/, viewID, newName);
```

## Parameters

- viewID (int): ID of the view that will be renamed.
- newName (string): New name of the view.

## Return Value

- Does not return an object.
