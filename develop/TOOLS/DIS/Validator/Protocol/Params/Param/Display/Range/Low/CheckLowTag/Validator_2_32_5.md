---  
uid: Validator_2_32_5  
---

# CheckLowTag

## UntrimmedValue

### Description

Untrimmed tag 'Range\/Low' in Param '{paramId}'. Current value '{untrimmedValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.32.5      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

If present, the 'Range\/Low' tag should be filled in with a numerical value.  
Its value should be smaller than the one in the 'Range\/High' tag.
