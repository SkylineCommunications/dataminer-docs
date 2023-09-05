---  
uid: Validator_18_10_3  
---

# CheckHiddenColumnsTag

## InvalidValue

### Description

Invalid value '{hiddenColumnsValue}' in tag 'HiddenColumns'. TreeControl ID '{treeControlPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.10.3     |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'TreeControl\/HiddenColumns' tag should contain a comma separated list of column PIDs that should not be visible in the TreeControl.  
The column PIDs should belong to one of the table displayed in the TreeControl.
