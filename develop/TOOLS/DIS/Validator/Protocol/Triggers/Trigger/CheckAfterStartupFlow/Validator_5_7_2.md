---  
uid: Validator_5_7_2  
---

# CheckAfterStartupFlow

## InvalidAfterStartupActionCondition

### Description

After startup Action can't have a Condition. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Trigger     |
| Full Id      | 5.7.2       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Move the condition to a later step.

### Details

A condition should not be used until the after startup flow went through the protocol thread (via a poll group).
