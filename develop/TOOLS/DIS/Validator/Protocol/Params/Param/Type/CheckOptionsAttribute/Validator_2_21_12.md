---  
uid: Validator_2_21_12  
---

# CheckOptionsAttribute

## MissingAttributeForMatrix

### Description

Missing attribute 'Param\/Type@options' in Matrix '{matrixPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.21.12     |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

Following options in Param\/Type@options attribute are required for matrixes.  
 \- dimensions\=rowCount,columnCount  
 \- columnTypes\=pid:minDiscreetValue\-maxDiscreetValue
