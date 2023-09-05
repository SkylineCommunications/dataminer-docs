---  
uid: Validator_3_15_26  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyProtocolNT\_SET\_ROW

### Description

Method 'SLProtocol.NotifyProtocol(225\/\*NT\_SET\_ROW\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.26     |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyProtocol(225\/\*NT\_SET\_ROW\*\/, ...)' method is now considered unrecommended.  
Instead, the wrapper method 'SLProtocol.SetRow()' is recommended.
