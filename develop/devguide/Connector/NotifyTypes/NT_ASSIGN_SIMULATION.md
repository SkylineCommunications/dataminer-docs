---
uid: NT_ASSIGN_SIMULATION
---

# NT_ASSIGN_SIMULATION (76)

Assigns a DataMiner simulation to an element.

```csharp
uint agentId = 400;
uint elementId = 10;
uint[] elementDetails = new uint[] { agentId, elementId };
bool assignSimulation = false;

protocol.NotifyDataMinerQueued(76 /*NT_ASSIGN_SIMULATION*/ , elementDetails, assignSimulation);
```

## Parameters

- elementDetails (uint[]):
  - elementDetails[0]: Agent ID of the element.
  - elementDetails[1]: ID of the element.
- assignSimulation (bool): "true" to assign, "false" to remove the simulation assignment.

## Return Value

- Does not return an object.

## Remarks

- This method call should only be used for testing purposes.
- This method call will cause a restart of the element. Therefore, NotifyDataMinerQueued should be used when this method is not performed on a remote element.
