---  
uid: Validator_3_27_1  
---

# CSharpNotifyDataMinerNTGetElementName

## DeltIncompatible

### Description

Invocation of method 'SLProtocol.NotifyDataMiner(144\/\*NT\_GET\_ELEMENT\_NAME\*\/, ...)' is not compatible with 'DELT'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.27.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Example code

```xml
uint[] elementDetails = new uint[] { agentId, elementId };
string elementName = (string) protocol.NotifyDataMiner(144/*NT_GET_ELEMENT_NAME */, elementDetails, null);
```

### Details

To make this call DELT compatible, the DMA ID needs to be provided as argument.  
See Example code.  
More information about the syntax can be found in the DataMiner Development Library.
