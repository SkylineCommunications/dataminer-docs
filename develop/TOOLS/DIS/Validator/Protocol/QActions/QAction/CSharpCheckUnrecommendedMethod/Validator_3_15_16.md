---  
uid: Validator_3_15_16  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyProtocolNT\_GET\_PARAMETER\_INDEX

### Description

Method 'SLProtocol.NotifyProtocol(122\/\*NT\_GET\_PARAMETER\_INDEX\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.16     |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyProtocol(122\/\*NT\_GET\_PARAMETER\_INDEX\*\/, ...)' method is now considered unrecommended.  
Instead, the wrapper method 'SLProtocol.GetParameterIndexByKey()' is recommended.
