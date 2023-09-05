---  
uid: Validator_3_15_11  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyProtocolNT\_GET\_KEY\_POSITION

### Description

Method 'SLProtocol.NotifyProtocol(163\/\*NT\_GET\_KEY\_POSITION\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.11     |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyProtocol(163\/\*NT\_GET\_KEY\_POSITION\*\/, ...)' method is now considered obsolete.  
Instead of relying on row positions, working directly with calls relying on primary keys is recommended  
Examples:  
 \- Use 'SLProtocol.GetParameterIndexByKey()' instead of 'SLProtocol.GetParameterIndex()'.
