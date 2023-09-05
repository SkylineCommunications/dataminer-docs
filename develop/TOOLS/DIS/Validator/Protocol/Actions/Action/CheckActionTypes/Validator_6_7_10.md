---  
uid: Validator_6_7_10  
---

# CheckActionTypes

## UnsupportedConnectionTypeDueTo

### Description

{optionalPrefix}'Type@nr' attribute in action of type '{actionType}' on '{actionOn}' references Connection '{connectionId}' with wrong type '{connectionType}'. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.7.10      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Action\/Type@nr' attribute should refer to the ID (0\-based) of an existing connection in following cases:  
\- On group:  
    \- 'set' \/ 'set with wait' : allowing to set multiple SNMP parameters in one go. The refered connection should be of type SNMP (snmp, snmpV2 or snmpV3).
