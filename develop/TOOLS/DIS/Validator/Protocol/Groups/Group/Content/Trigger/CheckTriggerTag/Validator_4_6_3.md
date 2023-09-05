---  
uid: Validator_4_6_3  
---

# CheckTriggerTag

## InvalidTriggerTag

### Description

Invalid value '{value}' in tag 'Content\/Trigger'. Group ID '{groupId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Group       |
| Full Id      | 4.6.3       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Group\/Content tag should contain a list of 'Param', 'Pair', 'Session', 'Trigger' or 'Action' tags. Note that only one type of them is allowed for a specific Group.  
 \- 'Param' tags should refer to the id of an existing Param.  
 \- 'Pair' tags should refer to the id of an existing Pair.  
 \- 'Session' tags should refer to the id of an existing HTTP\/Session.  
 \- 'Trigger' tags should refer to the id of an existing Trigger.  
 \- 'Action' tags should refer to the id of an existing Action.
