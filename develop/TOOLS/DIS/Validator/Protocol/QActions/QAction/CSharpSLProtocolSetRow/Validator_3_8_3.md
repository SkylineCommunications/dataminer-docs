---  
uid: Validator_3_8_3  
---

# CSharpSLProtocolSetRow

## ParamMissingHistorySet

### Description

SLProtocol.SetRow overload with 'ValueType timeInfo' argument requires 'Param@historySet\=true'. column PID '{columnPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.8.3       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

Every overload of the 'SLProtocol.SetRow' method having the 'ValueType timeInfo' argument is meant to execute a historySet.  
Such method requires the columns of table to be set to have the 'Param@historySet' attribute set to 'true'.
