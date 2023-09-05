---  
uid: Validator_2_54_3  
---

# CheckDependencyId

## InvalidValue

### Description

Invalid value '{attributeValue}' in attribute 'Discreets@dependencyId'. Param ID '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.54.3      |
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
