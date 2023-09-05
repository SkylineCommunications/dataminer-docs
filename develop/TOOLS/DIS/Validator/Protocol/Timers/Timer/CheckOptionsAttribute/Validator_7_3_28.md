---  
uid: Validator_7_3_28  
---

# CheckOptionsAttribute

## UseOfObsoleteQActionOption

### Description

The use of the qaction option is obsolete.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Timer       |
| Full Id      | 7.3.28      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The use of the qaction option is obsolete as it does not execute multi\-threaded but sequentially. Instead, use the qactionBefore option.
