---  
uid: Validator_2_38_9  
---

# CheckOptionsAttribute

## ForeignKeyColumnInvalidType

### Description

Invalid value '{columnType}' in tag 'Param\/Type' for foreign key column. Possible values 'read'. FK column PID '{fkColumnPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.38.9      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

A column used as foreign key to a table should be of Param\/Type 'read'.
