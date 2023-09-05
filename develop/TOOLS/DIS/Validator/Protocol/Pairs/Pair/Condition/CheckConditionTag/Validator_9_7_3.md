---  
uid: Validator_9_7_3  
---

# CheckConditionTag

## ConditionCanBeSimplified

### Description

Condition '{conditionString}' can be simplified. Pair ID '{pairId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Pair        |
| Full Id      | 9.7.3       |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Pair\/Condition' can be simplified. Some examples of when the condition can be simplified:  
  \- The condition contains redundant parentheses.  
  \- The condition does not contain a variable and therefore can either be dropped completely (or a variable must be included).
