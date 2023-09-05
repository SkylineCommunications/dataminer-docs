---  
uid: Validator_3_35_3  
---

# CheckConditionTag

## ConditionCanBeSimplified

### Description

Condition '{conditionString}' can be simplified. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.35.3      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'QAction\/Condition' can be simplified. Some examples of when the condition can be simplified:  
  \- The condition contains redundant parentheses.  
  \- The condition does not contain a variable and therefore can either be dropped completely (or a variable must be included).
