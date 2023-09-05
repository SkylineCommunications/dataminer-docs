---  
uid: Validator_7_6_3  
---

# CheckIdAttribute

## UntrimmedAttribute

### Description

Untrimmed attribute 'Timer@id'. Current value '{attributeValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Timer       |
| Full Id      | 7.6.3       |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

The id attribute is used internally as the identifier for each timer.  
It is therefore mandatory and needs to follow a number of rules:  
\- Each timer should have a unique id.  
\- Should be an unsigned integer.  
\- Only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
