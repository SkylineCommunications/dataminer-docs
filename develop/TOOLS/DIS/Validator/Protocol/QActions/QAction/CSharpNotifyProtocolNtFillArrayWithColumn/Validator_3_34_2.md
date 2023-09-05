---  
uid: Validator_3_34_2  
---

# CSharpNotifyProtocolNtFillArrayWithColumn

## NonExistingTable

### Description

Method 'NotifyProtocol(220\/\*NT\_FILL\_ARRAY\_WITH\_COLUMN\*\/, ...)' references a non\-existing 'table' with PID '{tablePid}'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.34.2      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

NotifyProtocol(220\/\*NT\_FILL\_ARRAY\_WITH\_COLUMN\*\/, ...) is used to update the values of column(s).  
Make sure to provide it with the ID of a table parameter that exists.  
Using Parameter class is recommended.
