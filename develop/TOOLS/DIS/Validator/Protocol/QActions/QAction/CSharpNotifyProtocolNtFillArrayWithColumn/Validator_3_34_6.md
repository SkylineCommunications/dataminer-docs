---  
uid: Validator_3_34_6  
---

# CSharpNotifyProtocolNtFillArrayWithColumn

## HardCodedColumnPid

### Description

Unrecommended use of magic number '{hardCodedColumnPid}', use 'Parameter' class instead. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.34.6      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

NotifyProtocol(220\/\*NT\_FILL\_ARRAY\_WITH\_COLUMN\*\/, ...) is used to update the values of column(s).  
Make sure to provide it with column parameter IDs that exists excluding the index (Primary Key) column.  
Using Parameter class is recommended.
