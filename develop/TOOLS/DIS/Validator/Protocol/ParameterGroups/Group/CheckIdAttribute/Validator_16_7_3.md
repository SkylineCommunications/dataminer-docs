---  
uid: Validator_16_7_3  
---

# CheckIdAttribute

## UntrimmedAttribute

### Description

Untrimmed attribute 'ParameterGroups\/Group@id'. Current value '{attributeValue}'.

### Properties

| Name         | Value          |
| ------------ | -------------- |
| Category     | ParameterGroup |
| Full Id      | 16.7.3         |
| Severity     | Warning        |
| Certainty    | Certain        |
| Source       | Validator      |
| Fix Impact   | NonBreaking    |
| Has Code Fix | True           |

### Details

The id attribute is used internally as the identifier for each parameterGroup.  
It is therefore mandatory and needs to follow a number of rules:  
\- Each parameterGroup should have a unique id.  
\- Should be an unsigned integer.  
\- Only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
