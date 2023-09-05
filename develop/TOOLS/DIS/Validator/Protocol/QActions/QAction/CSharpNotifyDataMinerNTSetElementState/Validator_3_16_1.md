---  
uid: Validator_3_16_1  
---

# CSharpNotifyDataMinerNTSetElementState

## DeltIncompatible

### Description

Invocation of method 'SLProtocol.NotifyDataMiner(Queued)(115\/\*NT\_SET\_ELEMENT\_STATE\*\/, ...)' is not compatible with 'DELT'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.16.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Example code

```xml
uint[] elementDetails = new uint[] { elementId, state, deleteOptions, dmaID };
protocol.NotifyDataMiner(115 /*NT_SET_ELEMENT_STATE*/ , elementDetails, null);
```

### Details

To make this call DELT compatible, the DMA ID needs to be provided as argument.  
See Example code.  
More information about the syntax can be found in the DataMiner Development Library.
