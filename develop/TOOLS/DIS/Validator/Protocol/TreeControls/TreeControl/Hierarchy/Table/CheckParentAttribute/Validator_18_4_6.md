---  
uid: Validator_18_4_6  
---

# CheckParentAttribute

## NonExistingId

### Description

Attribute 'Hierarchy\/Table@parent' references a non\-existing 'Table' with PID '{tablePid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.4.6      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The Hierarchy\/Table@parent attribute should contain a table PID. This allows to define which table is on the above level.  
Note this does not make sense on the first Hierarchy\/Table tag but is mandatory on all other ones.
