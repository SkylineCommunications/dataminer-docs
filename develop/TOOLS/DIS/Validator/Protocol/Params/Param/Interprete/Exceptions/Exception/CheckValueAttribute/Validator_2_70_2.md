---  
uid: Validator_2_70_2  
---

# CheckValueAttribute

## ValueIncompatibleWithInterpreteType

### Description

Incompatible 'Exception@value' value '{exceptionValue}' with 'Interprete\/Type' value '{interpreteType}'. Param ID '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.70.2      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

For each exception, the Exception@value attribute is required in order to define the incoming value that should be interpreted as exceptional.  
The value should be compliant with the defined Param\/Interprete\/Type.
