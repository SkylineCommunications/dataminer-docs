---  
uid: Validator_3_34_8  
---

# CSharpNotifyProtocolNtFillArrayWithColumn

## ColumnManagedByProtocolItem

### Description

Unsupported set on column '{columnPid}' managed by {managedByItemKind} '{managedByItemId}' with '{optionLocation}' containing '{optionName}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.34.8      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Some columns are fully managed by protocol items and therefore cannot be updated from QActions.  
Examples:  
\- Multi\-threaded timers with following ping options: rttColumn, timestampColumn, jitterColumn, latencyColumn, packetLossRateColumn.  
\- Merge actions (result destination).  
\- ...
