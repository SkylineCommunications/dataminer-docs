---  
uid: Validator_6_7_13  
---

# CheckActionTypes

## UnsupportedGroupParamWithoutSnmp

### Description

Attribute 'On@id' in action of type '{actionType}' on '{actionOn}' references Group '{groupId}' which references Param '{paramId}' with unsupported 'SNMP\/Enabled' '{snmpEnabledValue}'. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.7.13      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Action\/On@id' attribute should refer to the ID of an existing Group in following cases:  
\- On group:  
    \- 'set' \/ 'set with wait' : allowing to set multiple SNMP parameters in one go. The group content should refer to SNMP parameters Param\/Type 'write' and SNMP\/Enabled 'true'.
