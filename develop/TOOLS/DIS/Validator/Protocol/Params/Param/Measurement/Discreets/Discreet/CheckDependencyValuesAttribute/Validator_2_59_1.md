---  
uid: Validator_2_59_1  
---

# CheckDependencyValuesAttribute

## EmptyAttribute

### Description

Empty attribute 'Discreet@dependencyValues' in Param '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.59.1      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Discreet@dependencyValues attribute can be used in 2 scenarios:  
\- In combination with Discreets@dependencyId attribute.  
\- On a table contextMenu Param.  
    \- All referenced Params then require their RTDisplay tag to be set to true.  
See the guides for more info.
