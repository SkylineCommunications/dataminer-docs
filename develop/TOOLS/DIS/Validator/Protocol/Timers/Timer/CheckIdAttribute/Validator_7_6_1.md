---  
uid: Validator_7_6_1  
---

# CheckIdAttribute

## MissingAttribute

### Description

Missing attribute 'Timer@id'.

### Properties

| Name         | Value     |
| ------------ | --------- |
| Category     | Timer     |
| Full Id      | 7.6.1     |
| Severity     | Critical  |
| Certainty    | Certain   |
| Source       | Validator |
| Fix Impact   | Breaking  |
| Has Code Fix | False     |

### Details

The id attribute is used internally as the identifier for each timer.  
It is therefore mandatory and needs to follow a number of rules:  
\- Each timer should have a unique id.  
\- Should be an unsigned integer.  
\- Only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
