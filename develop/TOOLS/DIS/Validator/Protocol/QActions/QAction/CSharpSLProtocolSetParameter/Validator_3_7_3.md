---  
uid: Validator_3_7_3  
---

# CSharpSLProtocolSetParameter

## ParamMissingHistorySet

### Description

SLProtocol.SetParameter overload with 'ValueType timeInfo' argument requires 'Param@historySet\=true'. Param ID '{paramId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.7.3       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

Every overload of the 'SLProtocol.SetParameter' method having the 'ValueType timeInfo' argument is meant to execute a historySet on a standlone parameter.  
Such method requires the standalone parameter to be set to have the 'Param@historySet' attribute set to 'true'.
