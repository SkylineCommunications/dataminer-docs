---  
uid: Validator_2_37_7  
---

# CheckTypeTag

## MatrixSetterOnWrite

### Description

Unsupported attribute 'setter' in Matrix '{matrixPid}'. Current value 'true'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.37.7      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### How to fix

Remove the setter attribute.

### Details

Matrix write parameters should never have a setter \= true.
