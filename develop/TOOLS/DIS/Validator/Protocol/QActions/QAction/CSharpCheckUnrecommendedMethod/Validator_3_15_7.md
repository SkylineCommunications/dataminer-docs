---  
uid: Validator_3_15_7  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyProtocolNTDeleteRow

### Description

Method 'SLProtocol.NotifyProtocol(156\/\*NT\_DELETE\_ROW\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.7      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyProtocol(156\/\*NT\_DELETE\_ROW\*\/, ...)' method is now considered unrecommended.  
Instead, the wrapper method 'SLProtocol.DeleteRow()' is recommended.
