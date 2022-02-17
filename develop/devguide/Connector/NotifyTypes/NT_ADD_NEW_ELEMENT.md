---
uid: NT_ADD_NEW_ELEMENT
---

# NT_ADD_NEW_ELEMENT (200)

Creates an element on the DMA executing this method call.

```csharp
uint viewID = 200;
string[] elementDetails = new string[] { elementName, elementConfiguration };
object[] extraInfo = new object[2];
extraInfo[0] = null;
extraInfo[1] = new uint[]{ viewID };

protocol.NotifyDataMiner(200 /*NT_ADD_NEW_ELEMENT*/, elementDetails, extraInfo);
```

## Parameters

- elementDetails (string[]):
  - elementDetails[0]: Element name.
  - elementDetails[1]: Element configuration string.
- extraInfo (object[]):
  - extraInfo[0] (object): Can be used for properties.
  - extraInfo[1] (uint[]): ID(s) of the view to which this element must be added.

## Return Value

- With this method, the view and properties can already be set.
