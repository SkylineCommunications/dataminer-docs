---  
uid: Validator_18_13_2  
---

# CheckReadonlyColumnsTag

## UntrimmedTag

### Description

Untrimmed tag 'ReadonlyColumns' in TreeControl '{treeControlPid}'. Current value '{untrimmedValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.13.2     |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

'TreeControl\/ReadonlyColumns' tag should contain a comma separated list of column PIDs for which the value edition via the TreeControl should be disabled.  
The column PIDs should belong to one of the tables displayed in the TreeControl.
