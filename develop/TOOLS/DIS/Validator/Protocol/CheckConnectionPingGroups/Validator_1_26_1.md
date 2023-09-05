---  
uid: Validator_1_26_1  
---

# CheckConnectionPingGroups

## InvalidPingGroupType

### Description

Ping group for '{connectionType}' connection is not a '{connectionType}' poll group. Group ID '{groupId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Protocol    |
| Full Id      | 1.26.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

When to define a poll group:  
If a protocol has, at least, one group of type "poll" (no matter on which connection), then, the main connection should have a ping group defined in the protocol.  
How to define a poll group:  
No matter the (1st) connection type, if a group with id\="\-1" is defined, it will be the ping group.  
Otherwise:  
    \- SNMP: the first group defined in the XML.  
    \- (smart\-)serial:   
        \- The pair with ping attribute set to true.  
        \- If no such pair, the pair with lowest ID.
