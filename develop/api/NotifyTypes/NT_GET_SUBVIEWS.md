---
uid: NT_GET_SUBVIEWS
---

# NT_GET_SUBVIEWS (203)

Gets the names and IDs of all child views of a view.

```csharp
int viewID = 10008;
object[] childViews = (object[])protocol.NotifyDataMiner(203/*NT_GET_SUBVIEWS*/, viewID, null);
string[] childViewNames = (string[])childViews[0];
int[] childViewIDs = (int[])childViews[1];

for (int i = 0; i < childViewNames.Length; i++)
{
    string childViewName = childViewNames[i];
    int childViewID = childViewIDs[i];

    ////...
}
```

## Parameters

- viewID (int): The ID of the view for which the child views need to be retrieved.

## Return Value

- childViews (object[]):
  - childViews[0] (string[]): Array containing the names of the child views.
  - childViews[1] (int[]): Array containing the IDs of the child views.
