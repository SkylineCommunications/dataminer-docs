---  
uid: Validator_5_8_2  
---

# CheckIdAttribute

## EmptyAttribute

### Description

Empty attribute 'Trigger@id'.

### Properties

| Name         | Value     |
| ------------ | --------- |
| Category     | Trigger   |
| Full Id      | 5.8.2     |
| Severity     | Critical  |
| Certainty    | Certain   |
| Source       | Validator |
| Fix Impact   | Breaking  |
| Has Code Fix | False     |

### Details

The id attribute is used internally as the identifier for each trigger.  
It is therefore mandatory and needs to follow a number of rules:  
\- Each trigger should have a unique id.  
\- Should be an unsigned integer.  
\- Only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
