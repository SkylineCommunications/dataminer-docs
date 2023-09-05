---  
uid: Validator_3_26_1  
---

# CSharpNotifyDataMinerNTGetAlarmInfo

## DeltIncompatible

### Description

Invocation of method 'SLProtocol.NotifyDataMiner(48\/\*NT\_GET\_ALARM\_INFO\*\/, ...)' is not compatible with 'DELT'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.26.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Example code

```xml
uint[] elementInfo = new uint[] { dmaId, elementId };
uint[] parameterIds = new uint[] { 100, 300 };

object[] result = (object[]) protocol.NotifyDataMiner(48 /* NT_GET_ALARM_INFO */, elementInfo, parameterIds);
```

### Details

To make this call DELT compatible, the DMA ID needs to be provided as argument.  
See Example code.  
More information about the syntax can be found in the DataMiner Development Library.
