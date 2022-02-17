---
uid: NT_DELETE_ELEMENT
---

# NT_DELETE_ELEMENT (5)

Removes an element from a view.

```csharp
int viewID = 10008;

string[] elementIDs = new string[] { "346/675" };

int result = (int) protocol.NotifyDataMinerQueued(5 /*NT_DELETE_ELEMENT*/ , viewID, elementIDs);
```

## Parameters

- viewID (int): ID of the view that the element will be removed from.
- elementIDs (string[]): Global element ID or IDs of the element or elements that need to be removed from the view.

## Return Value

- (int): Result value. 0 indicates the call succeeded.
