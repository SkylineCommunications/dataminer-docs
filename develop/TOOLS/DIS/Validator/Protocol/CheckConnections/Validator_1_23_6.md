---  
uid: Validator_1_23_6  
---

# CheckConnections

## InvalidCombinationOfSyntax1And2

### Description

Connections can not be defined simultaneously via 'Protocol\/Type' and 'Protocol\/Connections'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Protocol    |
| Full Id      | 1.23.6      |
| Severity     | Critical    |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Connections can be defined either via 'Protocol\/Type' or via 'Protocol\/Connections' but both syntaxes can not be used in the same protocol.  
\- 'Protocol\/Type' is the recommended syntax.  
\- 'Protocol\/Connections' should only be used in case one of the rare features only available in this syntax is needed.
