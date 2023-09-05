---  
uid: Validator_9_3_2  
---

# CheckIdAttribute

## EmptyAttribute

### Description

Empty attribute 'Pair@id'.

### Properties

| Name         | Value     |
| ------------ | --------- |
| Category     | Pair      |
| Full Id      | 9.3.2     |
| Severity     | Critical  |
| Certainty    | Certain   |
| Source       | Validator |
| Fix Impact   | Breaking  |
| Has Code Fix | False     |

### Details

The id attribute is used internally as the identifier for each pair.  
It is therefore mandatory and needs to follow a number of rules:  
\- Each pair should have a unique id.  
\- Should be an unsigned integer.  
\- Only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
