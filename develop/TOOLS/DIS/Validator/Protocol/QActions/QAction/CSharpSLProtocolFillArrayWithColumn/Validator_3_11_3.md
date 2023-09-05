---  
uid: Validator_3_11_3  
---

# CSharpSLProtocolFillArrayWithColumn

## ParamMissingHistorySet

### Description

SLProtocol.FillArrayWithColumn overload with 'DateTime? timeInfo' argument requires 'Param@historySet\=true'. column PID '{columnPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.11.3      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

Every overload of the 'SLProtocol.FillArrayWithColumn' method having the 'DateTime? timeInfo' argument is meant to execute a historySet.  
Such method requires the column to be set to have the 'Param@historySet' attribute set to 'true'.
