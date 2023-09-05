---  
uid: Validator_7_4_4  
---

# CheckConditionTag

## ConditionCanBeSimplified

### Description

Condition '{conditionString}' can be simplified. Timer ID '{timerId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Timer       |
| Full Id      | 7.4.4       |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Timer\/Condition' can be simplified. Some examples of when the condition can be simplified:  
  \- The condition contains redundant parentheses.  
  \- The condition does not contain a variable and therefore can either be dropped completely (or a variable must be included).
