---  
uid: Validator_3_17_1  
---

# CSharpNotifyDataMinerNTSetAlarmState

## DeltIncompatible

### Description

Invocation of method 'SLProtocol.NotifyDataMiner(Queued)(116\/\*NT\_SET\_ALARM\_STATE\*\/, ...)' is not compatible with 'DELT'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.17.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Example code

```xml
object elementDetails = new uint[] {elementID, state, dmaID};
object maskDetails = new string[] {maskType, comment};

protocol.NotifyDataMiner(116 /* NT_SET_ALARM_STATE */, elementDetails, maskDetails);
```

### Details

To make this call DELT compatible, the DMA ID needs to be provided as argument.  
See Example code.  
More information about the syntax can be found in the DataMiner Development Library.
