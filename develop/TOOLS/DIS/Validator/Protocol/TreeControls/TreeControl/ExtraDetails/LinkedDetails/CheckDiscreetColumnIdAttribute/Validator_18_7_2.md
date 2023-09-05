---  
uid: Validator_18_7_2  
---

# CheckDiscreetColumnIdAttribute

## EmptyAttribute

### Description

Empty attribute 'LinkedDetails@discreetColumnId' in TreeControl '{treeControlPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.7.2      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

LinkedDetails@discreetColumnId attribute should contain a column PID. The value contained in that column will then be compared to the value specified in LinkedDetails@value attribute.  
Such column should have its RTDisplay tag set to true.
