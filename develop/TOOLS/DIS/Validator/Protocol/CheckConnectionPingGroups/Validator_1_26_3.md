---  
uid: Validator_1_26_3  
---

# CheckConnectionPingGroups

## MultiplePingPairsForConnection

### Description

Multiple ping pairs for connection with name '{connectionName}' and type '{connectionType}'. Connection ID '{connectionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Protocol    |
| Full Id      | 1.26.3      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

There should always be one and only one ping pair per (smart\-)serial connection.
