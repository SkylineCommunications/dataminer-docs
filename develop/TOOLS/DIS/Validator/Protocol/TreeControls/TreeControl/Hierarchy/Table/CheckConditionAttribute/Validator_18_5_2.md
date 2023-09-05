---  
uid: Validator_18_5_2  
---

# CheckConditionAttribute

## UntrimmedColumnPid

### Description

Untrimmed value '{untrimmedColumnPid}' in attribute 'Table@condition' in TreeControl '{treeControlId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.5.2      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Hierarchy\/Table@condition attribute should have one of the following format:  
\- {conditionColumnPid}:{conditionValue}  
\- {conditionColumnPid}:{conditionValue};filter:fk\={fkColumnPid}  
where:  
\- {conditionColumnPid} refers to a column which should have its RTDisplay set to true.  
\- {conditionValue} allows to specify the value to be present in column referred by {conditionColumnPid} for the condition to match.
