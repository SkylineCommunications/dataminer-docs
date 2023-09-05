---  
uid: Validator_18_10_4  
---

# CheckHiddenColumnsTag

## NonExistingIds

### Description

Tag 'HiddenColumns' references non\-existing IDs. TreeControl ID '{treeControlPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.10.4     |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'TreeControl\/HiddenColumns' tag should contain a comma separated list of column PIDs that should not be visible in the TreeControl.  
The column PIDs should belong to one of the table displayed in the TreeControl.
