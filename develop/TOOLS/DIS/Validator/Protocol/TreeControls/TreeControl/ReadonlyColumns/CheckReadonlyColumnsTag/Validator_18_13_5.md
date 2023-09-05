---  
uid: Validator_18_13_5  
---

# CheckReadonlyColumnsTag

## NonExistingIds\_Sub

### Description

Tag 'ReadonlyColumns' references a non\-existing 'Column' with PID '{columnPid}'. TreeControl ID '{treeControlPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.13.5     |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'TreeControl\/ReadonlyColumns' tag should contain a comma separated list of column PIDs for which the value edition via the TreeControl should be disabled.  
The column PIDs should belong to one of the tables displayed in the TreeControl.
