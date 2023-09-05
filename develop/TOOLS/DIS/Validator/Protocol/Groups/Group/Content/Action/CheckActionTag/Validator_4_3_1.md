---  
uid: Validator_4_3_1  
---

# CheckActionTag

## NonExistingId

### Description

Tag 'Content\/Action' references a non\-existing 'Action' with ID '{actionId}'. Group ID '{groupId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Group       |
| Full Id      | 4.3.1       |
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
