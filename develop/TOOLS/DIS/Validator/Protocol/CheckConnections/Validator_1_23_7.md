---  
uid: Validator_1_23_7  
---

# CheckConnections

## UnrecommendedSyntax2

### Description

Unrecommended use of the 'Protocol\/Connections' syntax.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Protocol    |
| Full Id      | 1.23.7      |
| Severity     | Minor       |
| Certainty    | Uncertain   |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Connections can be defined either via 'Protocol\/Type' or via 'Protocol\/Connections' but both syntaxes can not be used in the same protocol.  
\- 'Protocol\/Type' is the recommended syntax.  
\- 'Protocol\/Connections' should only be used in case one of the rare features only available in this syntax is needed.
