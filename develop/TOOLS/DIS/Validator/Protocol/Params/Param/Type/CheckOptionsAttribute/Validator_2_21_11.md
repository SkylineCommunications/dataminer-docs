---  
uid: Validator_2_21_11  
---

# CheckOptionsAttribute

## MissingMatrixOptions

### Description

Missing '{optionName}' option for matrix. Param ID '{matrixPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.21.11     |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Make sure both dimensions and columntypes options are correctly defined via the Param\/Type@options attribute.

### Details

Following options in Param\/Type@options attribute are required for matrixes.  
 \- dimensions\=rowCount,columnCount  
 \- columnTypes\=pid:minDiscreetValue\-maxDiscreetValue
