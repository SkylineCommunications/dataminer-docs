---  
uid: Validator_2_51_1  
---

# CheckDiscreetsTag

## MissingTag

### Description

Missing 'Measurement\/Discreets' tag for '{paramDisplayType}' Param with ID '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.51.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Button, pagebutton and discreet parameters should always have the Discreets tag.  
Additionally, Discreets tags should always have at least one of the following:  
\- Discreet tag(s)  
\- dependencyId attribute.
