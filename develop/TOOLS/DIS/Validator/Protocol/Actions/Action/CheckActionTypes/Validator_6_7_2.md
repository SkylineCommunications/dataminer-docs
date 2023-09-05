---  
uid: Validator_6_7_2  
---

# CheckActionTypes

## MissingOnIdAttribute

### Description

Missing attribute 'On@id' due to 'Action\/Type' '{actionType}' and 'Action\/On' '{actionOn}'. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.7.2       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Action\/On@id' attribute is mandatory in following cases:  
\- On timer: always.  
\- On pair:  
    \- timeout.  
\- On group:  
    \- All execute flavors: 'add to execute'\/'execute'\/'execute next'\/'execute one'\/'execute one top'\/'execute one now'\/'force execute'.
