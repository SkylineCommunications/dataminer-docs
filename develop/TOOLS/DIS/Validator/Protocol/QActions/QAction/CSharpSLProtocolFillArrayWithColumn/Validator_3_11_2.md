---  
uid: Validator_3_11_2  
---

# CSharpSLProtocolFillArrayWithColumn

## NonExistingColumn

### Description

Method 'SLProtocol.FillArrayWithColumn' references a non\-existing 'column' with PID '{columnPid}'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.11.2      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

SLProtocol.FillArrayWithColumn is used to update the values of a column.  
Make sure to provide it with an ID of a column parameter that exists.  
Using Parameter class is recommended.
