---  
uid: Validator_3_28_1  
---

# CSharpNotifyDataMinerNTServiceSetVdx

## DeltIncompatible

### Description

Invocation of method 'SLProtocol.NotifyDataMiner(Queued)(232\/\*NT\_SERVICE\_SET\_VDX\*\/, ...)' is not compatible with 'DELT'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.28.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Example code

```xml
string serviceInfo = dmaId + "/" + serviceId;
string serviceVdx = "Visio|1";

protocol.NotifyDataMiner(232 /*NT_SERVICE_SET_VDX*/ , serviceInfo, serviceVdx);
```

### Details

To make this call DELT compatible, the DMA ID needs to be provided as argument.  
See Example code.  
More information about the syntax can be found in the DataMiner Development Library.
