---  
uid: Validator_2_69_5  
---

# CheckIdAttribute

## ReferencedParamWrongInterpreteType

### Description

Invalid Interprete\/Type '{interpreteType}' on Param referenced by Interprete\/LengthType@id. Expected value 'double'. Param ID '{paramId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.69.5      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

When Interprete\/LengthType tag is set to 'other param', the id attribute should be added to it and should refer to the id of an existing parameter of Interprete\/Type double.
