---  
uid: Validator_2_68_1  
---

# CheckDefaultValueTag

## UnsupportedTag

### Description

Unsupported tag 'DefaultValue' in Param '{paramId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.68.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Interprete\/DefaultValue tag allows to give a default value to a parameter.  
This is currently only supported on standalone read parameters and the given value should be compatible with the Inteprete\/Type.
