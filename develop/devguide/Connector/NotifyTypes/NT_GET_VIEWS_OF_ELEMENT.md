---
uid: NT_GET_VIEWS_OF_ELEMENT  
---

# NT_GET_VIEWS_OF_ELEMENT (176)

Gets the ID(s) of the view(s) containing the element.

```csharp
int dmaID = 346;
int elementID = 660;
object result = protocol.NotifyDataMiner(176 /*NT_GET_VIEWS_OF_ELEMENT*/ , dmaID, elementID);

if (result != null)
{
    uint[] viewIDs = (uint[])result;
    
    foreach (uint viewID in viewIDs)
    {
        //// ...
    }
}
```

## Parameters

- dmaID (int): DataMiner Agent ID.
- elementID (int): Element ID.

## Return Value

- (uint[]): ID(s) of the view(s) that contain the specified element.
