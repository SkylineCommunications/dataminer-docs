---  
uid: Validator_3_31_3  
---

# CheckIdAttribute

## UntrimmedAttribute

### Description

Untrimmed attribute 'QAction@id'. Current value '{attributeValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.31.3      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

The id attribute is used internally as the identifier for each qaction.  
It is therefore mandatory and needs to follow a number of rules:  
\- Each qaction should have a unique id.  
\- Should be an unsigned integer.  
\- Only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
