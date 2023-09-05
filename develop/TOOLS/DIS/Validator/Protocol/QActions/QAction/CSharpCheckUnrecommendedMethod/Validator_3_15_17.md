---  
uid: Validator_3_15_17  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyProtocolNT\_GET\_ITEM\_DATA

### Description

Method 'SLProtocol.NotifyProtocol(88\/\*NT\_GET\_ITEM\_DATA\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.17     |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyProtocol(88\/\*NT\_GET\_ITEM\_DATA\*\/, ...)' method is now considered unrecommended.  
Instead, the wrapper method 'SLProtocol.GetParameterItemData()' is recommended.
