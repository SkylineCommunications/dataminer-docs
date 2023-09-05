---  
uid: Validator_18_7_4  
---

# CheckDiscreetColumnIdAttribute

## InvalidValue

### Description

Invalid value '{attributeValue}' in attribute 'LinkedDetails@discreetColumnId'. TreeControl ID '{treeControlPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.7.4      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

LinkedDetails@discreetColumnId attribute should contain a column PID. The value contained in that column will then be compared to the value specified in LinkedDetails@value attribute.  
Such column should have its RTDisplay tag set to true.
