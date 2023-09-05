---  
uid: Validator_6_22_3  
---

# CheckNrAttribute

## UntrimmedAttribute

### Description

Untrimmed value '{untrimmedValue}' in attribute 'Action\/On@nr'. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.22.3      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

The 'Action\/On@nr' attribute only makes sense if 'Action\/Type' tag is set to one of the following values:  
\- reverse: Semicolon (;) separated list of 0\-based position(s) of the parameter in the command\/response.
