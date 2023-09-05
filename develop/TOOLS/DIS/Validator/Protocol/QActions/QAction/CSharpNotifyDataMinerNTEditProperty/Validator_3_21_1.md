---  
uid: Validator_3_21_1  
---

# CSharpNotifyDataMinerNTEditProperty

## DeltIncompatible

### Description

Invocation of method 'SLProtocol.NotifyDataMiner(Queued)(62\/\*NT\_EDIT\_PROPERTY\*\/, ...)' is not compatible with 'DELT'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.21.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Example code

```xml
string propertyLocation = "element:"+ elementId + ":" + agentId;
string[] propertyDetails = new string[3] {"DeviceKey", "read-write", "2100"};

protocol.NotifyDataMinerQueued(62/*NT_EDIT_PROPERTY*/ , propertyLocation, propertyDetails);
```

### Details

To make this call DELT compatible, the DMA ID needs to be provided as argument.  
See Example code.  
More information about the syntax can be found in the DataMiner Development Library.
