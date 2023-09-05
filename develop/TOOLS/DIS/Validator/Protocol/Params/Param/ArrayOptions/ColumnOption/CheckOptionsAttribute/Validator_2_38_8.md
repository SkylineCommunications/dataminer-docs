---  
uid: Validator_2_38_8  
---

# CheckOptionsAttribute

## ForeignKeyColumnInvalidMeasurementType

### Description

Invalid value '{columnMeasurementType}' in tag 'Measurement\/Type' for foreign key column. Possible values 'string, number'. FK column PID '{fkColumnPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.38.8      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

A column used as foreign key to a table should be of Measurement\/Type 'string' or 'number'.
