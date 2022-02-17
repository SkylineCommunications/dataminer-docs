---
uid: NT_GET_ID_OF_ELEMENTS_IN_VIEW 
---

# NT_GET_ID_OF_ELEMENTS_IN_VIEW (178)

Retrieves the IDs of all elements included in the view.

```csharp
int viewID = -1;
string[] elementIDs = (string[])protocol.NotifyDataMiner(178/*GET_ID_OF_ELEMENTS_IN_VIEW*/ , viewID, null);

foreach (string elementID in elementIDs)
{
    //// ...
}
```

## Parameters

- viewID (int): ID of the view for which all contained elements must be retrieved. (Root view = -1).

## Return Value

- (string[]): Global element IDs of all elements contained in the view.
