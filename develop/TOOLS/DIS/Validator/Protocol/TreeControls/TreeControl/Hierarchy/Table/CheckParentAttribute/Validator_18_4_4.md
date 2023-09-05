---  
uid: Validator_18_4_4  
---

# CheckParentAttribute

## UntrimmedAttribute

### Description

Untrimmed attribute 'Table@parent' in TreeControl '{treeControlPid}'. Current value '{untrimmedValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.4.4      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

The Hierarchy\/Table@parent attribute should contain a table PID. This allows to define which table is on the above level.  
Note this does not make sense on the first Hierarchy\/Table tag but is mandatory on all other ones.
