---  
uid: Validator_18_13_4  
---

# CheckReadonlyColumnsTag

## NonExistingIds

### Description

Tag 'ReadonlyColumns' references non\-existing IDs. TreeControl ID '{treeControlPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.13.4     |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'TreeControl\/ReadonlyColumns' tag should contain a comma separated list of column PIDs for which the value edition via the TreeControl should be disabled.  
The column PIDs should belong to one of the tables displayed in the TreeControl.
