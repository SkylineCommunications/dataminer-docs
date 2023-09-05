---  
uid: Validator_3_15_5  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyDataMinerNTGetRemoteTrend

### Description

Method 'SLProtocol.NotifyDataMiner(216\/\*NT\_GET\_REMOTE\_TREND\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.5      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyDataMiner(216\/\*NT\_GET\_REMOTE\_TREND\*\/, ...)' method is now considered obsolete.  
Instead, the 'GetTrendDataMessage' SLNet message is recommended as it is more efficient and up to date.
