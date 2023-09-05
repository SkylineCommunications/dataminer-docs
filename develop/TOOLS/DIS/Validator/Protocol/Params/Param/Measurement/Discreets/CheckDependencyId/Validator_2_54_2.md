---  
uid: Validator_2_54_2  
---

# CheckDependencyId

## UntrimmedAttribute

### Description

Untrimmed attribute 'Discreets@dependencyId' in Param '{pid}'. Current value '{untrimmedValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.54.2      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

Discreets@dependencyId attribute should contain the ID of a Param.  
The referenced Param is expected to:  
\- Be of type 'read' or 'read bit'.  
\- Have RTDisplay tag set to 'true'.
