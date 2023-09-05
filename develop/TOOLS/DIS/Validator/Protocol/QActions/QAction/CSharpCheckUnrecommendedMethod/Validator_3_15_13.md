---  
uid: Validator_3_15_13  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyProtocolNT\_GET\_PARAMETER\_BY\_DATA

### Description

Method 'SLProtocol.NotifyProtocol( 87\/\*NT\_GET\_PARAMETER\_BY\_DATA\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.13     |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyProtocol( 87\/\*NT\_GET\_PARAMETER\_BY\_DATA\*\/, ...)' method is now considered unrecommended.  
Instead, the wrapper method 'SLProtocol.GetParameterByData()' is recommended.
