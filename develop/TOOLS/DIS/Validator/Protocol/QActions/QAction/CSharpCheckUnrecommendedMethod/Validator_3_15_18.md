---  
uid: Validator_3_15_18  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyProtocolNT\_GET\_ROW

### Description

Method 'SLProtocol.NotifyProtocol(215\/\*NT\_GET\_ROW\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.18     |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyProtocol(215\/\*NT\_GET\_ROW\*\/, ...)' method is now considered unrecommended.  
Instead, the wrapper method 'SLProtocol.GetRow()' is recommended.
