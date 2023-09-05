---  
uid: Validator_2_37_1  
---

# CheckTypeTag

## TogglebuttonRecommended

### Description

Measurement\/Type 'togglebutton' is recommended for Param with ID '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.37.1      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### How to fix

Change measurement type to 'togglebutton'.

### Details

When we have only two possible discreet values and it is obvious from reading one what the other one is, we should use a togglebutton.
