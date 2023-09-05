---  
uid: Validator_2_21_9  
---

# CheckOptionsAttribute

## InvalidColumnTypeParamRawType

### Description

Invalid Interprete\/RawType '{rawType}' for 'Matrix ColumnType Param'. ColumnType PID '{columnTypePid}'. Matrix PID '{matrixPid}'. Possible values 'numeric text, unsigned number'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.21.9      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Either by changing the reference to the columntype parameter withing the matrix parameter.  
Either by changing the RawType of the parameter currently referenced as bying the columntype parameter.
