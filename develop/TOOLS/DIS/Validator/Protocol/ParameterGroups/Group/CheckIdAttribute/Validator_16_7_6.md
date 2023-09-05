---  
uid: Validator_16_7_6  
---

# CheckIdAttribute

## DuplicatedId

### Description

More than one ParameterGroup with same ID '{parameterGroupId}'. ParameterGroup Names '{parameterGroupNames}'.

### Properties

| Name         | Value          |
| ------------ | -------------- |
| Category     | ParameterGroup |
| Full Id      | 16.7.6         |
| Severity     | Critical       |
| Certainty    | Certain        |
| Source       | Validator      |
| Fix Impact   | Breaking       |
| Has Code Fix | False          |

### Details

The id attribute is used internally as the identifier for each parameterGroup.  
It is therefore mandatory and needs to follow a number of rules:  
\- Each parameterGroup should have a unique id.  
\- Should be an unsigned integer.  
\- Only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
