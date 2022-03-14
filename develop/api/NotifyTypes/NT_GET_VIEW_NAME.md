---
uid: NT_GET_VIEW_NAME
---

# NT_GET_VIEW_NAME (303)

Gets the name of a view given the view ID.

```csharp
int viewID = 10045;

string viewName = (string) protocol.NotifyDataMiner(303 /*NT_GET_VIEW_NAME*/, viewID, null);
```

## Parameters

- viewID (int): The ID of the view for which the name needs to be retrieved. 

## Return Value

- (string): The name of the view. In case the view ID does not exist, an empty string is returned.
