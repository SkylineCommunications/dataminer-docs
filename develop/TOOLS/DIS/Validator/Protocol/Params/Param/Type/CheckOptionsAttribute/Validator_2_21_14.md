---  
uid: Validator_2_21_14  
---

# CheckOptionsAttribute

## InvalidMatrixOption

### Description

Invalid syntax for the '{optionName}' option. Matrix PID '{matrixPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.21.14     |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Make sure both dimensions and columntypes options are correctly defined.

### Details

Following options in Param\/Type@options attribute are required for matrixes.  
 \- dimensions\=rowCount,columnCount  
 \- columnTypes\=pid:minDiscreetValue\-maxDiscreetValue
