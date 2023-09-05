---  
uid: Validator_1_26_2  
---

# CheckConnectionPingGroups

## PingSerialPairHasNoResponse

### Description

Ping pair for '{connectionType}' connection contains no response. Pair ID '{pairId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Protocol    |
| Full Id      | 1.26.2      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The pair used for the ping group should always contain a response.
