---  
uid: Validator_3_19_1  
---

# CSharpNotifyDataMinerNTAssignAlarmTemplate

## DeltIncompatible

### Description

Invocation of method 'SLProtocol.NotifyDataMiner(Queued)(117\/\*NT\_ASSIGN\_ALARM\_TEMPLATE\*\/, ...)' is not compatible with 'DELT'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.19.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Example code

```xml
uint[] elementDetails = { agentId, elementId };
string[] alarmTemplate = new string[] { "Alarm Template 1" };

protocol.NotifyDataMiner(117/*NT_ASSIGN_ALARM_TEMPLATE*/, elementDetails, alarmTemplate);
```

### Details

To make this call DELT compatible, the DMA ID needs to be provided as argument.  
See Example code.  
More information about the syntax can be found in the DataMiner Development Library.
