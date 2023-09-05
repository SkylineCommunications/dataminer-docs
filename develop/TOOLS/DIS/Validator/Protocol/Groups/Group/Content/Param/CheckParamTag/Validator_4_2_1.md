---  
uid: Validator_4_2_1  
---

# CheckParamTag

## NonExistingId

### Description

Tag 'Content\/Param' references a non\-existing 'Param' with ID '{pid}'. Group ID '{groupId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Group       |
| Full Id      | 4.2.1       |
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
