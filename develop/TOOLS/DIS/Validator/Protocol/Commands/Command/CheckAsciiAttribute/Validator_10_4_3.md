---  
uid: Validator_10_4_3  
---

# CheckAsciiAttribute

## NonExistingId

### Description

Attribute 'ascii' references a non\-existing 'Param' with ID '{pid}'. Command ID '{commandId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Command     |
| Full Id      | 10.4.3      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

This attribute allows you to specify which parameters should be sent as ASCII. Possible values:  
 \- True: all params as ascii  
 \- False: no param as ascii  
 \- Semicolon separated list of Param IDs  
Note that this option only makes sense when using unicode feature.
