---  
uid: Validator_3_8_1  
---

# CSharpSLProtocolSetRow

## NonExistingParam

### Description

Method 'SLProtocol.SetRow' references a non\-existing 'table' with PID '{tablePid}'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.8.1       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

SLProtocol.SetRow is used to update the values of a table row.  
Make sure to provide it with an ID of a table parameter that exists.  
Using Parameter class is recommended.
