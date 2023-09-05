---  
uid: Validator_18_12_2  
---

# CheckOverrideIconColumnsTag

## UntrimmedTag

### Description

Untrimmed tag 'OverrideIconColumns' in TreeControl '{treeControlPid}'. Current value '{untrimmedValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.12.2     |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

'TreeControl\/OverrideIconColumns' tag should contain a comma separated list of column PIDs that should be used to define the icons in the TreeControl structure.  
The column PIDs should belong to one of the tables in the TreeControl Hierarchy and only one column per table should be used.
