---  
uid: Validator_3_15_21  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyProtocolNT\_SET\_PARAMETER\_WITH\_HISTORY

### Description

Method 'SLProtocol.NotifyProtocol(256\/\*NT\_SET\_PARAMETER\_WITH\_HISTORY\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.21     |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyProtocol(256\/\*NT\_SET\_PARAMETER\_WITH\_HISTORY\*\/, ...)' method is now considered unrecommended.  
Instead, the wrapper method 'SLProtocol.SetParameter()' is recommended.
