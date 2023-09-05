---  
uid: Validator_5_7_4  
---

# CheckAfterStartupFlow

## InvalidAfterStartupActionOn

### Description

After startup Action must have an On tag with value 'group'. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Trigger     |
| Full Id      | 5.7.4       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

After startup flow must be:  
Trigger: after startup On protocol \-\> Action: 'execute next\/execute one top\/execute\/execute one now' On Group \-\> Group: poll\/poll action\/poll trigger.
