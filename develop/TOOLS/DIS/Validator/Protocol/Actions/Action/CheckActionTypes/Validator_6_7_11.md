---  
uid: Validator_6_7_11  
---

# CheckActionTypes

## UnsupportedGroupContentDueTo

### Description

Attribute 'On@id' in action of type '{actionType}' on '{actionOn}' references Group '{groupId}' which is missing 'Content\/Param' tag(s). Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.7.11      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Action\/On@id' attribute should refer to the ID of an existing Group in following cases:  
\- On group:  
    \- 'set' \/ 'set with wait' : allowing to set multiple SNMP parameters in one go. The group content should refer to SNMP parameters of type 'write'.
