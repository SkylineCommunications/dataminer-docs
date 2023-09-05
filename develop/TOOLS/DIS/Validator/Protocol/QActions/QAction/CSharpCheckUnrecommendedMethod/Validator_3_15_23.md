---  
uid: Validator_3_15_23  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyProtocolNT\_SET\_PARAMETER\_BY\_NAME

### Description

Method 'SLProtocol.NotifyProtocol(84\/\*NT\_SET\_PARAMETER\_BY\_NAME\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.23     |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyProtocol(84\/\*NT\_SET\_PARAMETER\_BY\_NAME\*\/, ...)' method is now considered unrecommended.  
Instead, the wrapper method 'SLProtocol.SetParameterByName()' is recommended.
