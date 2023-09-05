---  
uid: Validator_3_9_2  
---

# CSharpSLProtocolFillArray

## ParamMissingHistorySet

### Description

SLProtocol.FillArray overload with 'DateTime? timeInfo' argument requires 'Param@historySet\=true'. column PID '{columnPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.9.2       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

Every overload of the 'SLProtocol.FillArray' method having the 'DateTime? timeInfo' argument is meant to execute a historySet.  
Such method requires the columns of the table to be set to have the 'Param@historySet' attribute set to 'true'.
