---  
uid: Validator_3_34_3  
---

# CSharpNotifyProtocolNtFillArrayWithColumn

## NonExistingColumn

### Description

Method 'NotifyProtocol(220\/\*NT\_FILL\_ARRAY\_WITH\_COLUMN\*\/, ...)' references a non\-existing 'column' with PID '{columnPid}'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.34.3      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

NotifyProtocol(220\/\*NT\_FILL\_ARRAY\_WITH\_COLUMN\*\/, ...) is used to update the values of column(s).  
Make sure to provide it with column parameter IDs that exists excluding the index (Primary Key) column.  
Using Parameter class is recommended.
