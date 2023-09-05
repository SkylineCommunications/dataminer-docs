---  
uid: Validator_18_2_5  
---

# CheckPathAttribute

## NonExistingIdsInAttribute\_Sub

### Description

Attribute 'Hierarchy@path' references a non\-existing 'Table' with PID '{paramId}'. TreeControl ID '{treeControlPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.2.5      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The Hierarchy@path attribute should contain a comma separated list of table PIDs.  
Those tables will define the different levels of the TreeControl.  
Note that this can also be achieved with more flexibility via the Hierarchy\/Table tags.
