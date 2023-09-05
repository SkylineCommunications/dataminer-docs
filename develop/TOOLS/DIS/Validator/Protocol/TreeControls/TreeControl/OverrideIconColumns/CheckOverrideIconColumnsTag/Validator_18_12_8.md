---  
uid: Validator_18_12_8  
---

# CheckOverrideIconColumnsTag

## UntrimmedValueInTag\_Sub

### Description

Untrimmed value '{untrimmedValue}' in tag 'OverrideIconColumns'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.12.8     |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'TreeControl\/OverrideIconColumns' tag should contain a comma separated list of column PIDs that should be used to define the icons in the TreeControl structure.  
The column PIDs should belong to one of the tables in the TreeControl Hierarchy and only one column per table should be used.
