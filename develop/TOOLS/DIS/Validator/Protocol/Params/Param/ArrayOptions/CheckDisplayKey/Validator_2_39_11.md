---  
uid: Validator_2_39_11  
---

# CheckDisplayKey

## DuplicateDisplayKeyColumn

### Description

Table has multiple ColumnOption tags with value 'displaykey' in type attribute. Table Pid {tablePid}.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.39.11     |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

A table should have, at most, 1 ColumnOption tag with its type attribute set to 'displaykey'.
