---  
uid: Validator_18_4_5  
---

# CheckParentAttribute

## InvalidValue

### Description

Invalid value '{attributeValue}' in attribute 'Table@parent'. TreeControl ID '{treeControlPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.4.5      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The Hierarchy\/Table@parent attribute should contain a table PID. This allows to define which table is on the above level.  
Note this does not make sense on the first Hierarchy\/Table tag but is mandatory on all other ones.
