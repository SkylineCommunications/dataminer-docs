---  
uid: Validator_3_10_1  
---

# CSharpSLProtocolFillArrayNoDelete

## NonExistingParam

### Description

Method 'SLProtocol.FillArrayNoDelete' references a non\-existing 'table' with PID '{tablePid}'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.10.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

SLProtocol.FillArrayNoDelete is used to update a table with new values.  
Make sure to provide it with an ID of a table parameter that exists.  
Using Parameter class is recommended.
