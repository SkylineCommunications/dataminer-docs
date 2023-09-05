---  
uid: Validator_3_15_10  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyProtocolNT\_GET\_DATA

### Description

Method 'SLProtocol.NotifyProtocol(60\/\*NT\_GET\_DATA\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.10     |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyProtocol(60\/\*NT\_GET\_DATA\*\/, ...)' method is now considered unrecommended.  
Instead, the wrapper method 'SLProtocol.GetData()' is recommended.  
If the intention was only to check if the parameter is empty, then 'SLProtocol.IsEmpty()' is recommended.
