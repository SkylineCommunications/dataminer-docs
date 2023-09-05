---  
uid: Validator_3_22_1  
---

# CSharpNotifyDataMinerNTTrendingAssignTemplate

## DeltIncompatible

### Description

Invocation of method 'SLProtocol.NotifyDataMiner(Queued)(14\/\*NT\_TRENDING\_ASSIGN\_TEMPLATE\*\/, ...)' is not compatible with 'DELT'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.22.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Example code

```xml
uint[] elementDetails = { agentId, elementId };
string[] trendTemplate = new string[] { "Template 1" };

protocol.NotifyDataMiner(14 /*NT_TRENDING_ASSIGN_TEMPLATE*/, elementDetails, trendTemplate);
```

### Details

To make this call DELT compatible, the DMA ID needs to be provided as argument.  
See Example code.  
More information about the syntax can be found in the DataMiner Development Library.
