---  
uid: Validator_18_11_2  
---

# CheckOverrideDisplayColumnsTag

## UntrimmedTag

### Description

Untrimmed tag 'OverrideDisplayColumns' in TreeControl '{treeControlPid}'. Current value '{untrimmedValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.11.2     |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

'TreeControl\/OverrideDisplayColumns' tag should contain a comma separated list of column PIDs that should be used as display name in the TreeControl structure.  
The column PIDs should belong to one of the tables displayed in the TreeControl Hierarchy and only one column per table should be used.  
For each column PID, an extra pipeline can optionally be added followed by a column PID to be used for sorting items.
