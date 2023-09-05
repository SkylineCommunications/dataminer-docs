---  
uid: Validator_11_4_3  
---

# CheckIdAttribute

## UntrimmedAttribute

### Description

Untrimmed attribute 'Response@id'. Current value '{attributeValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Response    |
| Full Id      | 11.4.3      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

The id attribute is used internally as the identifier for each response.  
It is therefore mandatory and needs to follow a number of rules:  
\- Each response should have a unique id.  
\- Should be an unsigned integer.  
\- Only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
