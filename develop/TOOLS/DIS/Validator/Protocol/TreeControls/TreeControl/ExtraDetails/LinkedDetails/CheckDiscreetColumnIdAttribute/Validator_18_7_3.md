---  
uid: Validator_18_7_3  
---

# CheckDiscreetColumnIdAttribute

## UntrimmedAttribute

### Description

Untrimmed attribute 'LinkedDetails@discreetColumnId' in TreeControl '{treeControlPid}'. Current value '{untrimmedValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.7.3      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

LinkedDetails@discreetColumnId attribute should contain a column PID. The value contained in that column will then be compared to the value specified in LinkedDetails@value attribute.  
Such column should have its RTDisplay tag set to true.
