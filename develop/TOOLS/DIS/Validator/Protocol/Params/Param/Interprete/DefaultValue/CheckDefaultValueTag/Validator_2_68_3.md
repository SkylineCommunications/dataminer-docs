---  
uid: Validator_2_68_3  
---

# CheckDefaultValueTag

## ValueIncompatibleWithInterpreteType

### Description

Interprete\/DefaultValue '{defaultValue}' is incompatible with Interprete\/Type '{interpreteType}'. Param ID '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.68.3      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Interprete\/DefaultValue tag allows to give a default value to a parameter.  
This is currently only supported on standalone read parameters and the given value should be compatible with the Inteprete\/Type.
