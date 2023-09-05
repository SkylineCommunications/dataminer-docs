---  
uid: Validator_10_1_1  
---

# CheckCommandLogic

## MissingCrcCommandAction

### Description

No 'CRC' Action triggered before Command '{commandId}'. 'CRC' Param '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Command     |
| Full Id      | 10.1.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Make sure a CRC action is triggered before command.
