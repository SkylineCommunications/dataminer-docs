---  
uid: Validator_10_5_1  
---

# CheckIdAttribute

## MissingAttribute

### Description

Missing attribute 'Command@id'.

### Properties

| Name         | Value     |
| ------------ | --------- |
| Category     | Command   |
| Full Id      | 10.5.1    |
| Severity     | Critical  |
| Certainty    | Certain   |
| Source       | Validator |
| Fix Impact   | Breaking  |
| Has Code Fix | False     |

### Details

The id attribute is used internally as the identifier for each command.  
It is therefore mandatory and needs to follow a number of rules:  
\- Each command should have a unique id.  
\- Should be an unsigned integer.  
\- Only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
