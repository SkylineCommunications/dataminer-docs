---  
uid: Validator_2_70_1  
---

# CheckValueAttribute

## MissingAttribute

### Description

Missing attribute 'Exception@value' in Param '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.70.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

For each exception, the Exception@value attribute is required in order to define the incoming value that should be interpreted as exceptional.  
The value should be compliant with the defined Param\/Interprete\/Type.
