---  
uid: Validator_2_63_4  
---

# CheckPidAttribute

## NonExistingParam

### Description

Attribute 'ColumnOption@pid' references a non\-existing 'column' with PID '{columnPid}'. Table PID '{tablePid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.63.4      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The ColumnOption@pid attribute is mandatory and should be filled in with the ID of an existing column Param.
