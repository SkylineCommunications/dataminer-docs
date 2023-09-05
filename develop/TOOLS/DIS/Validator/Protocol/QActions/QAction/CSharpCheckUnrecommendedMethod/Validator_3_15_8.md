---  
uid: Validator_3_15_8  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyProtocolNTAddRow

### Description

Method 'SLProtocol.NotifyProtocol(149\/\*NT\_ADD\_ROW\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.8      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyProtocol(149\/\*NT\_ADD\_ROW\*\/, ...)' method is now considered unrecommended.  
Instead, the wrapper method 'SLProtocol.AddRow()' is recommended.
