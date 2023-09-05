---  
uid: Validator_3_18_1  
---

# CSharpNotifyDataMinerNTGetParameter

## DeltIncompatible

### Description

Invocation of method 'SLProtocol.NotifyDataMiner(73\/\*NT\_GET\_PARAMETER\*\/, ...)' is not compatible with 'DELT'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.18.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Example code

```xml
uint[] ids = new uint[] { dmaID, elementID, parameterID };
object[] result = (object[])protocol.NotifyDataMiner(73/*NT_GET_PARAMETER*/, ids, null);
```

### Details

To make this call DELT compatible, the DMA ID needs to be provided as argument.  
See Example code.  
More information about the syntax can be found in the DataMiner Development Library.
