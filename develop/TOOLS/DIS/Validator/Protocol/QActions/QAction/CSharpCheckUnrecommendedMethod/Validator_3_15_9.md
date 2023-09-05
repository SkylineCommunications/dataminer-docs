---  
uid: Validator_3_15_9  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyProtocolNT\_CHECK\_TRIGGER

### Description

Method 'SLProtocol.NotifyProtocol(134\/\*NT\_CHECK\_TRIGGER\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.9      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyProtocol(134\/\*NT\_CHECK\_TRIGGER\*\/, ...)' method is now considered unrecommended.  
Instead, the wrapper method 'SLProtocol.CheckTrigger()' is recommended.
