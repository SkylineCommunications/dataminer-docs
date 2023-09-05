---  
uid: Validator_3_24_1  
---

# CSharpNotifyDataMinerNTAssignSimulation

## DeltIncompatible

### Description

Invocation of method 'SLProtocol.NotifyDataMiner(Queued)(76\/\*NT\_ASSIGN\_SIMULATION\*\/, ...)' is not compatible with 'DELT'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.24.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Example code

```xml
uint[] elementDetails = new uint[] { agentId, elementId };
bool assignSimulation = false;

protocol.NotifyDataMinerQueued(76 /*NT_ASSIGN_SIMULATION*/ , elementDetails, assignSimulation);
```

### Details

To make this call DELT compatible, the DMA ID needs to be provided as argument.  
See Example code.  
More information about the syntax can be found in the DataMiner Development Library.
