---
uid: NT_ADD_VIEW
---

# NT_ADD_VIEW (2)

Creates a new view.

```csharp
string name = "HeadQuarter";
string parentViewID = " 10060";
string[] viewDetails = new string[] { name, parentViewID };
string[] elementIDs = new string[] { "346/661", "346/660" };

uint viewID = (uint) protocol.NotifyDataMiner(2 /*NT_ADD_VIEW*/, viewDetails, elementIDs);
```

## Parameters

- viewDetails (string[]):
  - name (string): Name of the new view.
  - parentViewID (string): ID of the view to which this new view has to be added. Specify -1 to add the view to the root view.
- elementIDs (string[]): global element IDs of the elements that should be included in the new view.

## Return Value

- (uint): The ID of the view.
