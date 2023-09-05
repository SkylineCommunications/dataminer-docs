---  
uid: Validator_6_2_1  
---

# CheckIdAttribute

## MissingAttribute

### Description

Missing attribute 'Action@id'.

### Properties

| Name         | Value     |
| ------------ | --------- |
| Category     | Action    |
| Full Id      | 6.2.1     |
| Severity     | Critical  |
| Certainty    | Certain   |
| Source       | Validator |
| Fix Impact   | Breaking  |
| Has Code Fix | False     |

### Details

The Action@id attribute is used internally as the identifier for each action.  
It is therefore mandatory and needs to follow a number of rules:  
\- Each action should have a unique id.  
\- Should be an unsigned integer.  
\- Only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
