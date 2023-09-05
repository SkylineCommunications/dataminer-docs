---  
uid: Validator_18_5_5  
---

# CheckConditionAttribute

## InvalidValueInAttribute\_Sub

### Description

Invalid option '{optionName}' in attribute 'Table@condition'. TreeControl ID '{treeControlId}'. Current Value '{optionValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.5.5      |
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
