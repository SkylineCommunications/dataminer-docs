---  
uid: Validator_8_16_3  
---

# CheckIdAttribute

## UntrimmedAttribute

### Description

Untrimmed attribute 'HTTP\/Session@id'. Current value '{attributeValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | HTTP        |
| Full Id      | 8.16.3      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

The id attribute is used internally as the identifier for each session.  
It is therefore mandatory and needs to follow a number of rules:  
\- Each session should have a unique id.  
\- Should be an unsigned integer.  
\- Only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
