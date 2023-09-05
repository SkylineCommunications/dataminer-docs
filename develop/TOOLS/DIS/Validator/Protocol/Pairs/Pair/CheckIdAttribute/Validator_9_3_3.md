---  
uid: Validator_9_3_3  
---

# CheckIdAttribute

## UntrimmedAttribute

### Description

Untrimmed attribute 'Pair@id'. Current value '{attributeValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Pair        |
| Full Id      | 9.3.3       |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

The id attribute is used internally as the identifier for each pair.  
It is therefore mandatory and needs to follow a number of rules:  
\- Each pair should have a unique id.  
\- Should be an unsigned integer.  
\- Only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
