---  
uid: Validator_18_2_6  
---

# CheckPathAttribute

## DuplicateId

### Description

Duplicate value '{duplicateId}' in attribute 'Hierarchy@path'. TreeControl ID '{treeControlId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.2.6      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The Hierarchy@path attribute should contain a comma separated list of table PIDs.  
Those tables will define the different levels of the TreeControl.  
Note that this can also be achieved with more flexibility via the Hierarchy\/Table tags.
