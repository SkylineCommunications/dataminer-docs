---  
uid: Validator_3_34_5  
---

# CSharpNotifyProtocolNtFillArrayWithColumn

## HardCodedTablePid

### Description

Unrecommended use of magic number '{hardCodedTablePid}', use 'Parameter' class instead. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.34.5      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

NotifyProtocol(220\/\*NT\_FILL\_ARRAY\_WITH\_COLUMN\*\/, ...) is used to update the values of column(s).  
Make sure to provide it with an ID of a table parameter that exists.  
Using Parameter class is recommended.
