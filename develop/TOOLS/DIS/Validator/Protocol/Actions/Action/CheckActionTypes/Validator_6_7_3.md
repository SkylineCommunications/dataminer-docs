---  
uid: Validator_6_7_3  
---

# CheckActionTypes

## MissingTypeIdAttribute

### Description

Missing attribute 'Type@id' due to 'Action\/Type' '{actionType}' and 'Action\/On' '{actionOn}'. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.7.3       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Action\/Type@id' attribute is mandatory in following cases:  
\- On pair:  
    \- timeout: PID of the parameter that holds the timeout value (in ms).
