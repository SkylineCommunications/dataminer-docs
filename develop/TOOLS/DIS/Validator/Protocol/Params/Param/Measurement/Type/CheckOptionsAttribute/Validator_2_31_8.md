---  
uid: Validator_2_31_8  
---

# CheckOptionsAttribute

## MissingAttribute

### Description

Missing attribute 'Measurement\/Type@Options' in Matrix '{matrixPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.31.8      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

Following options in Measurement\/Type@options attribute are required for matrixes:  
 \- matrix\=InputCount, OutputCount, MinConnectedInputs, MaxConnectedInputs, MinConnectedOutputs, MaxConnectedOutputs
