---  
uid: Validator_11_1_1  
---

# CheckResponseLogic

## MissingCrcResponseAction

### Description

No 'CRC' Action triggered before Response '{responseId}'. 'CRC' Param '{paramPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Response    |
| Full Id      | 11.1.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Make sure a CRC action is triggered after response.
