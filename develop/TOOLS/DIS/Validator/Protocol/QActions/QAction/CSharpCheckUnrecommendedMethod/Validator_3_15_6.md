---  
uid: Validator_3_15_6  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedNotifyDataMinerNTGetRemoteTrendAvg

### Description

Method 'SLProtocol.NotifyDataMiner(260\/\*NT\_GET\_REMOTE\_TREND\_AVG\*\/, ...)' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.6      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.NotifyDataMiner(260\/\*NT\_GET\_REMOTE\_TREND\_AVG\*\/, ...)' method is now considered obsolete.  
Instead, the 'GetTrendDataMessage' SLNet message is recommended as it is more efficient and up to date.
