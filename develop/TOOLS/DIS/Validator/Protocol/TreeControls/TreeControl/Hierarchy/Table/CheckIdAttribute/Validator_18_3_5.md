---  
uid: Validator_18_3_5  
---

# CheckIdAttribute

## NonExistingId

### Description

Attribute 'Hierarchy\/Table@id' references a non\-existing 'Table' with PID '{tablePid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.3.5      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The Hierarchy\/Table@id attribute should contain a table PID allowing to define which table contains entries for a specific level of the TreeControl.  
Such table is expected to have RTDisplay tag set to 'true'.
