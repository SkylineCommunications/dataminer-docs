---  
uid: Validator_2_39_7  
---

# CheckDisplayKey

## DisplayKeyColumnInvalidMeasurementType

### Description

Invalid value '{columnMeasurementType}' in tag 'Measurement\/Type' for display key column. Possible values 'string, number'. DK column PID '{dkColumnPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.39.7      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

A column used as table display key should be of Measurement\/Type 'string' or 'number'.
