---  
uid: Validator_2_1_11  
---

# CheckIdAttribute

## DuplicatedId

### Description

More than one Param with same ID '{pid}'. Param Names '{paramNames}'.

### Properties

| Name         | Value     |
| ------------ | --------- |
| Category     | Param     |
| Full Id      | 2.1.11    |
| Severity     | Critical  |
| Certainty    | Certain   |
| Source       | Validator |
| Fix Impact   | Breaking  |
| Has Code Fix | False     |

### Details

The id attribute is used internally as the identifier for each param.  
It is therefore mandatory and needs to follow a number of rules:  
\- Each param should have a unique id.  
\- Should be an unsigned integer.  
\- Only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
