---  
uid: Validator_3_20_1  
---

# CSharpNotifyDataMinerNTUpdatePortsXml

## DeltIncompatible

### Description

Invocation of method 'SLProtocol.NotifyDataMiner(Queued)(128\/\*NT\_UPDATE\_PORTS\_XML\*\/, ...)' is not compatible with 'DELT'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.20.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Example code

```xml
string updateConfig = changeType + ";" + elementId + ";" + parameterId + ";" + agentId;
string updateValue = inputs + ";" + outputs;

int result = (int) protocol.NotifyDataMinerQueued(128/*NT_UPDATE_PORTS_XML*/, updateConfig, updateValue);
```

### Details

To make this call DELT compatible, the DMA ID needs to be provided as argument.  
See Example code.  
More information about the syntax can be found in the DataMiner Development Library.
