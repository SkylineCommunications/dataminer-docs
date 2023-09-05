---  
uid: Validator_3_34_4  
---

# CSharpNotifyProtocolNtFillArrayWithColumn

## ColumnMissingHistorySet

### Description

NotifyProtocol(220\/\*NT\_FILL\_ARRAY\_WITH\_COLUMN\*\/, ...) method with one or more DateTime(s) given to it requires 'Param@historySet\=true' on column with PID '{columnPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.34.4      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

NotifyProtocol(220\/\*NT\_FILL\_ARRAY\_WITH\_COLUMN\*\/, ...) with DateTime given on table or cell level requires related column parameter(s) to be set to have the 'Param@historySet' attribute set to 'true'.
