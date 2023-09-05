---  
uid: Validator_4_8_1  
---

# CheckIdAttribute

## MissingAttribute

### Description

Missing attribute 'Group@id'.

### Properties

| Name         | Value     |
| ------------ | --------- |
| Category     | Group     |
| Full Id      | 4.8.1     |
| Severity     | Critical  |
| Certainty    | Certain   |
| Source       | Validator |
| Fix Impact   | Breaking  |
| Has Code Fix | False     |

### Details

The id attribute is used internally as the identifier for each group.  
It is therefore mandatory and needs to follow a number of rules:  
\- Each group should have a unique id.  
\- Should be an unsigned integer.  
\- Only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
