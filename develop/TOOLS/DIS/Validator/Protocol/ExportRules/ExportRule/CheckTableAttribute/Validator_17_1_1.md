---  
uid: Validator_17_1_1  
---

# CheckTableAttribute

## NonExistingId

### Description

Attribute 'ExportRule@table' references a non\-existing 'Table' with PID '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | ExportRule  |
| Full Id      | 17.1.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Make sure every attribute that links to a parameter is configured correctly and links to an existing parameter id.
