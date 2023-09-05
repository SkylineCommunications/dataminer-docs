---  
uid: Validator_6_22_2  
---

# CheckNrAttribute

## EmptyAttibute

### Description

Empty attribute 'Action\/On@nr' in Action '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.22.2      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Action\/On@nr' attribute only makes sense if 'Action\/Type' tag is set to one of the following values:  
\- reverse: Semicolon (;) separated list of 0\-based position(s) of the parameter in the command\/response.
