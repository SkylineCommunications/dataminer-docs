---  
uid: Validator_2_54_5  
---

# CheckDependencyId

## ReferencedParamWrongType

### Description

Invalid Param Type '{referencedParamType}' on Param referenced by a 'Discreets@dependencyId' attribute. Param ID '{referencedPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.54.5      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Discreets@dependencyId attribute should contain the ID of a Param.  
The referenced Param is expected to:  
\- Be of type 'read' or 'read bit'.  
\- Have RTDisplay tag set to 'true'.
