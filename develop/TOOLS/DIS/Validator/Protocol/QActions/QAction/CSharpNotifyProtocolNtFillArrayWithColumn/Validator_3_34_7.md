---  
uid: Validator_3_34_7  
---

# CSharpNotifyProtocolNtFillArrayWithColumn

## ColumnManagedByDataMiner

### Description

Unsupported set on column '{columnPid}' with '{optionLocation}' containing '{optionName}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.34.7      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Some columns are fully managed by DataMiner and therefore cannot be updated from the protocol.  
Examples:  
\- ColumnOption@Type\="state".  
\- ColumnOption@Option containing the 'element' option.
