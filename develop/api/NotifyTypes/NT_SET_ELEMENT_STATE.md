---
uid: NT_SET_ELEMENT_STATE
---

# NT_SET_ELEMENT_STATE (115)

Changes the state of an element.

```csharp
uint elementID = 661;
uint state = 1; // Active
uint deleteOptions = 1;
uint dmaID = 200;
uint[] elementDetails = new uint[] { elementId, state, deleteOptions, dmaID };

protocol.NotifyDataMiner(115 /*NT_SET_ELEMENT_STATE*/ , elementDetails, null);
```

## Parameters

- elementDetails (uint[]):
  - elementDetails[0]: ID of the element.
  - elementDetails[1]: State: 1=Active, 3=Pause, 4=Stop, 6=Delete, 11=Restart.
  - elementDetails[2]: Delete options; always set to 1.
  - elementDetails[3]: ID of the DataMiner Agent. Optional.<!-- RN 4226 -->

Alternatively, the element name can be used:

- elementDetails (object[]):
  - elementDetails[0] (string): Name of the element.
  - elementDetails[1] (int): State: 1=Active, 3=Pause, 4=Stop, 6=Delete, 11=Restart.
  - elementDetails[2]: Delete options; always set to 1.

## Return Value

- Does not return an object.
