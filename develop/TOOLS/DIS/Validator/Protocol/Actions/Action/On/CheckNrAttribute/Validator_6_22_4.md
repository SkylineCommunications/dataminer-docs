---  
uid: Validator_6_22_4  
---

# CheckNrAttribute

## InvalidValue

### Description

Invalid value '{attributeValue}' in attribute 'Action\/On@nr'. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.22.4      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Action\/On@nr' attribute only makes sense if 'Action\/Type' tag is set to one of the following values:  
\- reverse: Semicolon (;) separated list of 0\-based position(s) of the parameter in the command\/response.
