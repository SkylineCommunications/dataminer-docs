---
uid: NT_GET_VIEW_ID
---

# NT_GET_VIEW_ID (179)

Gets the ID of the view with the specified name.

```csharp
string viewName = "HeadQuarter";

int viewID = Convert.ToInt32(protocol.NotifyDataMiner(179 /*NT_GET_VIEW_ID */ , viewName, null));
```

## Parameters

- viewName (string): Name of the view for which the ID must be obtained.

## Return Value

- (int): View ID, 0 if there is no view with the specified name.
