---  
uid: Validator_7_3_27  
---

# CheckOptionsAttribute

## UseOfObsoleteTimeoutPidOptionInPingOption

### Description

The use of the timeoutPid option in the ping option is obsolete.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Timer       |
| Full Id      | 7.3.27      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The use of the timeoutPid option in the ping option is obsolete. Instead, provide an additional column in the table that will indicate whether there was a timeout for each row.
