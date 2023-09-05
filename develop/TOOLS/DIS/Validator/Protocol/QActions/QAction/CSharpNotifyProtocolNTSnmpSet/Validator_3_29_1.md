---  
uid: Validator_3_29_1  
---

# CSharpNotifyProtocolNTSnmpSet

## DeltIncompatible

### Description

Invocation of method 'SLProtocol.NotifyProtocol(292\/\*NT\_SNMP\_SET\*\/, ...)' is not compatible with 'DELT'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.29.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Example code

```xml
object[] elementInfo = new object[] { elementId, ipPort, multipleSet, instance, connectionId, setCommunityString, enableRetries, agentId };
object[] oidInfo = new object[] { new object[] { oid, newValue, snmpType } };

object[] result = (object[])protocol.NotifyProtocol(292/*NT_SNMP_SET*/, elementInfo, oidInfo);
```

### Details

To make this call DELT compatible, the DMA ID needs to be provided as argument.  
See Example code.  
More information about the syntax can be found in the DataMiner Development Library.
