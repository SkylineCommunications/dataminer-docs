---  
uid: Validator_6_7_4  
---

# CheckActionTypes

## MissingOnNrAttribute

### Description

Missing attribute 'On@nr' due to 'Action\/Type' '{actionType}' and 'Action\/On' '{actionOn}'. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.7.4       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Action\/On@nr' attribute is mandatory in following cases:  
\- On pair:  
    \- set next: the 1\-based position(s) of the pair(s) in the group on which the next value needs to be set.
