---  
uid: Validator_2_32_4  
---

# CheckLowTag

## InvalidValue

### Description

Invalid value '{tagValue}' in tag 'Range\/Low'. Param ID '{paramId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.32.4      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

If present, the 'Range\/Low' tag should be filled in with a numerical value.  
Its value should be smaller than the one in the 'Range\/High' tag.
