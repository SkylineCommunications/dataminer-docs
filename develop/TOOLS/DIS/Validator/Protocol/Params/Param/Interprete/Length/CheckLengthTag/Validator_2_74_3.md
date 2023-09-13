---  
uid: Validator_2_74_3  
---

# CheckLengthTag

## InvalidValue

### Description

Invalid value '{tagValue}' in tag 'Length'. Param ID '{paramId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.74.3      |
| Severity     | Variable    |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Length' tag needs to be an unsigned integer.  
When the parameter is of type 'length', the 'Length' tag can not be larger than 4.
