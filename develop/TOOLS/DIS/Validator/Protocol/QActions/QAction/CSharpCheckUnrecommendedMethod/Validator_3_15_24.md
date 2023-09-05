---  
uid: Validator_3_15_24  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyProtocolNT\_SET\_DESCRIPTION

### Description

Method 'SLProtocol.NotifyProtocol(131\/\*NT\_SET\_DESCRIPTION\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.24     |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyProtocol(131\/\*NT\_SET\_DESCRIPTION\*\/, ...)' method is now considered unrecommended.  
Instead, the wrapper method 'SLProtocol.SetParameterDescription()' is recommended.
