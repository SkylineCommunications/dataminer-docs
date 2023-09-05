---  
uid: Validator_5_7_5  
---

# CheckAfterStartupFlow

## InvalidAfterStartupActionType

### Description

After startup Action must have a Type tag with value 'execute next' or 'execute'. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Trigger     |
| Full Id      | 5.7.5       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

After startup flow must be:  
Trigger: after startup On protocol \-\> Action: 'execute next\/execute one top\/execute\/execute one now' On Group \-\> Group: poll\/poll action\/poll trigger.
