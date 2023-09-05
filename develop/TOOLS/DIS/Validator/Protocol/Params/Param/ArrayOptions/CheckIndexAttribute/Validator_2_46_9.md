---  
uid: Validator_2_46_9  
---

# CheckIndexAttribute

## InvalidColumnType

### Description

Invalid value '{columnType}' in tag 'Param\/Type' for primary key column. Possible values 'read'. PK column PID '{pkColumnPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.46.9      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The column used as primary key of a table should be of Param\/Type 'read'.
