---
uid: NT_CHANGE_PARENT_OF_VIEW 
---

# NT_CHANGE_PARENT_OF_VIEW  (118)

Changes the parent view of a view.

```csharp
int viewID = 10044;
int parentViewID = -1;

protocol.NotifyDataMiner(118 /*NT_CHANGE_PARENT_OF_VIEW */, viewID, parentViewID);
```

## Parameters

- viewID (int):  ID of the view.
- parentViewID (int): The new parent view ID.

## Return Value

- Does not return an object.

## Remarks

- To make the view a child of the root view, use -1 as the value of parentViewID.
