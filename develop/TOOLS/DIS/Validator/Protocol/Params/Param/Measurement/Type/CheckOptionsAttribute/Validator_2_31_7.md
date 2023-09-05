---  
uid: Validator_2_31_7  
---

# CheckOptionsAttribute

## MissingMatrixOption

### Description

Missing '{optionName}' option for matrix Param. Matrix PID '{matrixPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.31.7      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Following options in Measurement\/Type@options attribute are required for matrixes:  
 \- matrix\=InputCount, OutputCount, MinConnectedInputs, MaxConnectedInputs, MinConnectedOutputs, MaxConnectedOutputs
