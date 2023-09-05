---  
uid: Validator_6_7_9  
---

# CheckActionTypes

## NonExistingConnectionRefInTypeNrAttribute

### Description

Attribute 'Type@nr' references a non\-existing 'Connection' with ID '{connectionId}'. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.7.9       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Action\/Type@nr' attribute should refer to an existing connection ID (0\-based) in following cases:  
\- On group:  
    \- 'set' \/ 'set with wait' : allowing to set multiple SNMP parameters in one go. The refered connection should be of type SNMP (snmp, snmpV2 or snmpV3).
