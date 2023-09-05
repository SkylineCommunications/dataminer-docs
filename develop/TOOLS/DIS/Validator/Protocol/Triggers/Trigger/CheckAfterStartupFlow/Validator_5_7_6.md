---  
uid: Validator_5_7_6  
---

# CheckAfterStartupFlow

## InvalidAfterStartupGroupType

### Description

After startup Group must have a Type tag with value 'poll', 'poll trigger' or 'poll action'. Group ID '{groupId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Trigger     |
| Full Id      | 5.7.6       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

After startup flow must be:  
Trigger: after startup On protocol \-\> Action: 'execute next\/execute one top\/execute\/execute one now' On Group \-\> Group: poll\/poll action\/poll trigger.
