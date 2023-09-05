---  
uid: Validator_4_9_3  
---

# CheckConditionTag

## ConditionCanBeSimplified

### Description

Condition '{conditionString}' can be simplified. Group ID '{groupId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Group       |
| Full Id      | 4.9.3       |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Group\/Condition' can be simplified. Some examples of when the condition can be simplified:  
  \- The condition contains redundant parentheses.  
  \- The condition does not contain a variable and therefore can either be dropped completely (or a variable must be included).
