---  
uid: Validator_18_7_5  
---

# CheckDiscreetColumnIdAttribute

## NonExistingId

### Description

Attribute 'ExtraDetails\/LinkedDetails@discreetColumnId' references a non\-existing 'Column' with PID '{columnPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.7.5      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

LinkedDetails@discreetColumnId attribute should contain a column PID. The value contained in that column will then be compared to the value specified in LinkedDetails@value attribute.  
Such column should have its RTDisplay tag set to true.
