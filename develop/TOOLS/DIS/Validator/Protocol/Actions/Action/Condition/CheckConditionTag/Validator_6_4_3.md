---  
uid: Validator_6_4_3  
---

# CheckConditionTag

## ConditionCanBeSimplified

### Description

Condition '{conditionString}' can be simplified. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.4.3       |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Action\/Condition' can be simplified. Some examples of when the condition can be simplified:  
  \- The condition contains redundant parentheses.  
  \- The condition does not contain a variable and therefore can either be dropped completely (or a variable must be included).
