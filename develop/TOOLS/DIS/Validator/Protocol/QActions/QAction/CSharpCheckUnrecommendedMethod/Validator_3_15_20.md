---  
uid: Validator_3_15_20  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyProtocolNT\_NOTIFY\_DISPLAY

### Description

Method 'SLProtocol.NotifyProtocol(123\/\*NT\_NOTIFY\_DISPLAY\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.20     |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyProtocol(123\/\*NT\_NOTIFY\_DISPLAY\*\/, ...)' method is now considered unrecommended.  
Instead, the wrapper method 'SLProtocol.SendToDisplay()' is recommended.
