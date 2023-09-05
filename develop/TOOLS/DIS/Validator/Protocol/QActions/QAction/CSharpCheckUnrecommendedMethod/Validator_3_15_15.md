---  
uid: Validator_3_15_15  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyProtocolNT\_GET\_DESCRIPTION

### Description

Method 'SLProtocol.NotifyProtocol(77\/\*NT\_GET\_DESCRIPTION\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.15     |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyProtocol(77\/\*NT\_GET\_DESCRIPTION\*\/, ...)' method is now considered unrecommended.  
Instead, the wrapper method 'SLProtocol.GetParameterDescription()' is recommended.
