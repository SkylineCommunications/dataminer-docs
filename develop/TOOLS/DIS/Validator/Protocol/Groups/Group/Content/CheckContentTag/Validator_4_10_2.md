---  
uid: Validator_4_10_2  
---

# CheckContentTag

## MixedTypes

### Description

Unsupported mixed group content '{contentTypes}'. Group ID '{groupId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Group       |
| Full Id      | 4.10.2      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Depending on the Group\/Type, the Group\/Content can only contain certain tags:  
\- 'poll': Can contain multiple instances of one of the below tags but not a mix of them:  
    \- 'Param'  
    \- 'Pair'  
    \- 'Session'  
\- 'action' \/ 'poll action': Can only contain Action tags.  
\- 'trigger' \/ 'poll trigger': Can only contain Trigger tags.
