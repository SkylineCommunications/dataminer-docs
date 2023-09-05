---  
uid: Validator_3_23_1  
---

# CSharpNotifyDataMinerNTUpdateDescriptionXml

## DeltIncompatible

### Description

Invocation of method 'SLProtocol.NotifyDataMiner(Queued)(127\/\*NT\_UPDATE\_DESCRIPTION\_XML\*\/, ...)' is not compatible with 'DELT'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.23.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Example code

```xml
uint[] elementDetails = new uint[] { agentId, elementId };
object[] updates = new object[] { update1, update2 };

int result = (int) protocol.NotifyDataMinerQueued(127/*NT_UPDATE_DESCRIPTION_XML */ , elementDetails, updates);
```

### Details

To make this call DELT compatible, the DMA ID needs to be provided as argument.  
See Example code.  
More information about the syntax can be found in the DataMiner Development Library.
