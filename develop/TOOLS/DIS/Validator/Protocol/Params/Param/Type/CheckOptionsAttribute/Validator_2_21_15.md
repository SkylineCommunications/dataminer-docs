---  
uid: Validator_2_21_15  
---

# CheckOptionsAttribute

## InvalidColumnTypeParamLengthType

### Description

Invalid Interprete\/LengthType '{lengthType}' for 'Matrix ColumnType Param'. ColumnType PID '{columnTypePid}'. Matrix PID '{matrixPid}'. Possible values 'next param, fixed'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.21.15     |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Either by changing the reference to the columntype parameter withing the matrix parameter.  
Either by changing the LengthType of the parameter currently referenced as bying the columntype parameter.
