---  
uid: Validator_3_15_14  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyProtocolNT\_GET\_PARAMETER\_BY\_NAME

### Description

Method 'SLProtocol.NotifyProtocol(85\/\*NT\_GET\_PARAMETER\_BY\_NAME\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.14     |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyProtocol(85\/\*NT\_GET\_PARAMETER\_BY\_NAME\*\/, ...)' method is now considered unrecommended.  
Instead, the wrapper method 'SLProtocol.GetParameterByName()' is recommended.
