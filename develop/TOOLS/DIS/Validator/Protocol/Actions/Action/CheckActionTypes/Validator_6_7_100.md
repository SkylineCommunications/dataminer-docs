---  
uid: Validator_6_7_100  
---

# CheckActionTypes

## UnsupportedAttributeOnNr

### Description

Unsupported attribute 'Action\/On@nr' in combination with 'Action\/Type' '{actionType}' and  'Action\/On' '{actionOn}'. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.7.100     |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Action\/On@nr' attribute only makes sense in following 'Action\/On' and 'Action\/Type' scenarios:  
\- On param:  
    \- reverse :  Semicolon (;) separated list of 0\-based position(s) of the parameter in the command\/response.  
\- On pair:  
    \- set next :  Semicolon (;) separated list of 1\-based position(s) of the pair(s) in the group.
