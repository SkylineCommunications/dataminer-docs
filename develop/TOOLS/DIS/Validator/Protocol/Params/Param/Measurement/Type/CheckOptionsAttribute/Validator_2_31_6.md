---  
uid: Validator_2_31_6  
---

# CheckOptionsAttribute

## InvalidMatrixOption

### Description

Invalid syntax for the '{optionName}' option. Matrix PID '{matrixPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.31.6      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Following options in Measurement\/Type@options attribute are required for matrixes:  
 \- matrix\=InputCount, OutputCount, MinConnectedInputs, MaxConnectedInputs, MinConnectedOutputs, MaxConnectedOutputs
