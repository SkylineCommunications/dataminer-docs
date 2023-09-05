---  
uid: Validator_3_25_1  
---

# CSharpNotifyDataMinerNTGetValue

## DeltIncompatible

### Description

Invocation of method 'SLProtocol.NotifyDataMiner(69\/\*NT\_GET\_VALUE\*\/, ...)' is not compatible with 'DELT'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.25.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Example code

```xml
uint[] elementDetails = new uint[] { agentId, elementId };
int parameterId = 120;

object[] result = (object[]) protocol.NotifyDataMiner(69 /*NT_GET_VALUE*/, elementDetails, parameterId);
```

### Details

To make this call DELT compatible, the DMA ID needs to be provided as argument.  
See Example code.  
More information about the syntax can be found in the DataMiner Development Library.
