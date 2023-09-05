---  
uid: Validator_5_7_3  
---

# CheckAfterStartupFlow

## InvalidAfterStartupTriggerType

### Description

After startup Trigger must have a Type tag with value 'action'. Trigger ID '{triggerId}'

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Trigger     |
| Full Id      | 5.7.3       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

After startup flow must be:  
Trigger: after startup On protocol \-\> Action: 'execute next\/execute one top\/execute\/execute one now' On Group \-\> Group: poll\/poll action\/poll trigger.
