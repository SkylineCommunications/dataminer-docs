---  
uid: Validator_3_11_1  
---

# CSharpSLProtocolFillArrayWithColumn

## NonExistingTable

### Description

Method 'SLProtocol.FillArrayWithColumn' references a non\-existing 'table' with PID '{tablePid}'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.11.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

SLProtocol.FillArrayWithColumn is used to update the values of a column.  
Make sure to provide it with an ID of a table parameter that exists.  
Using Parameter class is recommended.
