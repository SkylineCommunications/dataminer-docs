---  
uid: Validator_3_9_1  
---

# CSharpSLProtocolFillArray

## NonExistingParam

### Description

Method 'SLProtocol.FillArray' references a non\-existing 'table' with PID '{tablePid}'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.9.1       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

SLProtocol.FillArray is used to update a table with new values.  
Make sure to provide it with an ID of a table parameter that exists.  
Using Parameter class is recommended.
