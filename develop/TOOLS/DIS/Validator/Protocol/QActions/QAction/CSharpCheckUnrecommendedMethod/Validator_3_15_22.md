---  
uid: Validator_3_15_22  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyProtocolNT\_SET\_PARAMETER\_BY\_DATA

### Description

Method 'SLProtocol.NotifyProtocol(86\/\*NT\_SET\_PARAMETER\_BY\_DATA\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.22     |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyProtocol(86\/\*NT\_SET\_PARAMETER\_BY\_DATA\*\/, ...)' method is now considered unrecommended.  
Instead, the wrapper method 'SLProtocol.SetParameterByData()' is recommended.
