---  
uid: Validator_18_4_2  
---

# CheckParentAttribute

## ExcessiveAttribute

### Description

Unsupported attribute 'Table@parent' in TreeControl '{treeControlPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.4.2      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The Hierarchy\/Table@parent attribute should contain a table PID. This allows to define which table is on the above level.  
Note this does not make sense on the first Hierarchy\/Table tag but is mandatory on all other ones.
