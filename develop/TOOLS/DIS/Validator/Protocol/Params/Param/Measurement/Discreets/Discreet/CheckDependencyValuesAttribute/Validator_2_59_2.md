---  
uid: Validator_2_59_2  
---

# CheckDependencyValuesAttribute

## UntrimmedAttribute

### Description

Untrimmed attribute 'Discreet@dependencyValues' in Param '{pid}'. Current value '{untrimmedValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.59.2      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

Discreet@dependencyValues attribute can be used in 2 scenarios:  
\- In combination with Discreets@dependencyId attribute.  
\- On a table contextMenu Param.  
    \- All referenced Params then require their RTDisplay tag to be set to true.  
See the guides for more info.
