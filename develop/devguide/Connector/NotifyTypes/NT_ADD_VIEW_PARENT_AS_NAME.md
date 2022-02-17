---
uid: NT_ADD_VIEW_PARENT_AS_NAME
---

# NT_ADD_VIEW_PARENT_AS_NAME (326)

Adds a new view to the view with the provided name.

```csharp
string viewName = "Site A";
string parentViewName = "HeadQuarter";
string[] viewDetails = new string[] { viewName, parentViewName };
string[] elementIDs = new string[] { "346/660" };

uint viewID = (uint) protocol.NotifyDataMiner(326 /*NT_ADD_VIEW_PARENT_AS_NAME*/ , viewDetails, elementIDs);
```

## Parameters

- viewDetails (string[]):
  - viewDetails[0]: Name of the new view to add.
  - viewDetails[1]: Name of the parent view to which the new view will be added.
- elementIDs (string[]):
  - elementIDs (string[]): Global element IDs of elements that must be added to the new view (null if no elements need to be added).

## Return Value

- (uint): ID of the newly created view. If the view already exists, a null reference is returned.
