---  
uid: Validator_2_64_1  
---

# CheckColumns

## ColumnInvalidType

### Description

Invalid value '{columnType}' in tag 'Param\/Type' for column. Possible values 'read, write, group, read bit, write bit'. Column PID '{columnPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.64.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

A column should be of Param\/Type 'read', 'write', 'group', 'read bit' or 'write bit'.
