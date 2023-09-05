---  
uid: Validator_3_31_4  
---

# CheckIdAttribute

## InvalidValue

### Description

Invalid value '{qactionId}' in attribute 'QAction@id'. QAction name '{qactionName}'.

### Properties

| Name         | Value     |
| ------------ | --------- |
| Category     | QAction   |
| Full Id      | 3.31.4    |
| Severity     | Critical  |
| Certainty    | Certain   |
| Source       | Validator |
| Fix Impact   | Breaking  |
| Has Code Fix | False     |

### Details

The id attribute is used internally as the identifier for each qaction.  
It is therefore mandatory and needs to follow a number of rules:  
\- Each qaction should have a unique id.  
\- Should be an unsigned integer.  
\- Only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
