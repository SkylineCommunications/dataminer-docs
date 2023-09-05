---  
uid: Validator_2_33_4  
---

# CheckHighTag

## InvalidValue

### Description

Invalid value '{tagValue}' in tag 'Range\/High'. Param ID '{paramId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.33.4      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

If present, the 'Range\/High' tag should be filled in with a numerical value.  
Its value should be bigger than the one in the 'Range\/Low' tag.
