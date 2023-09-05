---  
uid: Validator_2_69_1  
---

# CheckIdAttribute

## MissingAttribute

### Description

Missing attribute 'Interprete\/LengthType@id' due to 'LengthType' 'other param'. Param ID '{paramId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.69.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

When Interprete\/LengthType tag is set to 'other param', the id attribute should be added to it and should refer to the id of an existing parameter of Interprete\/Type double.
