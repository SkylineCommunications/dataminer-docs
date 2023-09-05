---  
uid: Validator_6_7_5  
---

# CheckActionTypes

## NonExistingParamRefInTypeIdAttribute

### Description

Attribute 'Type@id' references a non\-existing 'Param' with ID '{pid}'. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.7.5       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Action\/Type@id' attribute should refer to existing parameter ID in following cases:  
\- On pair:  
    \- timeout: ID of the parameter that holds the timeout value (in ms).  
    \- set next: (optional) ID of the parameter containing the 'time to wait after pair' value (in ms).
