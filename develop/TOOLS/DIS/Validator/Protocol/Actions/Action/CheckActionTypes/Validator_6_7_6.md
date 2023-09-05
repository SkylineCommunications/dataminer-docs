---  
uid: Validator_6_7_6  
---

# CheckActionTypes

## MissingTypeIdOrTypeValueAttribute

### Description

Missing attribute 'Type@id or Type@value' due to 'Action\/Type' '{actionType}' and 'Action\/On' '{actionOn}'. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.7.6       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Following cases require either a 'Action\/Type@id' or a 'Action\/Type@value' attribute:  
\- On pair:  
    \- set next: define the 'time to wait after pair' value (in ms) either by referencing the ID of a parameter containing the (dynamic) value via 'Type@id' or by hard coding the value via the 'Type@value' attribute.
