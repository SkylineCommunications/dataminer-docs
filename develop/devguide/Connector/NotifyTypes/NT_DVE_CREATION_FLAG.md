---
uid: NT_DVE_CREATION_FLAG
---

# NT_DVE_CREATION_FLAG (340)

Enables or disables the creation of DVEs.

```csharp
uint dmaID = 346;
uint elementID = 793;
uint[] elementDetails = new uint[] { dmaID, elementID };
int createDve = 0;

protocol.NotifyDataMiner(340/*NT_DVE_CREATION_FLAG*/ , elementDetails, createDve);
```

## Parameters

- elementDetails (uint[]):
  - elementDetails[0]: DataMiner Agent ID
  - elementDetails[1]: Element ID
- createDve (int): 0 = disable the creation of DVEs, 1 = enable the creation of DVEs.

## Return Value

- Does not return an object.

## Remarks

- When the creation is disabled, all the existing DVEs will disappear from the system for the specified parent element. The existing element IDs of the DVEs will also be cleared. When the creation of DVEs is enabled again, new element IDs will be assigned for the DVEs and the DVEs will be recreated.
- Since DataMiner version 8.0.3, the toggling of DVE creation is supported in the element wizard (in Cube only).
- Calling this method will set the dvecreate attribute of the Name tag in the Element.xml file of the element.
