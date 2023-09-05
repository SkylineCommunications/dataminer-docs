---  
uid: Validator_16_7_5  
---

# CheckIdAttribute

## OutOfRangeId

### Description

Out of range ParameterGroup ID '{id}'.

### Properties

| Name         | Value          |
| ------------ | -------------- |
| Category     | ParameterGroup |
| Full Id      | 16.7.5         |
| Severity     | Critical       |
| Certainty    | Variable       |
| Source       | Validator      |
| Fix Impact   | NonBreaking    |
| Has Code Fix | False          |

### Details

A ParameterGroup should have a unique id \> 0 and \<\= 10000.  
Note that from DM 9.0.4 onward, id \> 0 and \<\=100.000 can be used.
