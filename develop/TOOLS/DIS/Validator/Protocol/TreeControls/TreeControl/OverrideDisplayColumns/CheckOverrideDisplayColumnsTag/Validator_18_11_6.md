---  
uid: Validator_18_11_6  
---

# CheckOverrideDisplayColumnsTag

## DuplicateId

### Description

Duplicate value '{duplicateId}' in tag 'OverrideDisplayColumns'. TreeControl ID '{treeControlId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.11.6     |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'TreeControl\/OverrideDisplayColumns' tag should contain a comma separated list of column PIDs that should be used as display name in the TreeControl structure.  
The column PIDs should belong to one of the tables displayed in the TreeControl Hierarchy and only one column per table should be used.  
For each column PID, an extra pipeline can optionally be added followed by a column PID to be used for sorting items.
