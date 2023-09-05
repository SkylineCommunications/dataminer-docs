---  
uid: Validator_3_15_25  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyProtocolNT\_SET\_ITEM\_DATA

### Description

Method 'SLProtocol.NotifyProtocol(89\/\*NT\_SET\_ITEM\_DATA\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.25     |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyProtocol(89\/\*NT\_SET\_ITEM\_DATA\*\/, ...)' method is now considered unrecommended.  
Instead, the wrapper method 'SLProtocol.SetParameterItemData()' is recommended.
