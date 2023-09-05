---  
uid: Validator_2_1_13  
---

# CheckIdAttribute

## UntrimmedAttribute

### Description

Untrimmed attribute 'Param@id'. Current value '{attributeValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.1.13      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

The id attribute is used internally as the identifier for each param.  
It is therefore mandatory and needs to follow a number of rules:  
\- Each param should have a unique id.  
\- Should be an unsigned integer.  
\- Only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
