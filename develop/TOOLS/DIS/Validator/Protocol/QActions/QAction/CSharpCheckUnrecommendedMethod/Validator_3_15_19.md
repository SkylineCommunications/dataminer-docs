---  
uid: Validator_3_15_19  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyProtocolNT\_ARRAY\_ROW\_COUNT

### Description

Method 'SLProtocol.NotifyProtocol(195\/\*NT\_ARRAY\_ROW\_COUNT\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.19     |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyProtocol(195\/\*NT\_ARRAY\_ROW\_COUNT\*\/, ...)' method is now considered unrecommended.  
Instead, the wrapper method 'SLProtocol.RowCount()' is recommended.  
If the intention is to loop over rows based on the result, using a call to get columns straight away is recommended.
