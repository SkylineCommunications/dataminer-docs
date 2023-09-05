---  
uid: Validator_18_13_3  
---

# CheckReadonlyColumnsTag

## InvalidValue

### Description

Invalid value '{readonlyColumnsValue}' in tag 'ReadonlyColumns'. TreeControl ID '{treeControlPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.13.3     |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'TreeControl\/ReadonlyColumns' tag should contain a comma separated list of column PIDs for which the value edition via the TreeControl should be disabled.  
The column PIDs should belong to one of the tables displayed in the TreeControl.
