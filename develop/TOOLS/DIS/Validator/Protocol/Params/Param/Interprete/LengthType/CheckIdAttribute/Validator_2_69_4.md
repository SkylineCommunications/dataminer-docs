---  
uid: Validator_2_69_4  
---

# CheckIdAttribute

## NonExistingId

### Description

Attribute 'Interprete\/LengthType@id' references a non\-existing 'Param' with ID '{nonExistingParamId}'. Param ID '{paramId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.69.4      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

When Interprete\/LengthType tag is set to 'other param', the id attribute should be added to it and should refer to the id of an existing parameter of Interprete\/Type double.
