---  
uid: Validator_2_46_8  
---

# CheckIndexAttribute

## InvalidColumnMeasurementType

### Description

Invalid value '{columnMeasurementType}' in tag 'Measurement\/Type' for primary key column. Possible values 'string, number'. PK column PID '{pkColumnPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.46.8      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The column used as primary key of a table should be of Mesurement\/Type 'string' or 'number'.
