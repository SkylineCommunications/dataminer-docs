---  
uid: Validator_2_52_1  
---

# CheckDiscreetTag

## MissingTag

### Description

Missing 'Discreet' tag(s) in 'Measurement\/Discreets' tag. Param ID '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.52.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Discreets tags should always have at least one of the following:  
\- Discreet tag(s)  
\- dependencyId attribute.
