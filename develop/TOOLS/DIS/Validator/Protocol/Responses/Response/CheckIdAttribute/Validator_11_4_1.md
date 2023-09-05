---  
uid: Validator_11_4_1  
---

# CheckIdAttribute

## MissingAttribute

### Description

Missing attribute 'Response@id'.

### Properties

| Name         | Value     |
| ------------ | --------- |
| Category     | Response  |
| Full Id      | 11.4.1    |
| Severity     | Critical  |
| Certainty    | Certain   |
| Source       | Validator |
| Fix Impact   | Breaking  |
| Has Code Fix | False     |

### Details

The id attribute is used internally as the identifier for each response.  
It is therefore mandatory and needs to follow a number of rules:  
\- Each response should have a unique id.  
\- Should be an unsigned integer.  
\- Only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
