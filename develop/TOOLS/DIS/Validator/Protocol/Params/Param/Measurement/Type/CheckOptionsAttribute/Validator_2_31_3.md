---  
uid: Validator_2_31_3  
---

# CheckOptionsAttribute

## InvalidConnectedMatrixPoints

### Description

'{badValue}': Invalid '{minOrMax}' number of connections for one {inputOrOutput} for matrix '{matrixPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.31.3      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Make sure the total number of possible connections for a single input or output is not negative nor exceeds the total dimensions of the matrix.
