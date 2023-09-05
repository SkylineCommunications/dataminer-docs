---  
uid: Validator_2_37_9  
---

# CheckTypeTag

## InvalidParamType

### Description

Invalid value '{paramType}' in 'Param\/Type' for '{measurementType}'. Param ID '{paramId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.37.9      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Following kind of parameters require the Param\/Type tag to be set to 'write' or 'writebit':  
\- button  
\- togglebutton  
\- pagebutton
